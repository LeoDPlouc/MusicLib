using MusicLib.Objects;
using MusicLib.Files;
using MusicLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MusicLib.Config;

namespace MusicLib.Processing
{
    public class SongCollector
    {
        private static Thread collector;
        private static bool cancel;

        public static void Start()
        {
            cancel = false;

            collector = new Thread(DoWork);
            collector.Start(new object[]
            {
                Configuration.LibraryPath,
                Configuration.ServerEnabled
            });
        }

        public static void Stop()
        {
            cancel = true;
            while (collector.IsAlive)
                Thread.Sleep(10);
        }

        private static void DoWork(object arg)
        {
            object[] args = arg as object[];

            while (!cancel)
            {
                Collect(args[0] as string, (bool)args[1]).Wait();
                Thread.Sleep(5000);
            }
        }

        private static async Task Collect(string path, bool serverEnabled)
        {
            SongCollection songs = SongCollection.GetMainCollection();
            string[] paths = FileHandler.ListAllSongPath(path);

            int count = 0;

            foreach(string p in paths)
            {
                if (cancel)
                    return;

                Song song = null;
                try
                {
                    song = await LoadSong(p, serverEnabled);
                }
                catch(Exception e)
                {
                    FileHandler.ConvertToMP3(p);
                    song = await LoadSong(p, serverEnabled);
                }

                if (song != null)
                {
                    songs.Add(song);
                    count++;
                }

                if (count >= 100)
                {
                    AlbumCollection.FetchAlbums();
                    count = 0;
                }
            }
            AlbumCollection.FetchAlbums();
        }

        private static async Task<Song> LoadSong(string path, bool serverEnabled)
        {
            if (SongCollection.GetMainCollection().Any(s => s.Path == path))
                return null;

            Song song = FileHandler.LoadSong(path);

            if (song.AcousticId is null)
            {
                song.AcousticId = AcousticID.ComputeAcousticId(song.Path);
                FileHandler.SaveSong(song);
            }

            SongInfo songInfo;
            if (serverEnabled)
                songInfo = await Client.GetSongInfo(song.AcousticId, "127.0.0.1");
            else
                songInfo = InfoFiles.Load(song.AcousticId);

            song.Heart = songInfo.Heart;
            song.Like = songInfo.Like;

            return song;
        }
    }
}

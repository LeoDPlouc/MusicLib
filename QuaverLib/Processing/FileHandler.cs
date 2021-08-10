using MusicLib.Objects;
using System.Linq;
using System.IO;
using System.Text;
using TagLib;
using TagLib.Id3v2;
using File = System.IO.File;
using System.Threading.Tasks;
using System.Threading;
using FFMpegCore;
using FFMpegCore.Enums;
using System;

namespace MusicLib.Processing
{
    public class FileHandler
    {
        private const string ACOUSTICID_TAG = "AcousticId";

        public static string[] ListAllSongPath(string path)
        {
            return Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
        }
        public static Song LoadSong(string path)
        {
            TagLib.File f = null;
            Song song;
            try
            {
                f = TagLib.File.Create(path);

                string acousticId = GetCustomTag(f, ACOUSTICID_TAG);

                song = new Song
                {
                    Album = f.Tag.Album,
                    Artist = f.Tag.FirstAlbumArtist,
                    Duration = f.Properties.Duration.TotalMinutes,
                    N = (int)f.Tag.Track,
                    Path = path,
                    Title = f.Tag.Title,
                    AcousticId = acousticId
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                f?.Dispose();
            }

            return song;
        }
        public static void SaveSong(Song song)
        {
            TagLib.File f = null;
            try
            {
                f = TagLib.File.Create(song.Path);

                f.Tag.Album = song.Album;
                f.Tag.AlbumArtists = new string[] { song.Artist };
                f.Tag.Pictures = new Picture[] { new Picture(new ByteVector(song.GetCover())) };
                f.Tag.Track = (uint)song.N;
                f.Tag.Title = song.Title;

                SetCustomTag(f, ACOUSTICID_TAG, song.AcousticId);

                WaitFileAvailaible(song.Path);
                f.Save();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                f?.Dispose();
            }
        }

        public static byte[] LoadCover(string path)
        {
            TagLib.File f = null;
            byte[] data;
            try
            {
                f = TagLib.File.Create(path);
                IPicture[] pics = f.Tag.Pictures;

                data = new byte[0];
                if (pics.Length > 0)
                    data = pics.First().Data.Data;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                f?.Dispose();
            }

            return data;
        }
        public static bool CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return false;
            }
            return true;
        }
        public static bool CheckFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return false;
            }
            return true;
        }

        public static void ConvertToMP3(string path)
        {
            GlobalFFOptions.Configure(new FFOptions()
            {
                BinaryFolder = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg")
            });

            string pathTemp = Path.ChangeExtension(path, ".temp.mp3");

            WaitFileAvailaible(path);

            FFMpegArguments
                .FromFileInput(path)
                .OutputToFile(pathTemp)
                .ProcessSynchronously();

            WaitFileAvailaible(pathTemp);
            WaitFileAvailaible(path);

            File.Delete(path);
            File.Move(pathTemp, path);
        }

        private static string GetCustomTag(TagLib.File file, string tagName)
        {
            var tag = (TagLib.Id3v2.Tag)file.GetTag(TagTypes.Id3v2);
            PrivateFrame frame = PrivateFrame.Get(tag, tagName, false);
            if (frame is null)
                return null;
            return Encoding.Unicode.GetString(frame.PrivateData.Data);
        }
        private static void SetCustomTag(TagLib.File file, string tagName, string value)
        {
            var tag = (TagLib.Id3v2.Tag)file.GetTag(TagTypes.Id3v2);
            PrivateFrame frame = PrivateFrame.Get(tag, tagName, true);
            frame.PrivateData = Encoding.Unicode.GetBytes(value);
        }

        private static void WaitFileAvailaible(string path)
        {
            int i = 0;
            while (i < 1000)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(path, FileMode.Append);
                    break;
                }
                catch
                {
                    i++;
                    Thread.Sleep(50);
                }
                finally
                {
                    fs?.Close();
                    fs?.Dispose();
                }
            }
        }
    }
}

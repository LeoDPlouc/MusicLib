using MusicLib.Files;
using MusicLib.Processing;
using MusicLib.Server;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicLib.Objects
{
    [Serializable]
    public partial class Song
    {
        public string Title { get; set; }
        public int N { get; set; }
        public double Duration { get; set; }
        public bool Like { get; set; }
        public bool Heart { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Path { get; set; }
        public string AcousticId { get; set; }


        public byte[] GetCover() => FileHandler.LoadCover(Path);
        public SongInfo GetSongInfo()
        {
            return new SongInfo
            {
                AcousticId = this.AcousticId,
                Like = this.Like,
                Heart = this.Heart
            };
        }
        public async Task Save()
        {
            FileHandler.SaveSong(this);
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize<Song>(this);
        }
        public static Song Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Song>(json);
        }
    }
}

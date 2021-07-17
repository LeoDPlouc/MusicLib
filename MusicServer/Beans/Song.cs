using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace MusicServer.Beans
{
    [Serializable]
    public partial class Song
    {
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public bool Like { get; set; }
        public bool Heart { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }
        public string AcousticId { get; set; }
        public async Task Save()
        {
            using(var fs = File.Create("SongData/" + AcousticId))
            {
                await JsonSerializer.SerializeAsync(fs, this, typeof(Song));
            }
        }

        public static Song Parse(string json)
        {
            return (Song)JsonSerializer.Deserialize(json, typeof(Song));
        }

        public static async Task<Song> Load(string AcousticID)
        {
            using(var fs = File.OpenRead("SongData/" + AcousticID))
            {
                return await JsonSerializer.DeserializeAsync(fs, typeof(Song)) as Song;
            }
        }
    }
}

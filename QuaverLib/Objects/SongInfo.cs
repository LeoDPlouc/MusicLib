using MusicLib.Config;
using MusicLib.Files;
using MusicLib.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicLib.Objects
{
    [Serializable]
    public class SongInfo
    {
        public bool Like { get; set; }
        public bool Heart { get; set; }
        public string AcousticId { get; set; }
        public string Host { get; set; }
        public string Serialize()
        {
            return JsonSerializer.Serialize<SongInfo>(this);
        }
        public static SongInfo Deserialize(string json)
        {
            return JsonSerializer.Deserialize<SongInfo>(json);
        }

        public async Task Save()
        {
            if (Configuration.ServerEnabled)
                await Client.SendSongInfo(this, "127.0.0.1");
            else
                InfoFiles.Save(this);
        }
    }
}

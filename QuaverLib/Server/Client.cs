using MusicLib.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static MusicLib.Objects.Song;

namespace MusicLib.Server
{
    public class Client
    {
        public static async Task SendSongInfo(SongInfo info, string servAddr)
        {
            string json = info.Serialize();

            HttpClient client = new HttpClient();
            await client.PostAsync("http://" + servAddr + ":" + 8000 + "/info/", new StringContent(json));
        }

        public static async Task<SongInfo> GetSongInfo(string acousticId, string servAddr)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync("http://" + servAddr + ":" + 8000 + "/info/" + "?acousticId=" + acousticId, HttpCompletionOption.ResponseContentRead);
            string json = await res.Content.ReadAsStringAsync();
            return SongInfo.Deserialize(json);
        }
    }
}

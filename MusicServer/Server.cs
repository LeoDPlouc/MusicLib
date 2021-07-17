using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net;
using System.IO;
using System.Web;
using MusicServer.Beans;

namespace MusicServer
{
    class Server
    {
        static HttpListener listener;

        public static void Start()
        {
            if (listener != null) return;

            listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8000/");
            listener.Start();

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                string url = context.Request.RawUrl;
                if (url.StartsWith("/song/"))
                {
                    if(context.Request.HttpMethod == "GET")
                        getSong(context);
                    if(context.Request.HttpMethod == "POST")
                        postSong(context);
                }
                context.Response.Close();
            }
        }
        private static async void postSong(HttpListenerContext context)
        {
            string json = processBody(context.Request);
            Song song = Song.Parse(json);

            Console.WriteLine("POST " + song.AcousticId);

            await song.Save();
        }

        private static void getSong(HttpListenerContext context)
        {
            string acousticId = HttpUtility.ParseQueryString(context.Request.Url.Query).Get("acousticId");

            Console.WriteLine("GET " + acousticId);

            string songData = getJSONFile("SongData/" + acousticId);
            if(songData == null)
            {
                context.Response.StatusCode = 404;
                songData = "File not found";
            }
            using (var stream = context.Response.OutputStream)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(songData);
                context.Response.ContentLength64 = buffer.Length;
                stream.Write(buffer, 0, buffer.Length);
            }
        }
        private static string processBody(HttpListenerRequest req)
        {
            string body;
            using (var stream = new StreamReader(req.InputStream))
            {
                body = stream.ReadToEnd();
            }

            return body;
        }

        private static string getJSONFile(string path)
        {
            if (!File.Exists(path))
                return null;
            using (var stream = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                return stream.ReadToEnd();
            }
        }
    }
}

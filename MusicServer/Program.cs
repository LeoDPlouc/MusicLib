using MusicServer.Beans;
using System;
using System.IO;

namespace MusicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("SongData"))
                Directory.CreateDirectory("SongData");

            Server.Start();
        }
    }
}

using MusicLib.Processing;
using MusicLib.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography;
using static MusicLib.Objects.Song;

namespace MusicLib.Files
{
    public class InfoFiles
    {
        public static string PATH = "Info/";

        public static void Save(SongInfo songInfo)
        {
            FileHandler.CheckDirectory(PATH);

            string hash = ComputeHash(songInfo.AcousticId);

            string json = songInfo.Serialize();
            using (var fs = File.Create(PATH + hash))
            {
                byte[] buffer = Encoding.Unicode.GetBytes(json);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public static SongInfo Load(string AcousticID)
        {
            string hash = ComputeHash(AcousticID);
            string fullPath = PATH + hash;

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath, Encoding.Unicode);
                return SongInfo.Deserialize(json);
            }

            return new SongInfo
            {
                AcousticId = AcousticID,
                Heart = false,
                Like = false
            };
        }

        private static string ComputeHash(string acousticId)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(acousticId);
            byte[] hashByte = MD5.Create().ComputeHash(buffer);
            return BitConverter.ToString(hashByte);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicLib.Objects
{
    public class Album
    {
        public Album() => Songs = new SongCollection(new Song[0]);
        public string Title { get; set; }
        public string Artist { get; set; }
        public SongCollection Songs { get; set; }
        public byte[] Cover { get => Songs.First().GetCover(); }
    }
}

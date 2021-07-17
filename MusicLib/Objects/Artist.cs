using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLib.Objects
{
    public class Artist
    {
        public Artist() => Albums = new AlbumCollection(new Album[0]);
        public string Name { get; set; }
        public AlbumCollection Albums;
    }
}

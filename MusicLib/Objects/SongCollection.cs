using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicLib.Objects
{
    public class SongCollection : IEnumerable<Song>, ICollection<Song>
    {
        private static SongCollection mainCollection;

        private List<Song> localCollection;

        public int Count => localCollection.Count;
        public bool IsReadOnly => false;

        public event EventHandler<SongCollectionEventArgs> CollectionChanged;
        public void OnCollectionChanged(SongCollectionEventArgs.ChangeType type, Song changedSong) => CollectionChanged?.Invoke(this, new SongCollectionEventArgs { ChangedSong = changedSong, ChangeTypeArg = type });
        public SongCollection(IEnumerable<Song> songsSource)
        {
            localCollection = new List<Song>();
            foreach (Song s in songsSource)
                localCollection.Add(s);
        }
        public static SongCollection GetMainCollection()
        {
            if (mainCollection is null)
                mainCollection = new SongCollection(new Song[0]);
            return mainCollection;
        }

        public List<Song> SearchByTitle(string arg)
        {
            Regex pattern = new Regex(arg);

            return localCollection.FindAll((Song s) =>
            {
                return pattern.IsMatch(s.Title);
            });
        }
        public List<Song> SearchByAlbum(string arg)
        {
            Regex pattern = new Regex(arg);

            return localCollection.FindAll((Song s) =>
            {
                return pattern.IsMatch(s.Album);
            });
        }
        public List<Song> SearchByArtist(string arg)
        {
            Regex pattern = new Regex(arg);

            return localCollection.FindAll((Song s) =>
            {
                return pattern.IsMatch(s.Artist);
            });
        }

        public IEnumerator<Song> GetEnumerator() => localCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => localCollection.GetEnumerator();

        public void Add(Song item)
        {
            if(item != null)
            {
                localCollection.Add(item);
                OnCollectionChanged(SongCollectionEventArgs.ChangeType.Add, item);
            }
            if (this == mainCollection)
                AlbumCollection.FetchAlbums();
        }
        public void Clear()
        {
            localCollection.Clear();
            OnCollectionChanged(SongCollectionEventArgs.ChangeType.Clear, null);
        }
        public bool Contains(Song item) => localCollection.Contains(item);
        public void CopyTo(Song[] array, int arrayIndex) => localCollection.CopyTo(array, arrayIndex);
        public bool Remove(Song item)
        {
            bool remove = localCollection.Remove(item);
            OnCollectionChanged(SongCollectionEventArgs.ChangeType.Remove, item);
            return remove;
        }
    }

    public class SongCollectionEventArgs : EventArgs
    {
        public enum ChangeType
        {
            Clear,
            Remove,
            Add
        }

        public ChangeType ChangeTypeArg { get; set; }
        public Song ChangedSong { get; set; }

    }
}

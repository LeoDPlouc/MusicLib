using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicLib.Objects
{
    public class AlbumCollection : IEnumerable<Album>, ICollection<Album>
    {
        private static AlbumCollection mainCollection;

        private List<Album> localCollection;

        public int Count => localCollection.Count;

        public bool IsReadOnly => false;

        public event EventHandler<AlbumCollectionEventArgs> CollectionChanged;
        public void OnCollectionChanged(AlbumCollectionEventArgs.ChangeType type, Album albumChanged) => CollectionChanged?.Invoke(this, new AlbumCollectionEventArgs { ChangeTypeArg = type, ChangedAlbum = albumChanged });

        public AlbumCollection(IEnumerable<Album> albumsSource)
        {
            localCollection = new List<Album>();
            foreach (Album a in albumsSource)
                localCollection.Add(a);
        }
        public static AlbumCollection GetMainCollection()
        {
            if (mainCollection is null)
                mainCollection = new AlbumCollection(new Album[0]);
            return mainCollection;
        }

        public static void FetchAlbums()
        {
            GetMainCollection();
            foreach (Song s in SongCollection.GetMainCollection())
            {
                var album = mainCollection.localCollection.Find((Album a) =>
                {
                    return a.Title == s.Album;
                });

                if (album == null)
                {
                    album = new Album() { Title = s.Album, Artist = s.Artist };
                    if (!album.Songs.Contains(s))
                        album.Songs.Add(s);
                    mainCollection.Add(album);
                }
                else
                {
                    if (!album.Songs.Contains(s))
                        album.Songs.Add(s);
                }
            }

            ArtistCollection.FetchArtists();
        }

        public List<Album> SearchByTitle(string arg)
        {
            Regex pattern = new Regex(arg);

            return localCollection.FindAll((Album a) =>
            {
                return pattern.IsMatch(a.Title);
            });
        }

        public IEnumerator<Album> GetEnumerator() => localCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => localCollection.GetEnumerator();

        public void Add(Album item)
        {
            localCollection.Add(item);
            OnCollectionChanged(AlbumCollectionEventArgs.ChangeType.Add, item);
        }
        public void Clear()
        {
            localCollection.Clear();
            OnCollectionChanged(AlbumCollectionEventArgs.ChangeType.Clear, null);
        }
        public bool Contains(Album item) => localCollection.Contains(item);
        public void CopyTo(Album[] array, int arrayIndex) => localCollection.CopyTo(array, arrayIndex);
        public bool Remove(Album item)
        {
            bool remove = localCollection.Remove(item);
            OnCollectionChanged(AlbumCollectionEventArgs.ChangeType.Remove, item);
            return remove;
        }
    }

    public class AlbumCollectionEventArgs : EventArgs
    {
        public enum ChangeType
        {
            Clear,
            Remove,
            Add
        }

        public ChangeType ChangeTypeArg { get; set; }
        public Album ChangedAlbum { get; set; }

    }
}

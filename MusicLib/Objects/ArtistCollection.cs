using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicLib.Objects
{
    public class ArtistCollection : IEnumerable<Artist>, ICollection<Artist>
    {
        private static ArtistCollection mainCollection;

        private List<Artist> localCollection;

        public int Count => localCollection.Count;
        public bool IsReadOnly => false;

        public event EventHandler<ArtistCollectionEventArgs> CollectionChanged;
        public void OnCollectionChanged(ArtistCollectionEventArgs.ChangeType type, Artist artistChanged) => CollectionChanged?.Invoke(this, new ArtistCollectionEventArgs { ChangeTypeArg = type, ChangedArtist = artistChanged });

        public ArtistCollection(IEnumerable<Artist> artistsSource)
        {
            localCollection = new List<Artist>();
            foreach (Artist a in artistsSource)
                localCollection.Add(a);
        }
        public static ArtistCollection GetMainCollection()
        {
            if (mainCollection is null)
                mainCollection = new ArtistCollection(new Artist[0]);
            return mainCollection;
        }

        public static void FetchArtists()
        {
            GetMainCollection();
            foreach (Album alb in AlbumCollection.GetMainCollection())
            {
                var artist = mainCollection.localCollection.Find((Artist art) => alb.Artist == art.Name);

                if (artist == null)
                {
                    artist = new Artist() { Name = alb.Artist };
                    if (!artist.Albums.Contains(alb))
                        artist.Albums.Add(alb);
                    mainCollection.Add(artist);
                }
                else
                {
                    if (!artist.Albums.Contains(alb))
                        artist.Albums.Add(alb);
                }
            }
        }

        public List<Artist> SearchByName(string arg)
        {
            Regex pattern = new Regex(arg);

            return localCollection.FindAll((Artist a) =>
            {
                return pattern.IsMatch(a.Name);
            });
        }

        public IEnumerator<Artist> GetEnumerator() => localCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => localCollection.GetEnumerator();

        public void Add(Artist item)
        {
            localCollection.Add(item);
            OnCollectionChanged(ArtistCollectionEventArgs.ChangeType.Add, item);
        }
        public void Clear()
        {
            localCollection.Clear();
            OnCollectionChanged(ArtistCollectionEventArgs.ChangeType.Clear, null);
        }
        public bool Contains(Artist item) => localCollection.Contains(item);
        public void CopyTo(Artist[] array, int arrayIndex) => localCollection.CopyTo(array, arrayIndex);
        public bool Remove(Artist item)
        {
            bool remove = localCollection.Remove(item);
            OnCollectionChanged(ArtistCollectionEventArgs.ChangeType.Remove, item);
            return remove;
        }
    }
    public class ArtistCollectionEventArgs : EventArgs
    {
        public enum ChangeType
        {
            Clear,
            Remove,
            Add
        }

        public ChangeType ChangeTypeArg { get; set; }
        public Artist ChangedArtist { get; set; }

    }
}

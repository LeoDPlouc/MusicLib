using MusicLib.Objects;
using Xunit;

namespace MusicLibTest
{
    [Collection("Collection Tests")]
    public class ArstisCollectionTest
    {
        [Fact]
        public void FetchArtistsTest()
        {
            SongCollection.GetMainCollection().Clear();
            AlbumCollection.GetMainCollection().Clear();
            ArtistCollection.GetMainCollection().Clear();

            Album a1 = new Album { Title = "album 1", Artist = "artist 1" };
            Album a2 = new Album { Title = "album 2", Artist = "artist 2" };
            Album a3 = new Album { Title = "album 3", Artist = "artist 3" };

            AlbumCollection.GetMainCollection().Add(a1);
            AlbumCollection.GetMainCollection().Add(a2);
            AlbumCollection.GetMainCollection().Add(a3);

            ArtistCollection.FetchArtists();

            Assert.Equal(3, ArtistCollection.GetMainCollection().Count);
        }
    }
}

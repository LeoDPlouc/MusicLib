using MusicLib.Objects;
using Xunit;

namespace MusicLibTest
{
    [Collection("Collection Tests")]
    public class AlbumCollectionTest
    {
        [Fact]
        public void FetchAlbumsTest()
        {
            SongCollection.GetMainCollection().Clear();
            AlbumCollection.GetMainCollection().Clear();
            ArtistCollection.GetMainCollection().Clear();

            Song s1 = new Song { Title = "song 1", Album = "album 1" };
            Song s2 = new Song { Title = "song 2", Album = "album 2" };
            Song s3 = new Song { Title = "song 3", Album = "album 3" };

            SongCollection.GetMainCollection().Add(s1);
            SongCollection.GetMainCollection().Add(s2);
            SongCollection.GetMainCollection().Add(s3);

            AlbumCollection.FetchAlbums();

            Assert.Equal(3, AlbumCollection.GetMainCollection().Count);
        }
    }
}

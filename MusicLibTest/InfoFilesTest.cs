using MusicLib.Files;
using MusicLib.Objects;
using Xunit;

namespace MusicLibTest
{
    public class InfoFilesTest
    {
        [Fact]
        public void InfoFileTest()
        {
            SongInfo si = new SongInfo() { AcousticId = "test", Heart = true, Host = "test", Like = false };

            InfoFiles.Save(si);
            SongInfo siTest = InfoFiles.Load("test");

            Assert.Equal(si.AcousticId, siTest.AcousticId);
            Assert.Equal(si.Heart, siTest.Heart);
            Assert.Equal(si.Host, siTest.Host);
            Assert.Equal(si.Like, siTest.Like);
        }
    }
}

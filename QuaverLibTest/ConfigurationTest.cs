using MusicLib.Config;
using System;
using Xunit;

namespace MusicLibTest
{
    public class ConfigurationTest
    {
        [Fact]
        public void ServerEnabledTrueTest()
        {
            Configuration.ServerEnabled = true;

            Assert.True(Configuration.ServerEnabled);
        }

        [Fact]
        public void ServerEnabledFalseTest()
        {
            Configuration.ServerEnabled = false;

            Assert.False(Configuration.ServerEnabled);
        }

        [Fact]
        public void LibraryPathTest()
        {
            string path = @"~/music";

            Configuration.LibraryPath = path;

            Assert.Equal(path, Configuration.LibraryPath);
        }
    }
}

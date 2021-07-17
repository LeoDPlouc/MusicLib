using MusicLib.Objects;
using System;
using System.Collections.Generic;

namespace MusicLib.Parts
{
    public class Playlist
    {
        /// <summary>
        /// Initialise the Playlist
        /// </summary>
        public static void InitPlaylist()
        {
            SongList = new List<Song>();

            Player.SongFinished += Playlist_SongFinished;
        }
        /// <summary>
        /// Go to the next song when the current song is over
        /// </summary>
        private static void Playlist_SongFinished(object sender, EventArgs e)
        {
            CurrentSong = Next();
        }

        #region Public Members
        /// <summary>
        /// The list of the songs currently in the Playlist
        /// </summary>
        public static List<Song> SongList { get; private set; }
        public static Song CurrentSong { get; private set; }
        #endregion

        #region Events
        public static event EventHandler PlaylistChanged;
        public static event EventHandler SongChanged;
        /// <summary>
        /// Raise an event when the songlist is changed
        /// </summary>
        protected static void OnPlaylistChanged()
        {
            PlaylistChanged?.Invoke(null, new EventArgs());
        }
        /// <summary>
        /// Raise an event when the current song changes
        /// </summary>
        protected static void OnSongChanged()
        {
            SongChanged?.Invoke(null, new EventArgs());
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Go to the next song
        /// </summary>
        /// <returns>The next song</returns>
        public static Song Next()
        {
            CurrentSong = SongList[GetPosition() + 1];

            OnSongChanged();

            return CurrentSong;
        }
        /// <summary>
        /// Get the position of the current song in the songlist
        /// </summary>
        /// <returns>The index of the song</returns>
        public static int GetPosition() => SongList.FindIndex((Song s) => s == CurrentSong);
        /// <summary>
        /// Change the current song if the new song is in the songlist
        /// </summary>
        /// <param name="song">The new song</param>
        public static void SetCurrentSong(Song song)
        {
            if (SongList.Contains(song))
                CurrentSong = song;

            OnSongChanged();
        }
        /// <summary>
        /// Change the current song if the new song is in the songlist
        /// If it's not load the new songlist then change the current song
        /// </summary>
        /// <param name="song">The new song</param>
        public static void SetCurrentSong(Song song, IEnumerable<Song> songlist)
        {
            Load(songlist);
                
            CurrentSong = song;
            OnSongChanged();
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Load the collection of songs as the playlist's songs
        /// </summary>
        /// <param name="songs">A collection of songs to load</param>
        private static void Load(IEnumerable<Song> songs)
        {
            SongList.Clear();
            foreach (Song s in songs) SongList.Add(s);

            OnPlaylistChanged();
        }
        #endregion
    }
}

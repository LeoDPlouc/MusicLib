using MusicLib.Config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicLib.Control
{
    public partial class ConfigControl : UserControl
    {
        public ConfigControl() => InitializeComponent();

        private void ServerEnabledControl_CheckStateChanged(object sender, EventArgs e)
        {
            Configuration.ServerEnabled = serverEnabledControl.Checked;
        }

        private void PathControl_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string path = folderBrowser.SelectedPath;


            if (!string.IsNullOrEmpty(path))
                Configuration.LibraryPath = path;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using Microsoft.SilverlightMediaFramework.Core;
using Microsoft.SilverlightMediaFramework.Core.Media;
using Microsoft.SilverlightMediaFramework.Plugins.Primitives;

namespace Player
{
    public partial class MainPage : UserControl
    {
        private Uri _media;

        public MainPage()
        {
            InitializeComponent();
            HtmlPage.RegisterScriptableObject("Player", this);
        }

        public MainPage(Uri media) : this()
        {
            _media = media;
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMedia();
        }

        private void UpdateMedia()
        {
            var item = new PlaylistItem
                           {
                               MediaSource = _media,
                               DeliveryMethod = DeliveryMethods.AdaptiveStreaming
                           };

            Player.Playlist.Clear();
            Player.Playlist.Add(item);
        }

        [ScriptableMember]
        public void SetMedia(string mediaUrl)
        {
            _media = new Uri(mediaUrl, UriKind.RelativeOrAbsolute);
            UpdateMedia();
        }

        [ScriptableMember]
        public void Play()
        {
            Player.Play();
        }

        [ScriptableMember]
        public void Pause()
        {
            Player.Pause();
        }
        
        [ScriptableMember]
        public void Stop()
        {
            Player.Stop();
            Player.Playlist.Clear();
        }

        [ScriptableMember]
        public void SeekToPosition(double time)
        {
            Player.SeekToPosition(time);
        }

        [ScriptableMember]
        public void TakeScreenshot()
        {
            throw new NotImplementedException();
        }

        [ScriptableMember]
        public void ShowGraph()
        {
            Player.PlayerGraphVisibility = Player.PlayerGraphVisibility == FeatureVisibility.Visible
                                               ? FeatureVisibility.Hidden
                                               : FeatureVisibility.Visible;
        }
    }
}

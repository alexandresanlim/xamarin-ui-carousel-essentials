using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App.CardTools.iOS.Services;
using App.CardTools.Models._1___Interface;
using AVFoundation;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace App.CardTools.iOS.Services
{
    public class AudioService : IAudio
    {
        public AudioService()
        { }
        public void PlayAudioFile(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _player = AVAudioPlayer.FromUrl(url);
            _player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _player = null;
            };
            _player.Play();
        }
    }
}
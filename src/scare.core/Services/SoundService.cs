using Prism.Events;
using Scare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Scare.Core.Model;

namespace scare.core.Services
{
    public class SoundService
    {
        private List<MediaElement> _mediaElements = new List<MediaElement>();
        private readonly IEventAggregator _events;
        private SubscriptionToken _soundEventToken = null;

        public SoundService(IEventAggregator events)
        {
            _events = events;
            _soundEventToken = _events.GetEvent<Events.SoundEvent>().Subscribe((args) =>
            {
                this.OnSoundEvent(args);
            }, ThreadOption.UIThread);

            _mediaElements.Add(new MediaElement());
            _mediaElements.Add(new MediaElement());
            _mediaElements.Add(new MediaElement());
            _mediaElements.Add(new MediaElement());
            _mediaElements.Add(new MediaElement());
            _mediaElements.Add(new MediaElement());
        }

        private void OnSoundEvent(SoundEventArgs args)
        {
            if (args == null)
                return;
            Play(args.Channel, args.FileName);
        }

        public async void Play(int channel, string fileName)
        {
            Windows.Storage.StorageFile storageFile = await Windows.Storage.KnownFolders.MusicLibrary.GetFileAsync(fileName);
            var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            if (null != stream)
            {
                if (channel > -1 && channel < _mediaElements.Count)
                {
                    var media = _mediaElements[channel];
                    media.SetSource(stream, storageFile.ContentType);
                    media.Play();
                }
            }
        }
        public void Stop(int channel)
        {
            if (channel > -1 && channel < _mediaElements.Count)
            {
                var media = _mediaElements[channel];
                media.Stop();
            }
        }

        public void StopAll()
        {
            for (int x = 0; x < _mediaElements.Count; x++)
            {
                _mediaElements[x].Stop();
            }
        }
    }
}

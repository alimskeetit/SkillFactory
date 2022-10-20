using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace SFPracticum18._4._1
{
    internal class DownloadVideo : Command
    {
        string URL;
        string path;

        public DownloadVideo(string URL, string path)
        {
            this.URL = URL;
            this.path = path;
        }

        public override async void Execute()
        {
            var youtube = new YoutubeClient();
            var video = foo1Async();

            var streamManifest = foo2Async(youtube, video.Result);

            var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestVideoQuality();

            await youtube.Videos.Streams.DownloadAsync(streamInfo, "video.mp4");
        }

        private async Task<Video> foo1Async()
        {
            var youtube = new YoutubeClient();
            return await youtube.Videos.GetAsync(URL);
        }

        private async Task<StreamManifest> foo2Async(YoutubeClient youtube, Video video)
        {
            return await youtube.Videos.Streams.GetManifestAsync(video.Id);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}

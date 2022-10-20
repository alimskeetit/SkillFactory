using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace SFPracticum18._4._1
{
    internal class GetDescription : Command
    {
        Video video;

        public GetDescription(Video video)
        {
            this.video = video;
        }

        public override void Execute()
        {
            Console.WriteLine(video.Description);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}

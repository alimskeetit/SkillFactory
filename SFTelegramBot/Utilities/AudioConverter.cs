using FFMpegCore;
using SFTelegramBot.Extensions;

namespace SFTelegramBot.Utilities
{
    public class AudioConverter
    {
        public static void TryConvert(string inputFile, string outputFile)
        {
            var b = @Path.Combine(DirectoryExtension.GetSolutionRoot(), "ffmpeg-win64", "bin");
            GlobalFFOptions.Configure(options => options.BinaryFolder = Path.Combine(DirectoryExtension.GetSolutionRoot(), "ffmpeg-win64", "bin"));
        
            FFMpegArguments
                .FromFileInput(inputFile)
                .OutputToFile(outputFile, true, options => 
                options.WithFastStart())
                .ProcessSynchronously();
        }
    }
}

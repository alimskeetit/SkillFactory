using SFPracticum18._4._1;
using YoutubeExplode;
using YoutubeExplode.Videos;

class Program
{
    public static async Task Main()
    {
        Console.Write("Введите URL: ");
        string URL = Console.ReadLine();
        Video video = await new YoutubeClient().Videos.GetAsync(URL);
        
        Invoker youTubeCommand = new Invoker();
        
        youTubeCommand.SetCommand(new GetDescription(video));
        youTubeCommand.Run();

        youTubeCommand.SetCommand(new DownloadVideo(URL, "C:\\Users\\Ванч\\Desktop\\asd"));
        youTubeCommand.Run();
    }
}
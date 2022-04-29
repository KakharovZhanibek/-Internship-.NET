// See https://aka.ms/new-console-template for more information
using FileDownloadUsingTPL;


string? testUrl = "";
Console.WriteLine("Enter download url. You can find some in https://file-examples.com/index.php/sample-video-files/sample-mp4-files/"); ;

testUrl = Console.ReadLine();



DownloadManager downloadManager = new DownloadManager();

downloadManager.Download(testUrl, 15);

Console.WriteLine("Press any key.");
Console.ReadKey();
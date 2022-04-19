// See https://aka.ms/new-console-template for more information
using FileDownloadUsingTPL;


string testUrl = "https://file-examples.com/storage/fee8962188625f1ad9b416a/2017/04/file_example_MP4_1920_18MG.mp4";
/*"https://file-examples.com/storage/fe55f31641625f0cc982303/2017/10/file_example_JPG_2500kB.jpg"*/
/*"https://file-examples.com/storage/fe55f31641625f0cc982303/2017/10/file_example_GIF_3500kB.gif";*/
/*"https://file-examples.com/storage/fe55f31641625f0cc982303/2018/04/file_example_OGG_1920_13_3mg.ogg";*/


DownloadManager downloadManager = new DownloadManager();

downloadManager.Download(testUrl, 15);

Console.WriteLine("Press any key.");
Console.ReadKey();
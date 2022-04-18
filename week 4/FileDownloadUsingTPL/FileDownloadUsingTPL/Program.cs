// See https://aka.ms/new-console-template for more information
using FileDownloadUsingTPL;


string testUrl = "https://file-examples.com/storage/fe1170c1cf625dc95987de5/2017/04/file_example_MP4_1920_18MG.mp4";
    /*"https://file-examples.com/storage/fe1170c1cf625dc95987de5/2017/10/file_example_GIF_3500kB.gif";*/
    /*"https://file-examples.com/storage/fe470b25f7625d74f974f35/2017/10/file_example_JPG_2500kB.jpg";*/
/*"https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_1920_18MG.mp4";*/
/*"https://rog.asus.com/us/laptops/rog-flow/rog-flow-z13-2022-series";*/
/*"https://file-examples.com/wp-content/uploads/2017/10/file_example_JPG_500kB.jpg";*/
/*"https://file-examples.com/wp-content/uploads/2017/10/file_example_JPG_2500kB.jpg";*/
/*"https://via.placeholder.com/600/92c952";*/
/*"https://via.placeholder.com/150/92c952";*/
/*"https://file-examples.com/storage/fe470b25f7625d74f974f35/2017/10/file_example_GIF_3500kB.gif";*/


DownloadManager downloadManager = new DownloadManager();
//downloadManager.GetFileSizeInfo(testUrl);

//downloadManager.DownloadTaskSync(testUrl, 8);
//downloadManager.MergeFileChunks();

downloadManager.DownloadParallel(testUrl, 8);
downloadManager.MergeFileChunks();

Console.WriteLine("Press any key.");
Console.ReadKey();
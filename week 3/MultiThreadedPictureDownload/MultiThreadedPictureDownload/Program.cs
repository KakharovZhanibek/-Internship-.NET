using MultiThreadedPictureDownload.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace MultiThreadedPictureDownload
{
    class Program
    {
        static void Main(string[] args)
        {
            string photosUrl = "https://jsonplaceholder.typicode.com/photos";

            PhotoDownloadManager downloadManager = new PhotoDownloadManager();

            downloadManager.TakeDownloadUrls(photosUrl);

            downloadManager.MultithreadedDownload(10);

        }
    }
}

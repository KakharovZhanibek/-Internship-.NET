using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadedPictureDownload.Models
{
    class PhotoDownloadManager
    {
        private List<string> downloadUrls = new List<string>();
        private Dictionary<Thread, List<string>> threadUrls = new Dictionary<Thread, List<string>>();
       
        private void Download()
        {
            using (WebClient webClient = new WebClient())
            {
                foreach (string url in threadUrls[Thread.CurrentThread])
                {
                    webClient.DownloadFile(url, "Pictures\\IMAGE" + Guid.NewGuid().ToString() + ".png");
                    Thread.Sleep(3000);
                }
            }
        }

        public void MultithreadedDownload(int threadCount)
        {
            if (threadCount > 0 && threadCount <= 15)
            {
                DistributeOnThreads(threadCount);
                foreach (var item in threadUrls)
                {
                    item.Key.Start();
                }
            }
            else
            {
                Console.WriteLine("Invalid number of Threads! Example: 0 < X < 15.");
            }
        }
        private void DistributeOnThreads(int threadCount)
        {
            int urlsPerThread = downloadUrls.Count / threadCount;
            int counter = 0;
            int remains;

            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(Download);
                threadUrls.Add(thread, downloadUrls.GetRange(counter, urlsPerThread));
                counter += urlsPerThread;
            }
            if (downloadUrls.Count % threadCount != 0)
            {
                remains = downloadUrls.Count % threadCount;
                threadUrls.Last().Value.AddRange(downloadUrls.GetRange(counter, remains));
            }
        }

        public void TakeDownloadUrls(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse webResponse = request.GetResponse();

            var enconding = ASCIIEncoding.ASCII;
            string content;
            using (var reader = new StreamReader(webResponse.GetResponseStream(), enconding))
            {
                content = reader.ReadToEnd();
            }

            var jObjects = JArray.Parse(content);

            //just for safe checking
            int limiter = 0;
            //-
            foreach (JObject item in jObjects)
            {
                if (limiter == 50)
                    break;
                downloadUrls.Add(item.SelectToken("thumbnailUrl").ToString());
                limiter++;
            }
        }
    }
}

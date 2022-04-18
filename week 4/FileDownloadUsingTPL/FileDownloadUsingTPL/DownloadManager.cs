using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloadUsingTPL
{
    internal class DownloadManager
    {
        private long fileSize;
        private long chunkSize;
        private string? url;
        private string? folderName;
        private string contentType = "";
        private Dictionary<int, string> fileChunksPaths = new Dictionary<int, string>();
        List<Action> workers = new List<Action>();
        List<Range> ranges = new List<Range>();
        public void GetFileSizeInfo(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url);

                    HttpResponseMessage response = httpClient.Send(request);

                    response.EnsureSuccessStatusCode();

                    this.url = url;

                    fileSize = Convert.ToInt64(response.Content.Headers.GetValues("Content-Length").First());
                    contentType = response.Content.Headers.GetValues("Content-Type").First().Split(@"/").Last();

                    //Console.WriteLine(fileSize + "  |  " + fileSize / 8 + " | " + fileSize % 8 + "  |  " + (double)fileSize / 5);
                    //Console.WriteLine(fileSize + " bytes   Content Type  "+contentType);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException caught!");
                Console.WriteLine("Message :{0}", e.Message);
            }
        }
        public void MergeFileChunks()
        {
            using (FileStream fs = new FileStream(@"..\DownloadedFiles\" + folderName + "\\FinalFile" + "." + contentType, FileMode.Append, FileAccess.Write))
            {
                foreach (var fileChunkPath in fileChunksPaths.OrderBy(o => o.Key))
                {
                    byte[] fileChunkBytes = File.ReadAllBytes(fileChunkPath.Value);
                    File.Delete(fileChunkPath.Value);
                    fs.Write(fileChunkBytes);
                }
            }
        }

        private void ParallelDownloadToPath(long start, long count, int fileChunkCounter)
        {
            Console.WriteLine(Task.CurrentId + "  :  " + start + " | " + count + "  " + fileChunkCounter);

            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();

                request.Method = HttpMethod.Get;
                request.Headers.Range = new RangeHeaderValue(start, count);
                request.RequestUri = new Uri(url);

                 HttpResponseMessage response= httpClient.Send(request);

                //Console.WriteLine(Task.CurrentId + "  Actual Chunk Size\n" + response.Content.Headers.GetValues("Content-Length").First() + "\n");

                response.EnsureSuccessStatusCode();

                string fileChunkPath = "..\\DownloadedFiles\\" + folderName + "\\" + fileChunkCounter.ToString();

                fileChunksPaths.Add(fileChunkCounter, fileChunkPath);

                using var fileStream = File.Create(fileChunkPath);

                using (var downloadStream = response.Content.ReadAsStream())
                {
                    downloadStream.CopyTo(fileStream);
                }
            }
        }
        //public void Download(string url, int tasksCount)
        //{
        //    GetFileSizeInfo(url);

        //    long remains;
        //    long start = 0;
        //    chunkSize = fileSize / tasksCount;
        //    long to = chunkSize;

        //    folderName = Guid.NewGuid().ToString();
        //    string dir = @"..\DownloadedFiles\" + folderName;
        //    Directory.CreateDirectory(dir);

        //    int i = 0;
        //    while (i < tasksCount)
        //    {
        //        Parallel.Invoke(async () => await ParallelDownloadToPath(start, to - 1, i));
        //        start += chunkSize;
        //        to += chunkSize;
        //        i++;
        //    }
        //    if (fileSize % tasksCount != 0)
        //    {
        //        remains = fileSize % tasksCount;
        //        Parallel.Invoke(async () => await ParallelDownloadToPath(start, start + remains - 1, i));
        //    }
        //    Task.WaitAll();
        //}

        public void DownloadParallel(string url, int tasksCount)
        {
            GetFileSizeInfo(url);
            FileSlicer(tasksCount);

            folderName = Guid.NewGuid().ToString();
            string dir = @"..\DownloadedFiles\" + folderName;
            Directory.CreateDirectory(dir);

            int i = 0;
            while (i < tasksCount)
            {
                long testStart = ranges[i].Start;
                long testTo = ranges[i].To;
                int testCounter = i;
                Action action = new Action(() => ParallelDownloadToPath(testStart, testTo, testCounter));
                workers.Add(action);
                i++;
            }
            if (fileSize % tasksCount != 0)
            {
                long testStart = ranges[i].Start;
                long testTo = ranges[i].To;
                int testCounter = i;
                Action action = new Action(() => ParallelDownloadToPath(testStart, testTo, testCounter));
                workers.Add(action);
            }

            Parallel.Invoke(workers.ToArray());
            Task.WaitAll();
        }
        public void FileSlicer(int tasksCount)
        {
            chunkSize = fileSize / tasksCount;
            long remains;
            long start = 0;
            long to = chunkSize;

            for (int i = 0; i < tasksCount; i++)
            {
                Range range = new Range() { Start = start, To = to - 1 };
                ranges.Add(range);
                start += chunkSize;
                to += chunkSize;
            }
            if (fileSize % tasksCount != 0)
            {
                remains = fileSize % tasksCount;
                Range range = new Range() { Start = start, To = start + remains - 1 };
                ranges.Add(range);
            }
        }
    }
}

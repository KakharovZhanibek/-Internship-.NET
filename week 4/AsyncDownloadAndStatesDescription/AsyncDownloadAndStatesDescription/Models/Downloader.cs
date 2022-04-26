using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDownloadAndStatesDescription.Models
{
    internal class Downloader
    {

        public async Task Download(string fileUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await httpClient.GetAsync(fileUrl);
                    var downloadStream = await responseMessage.Content.ReadAsStreamAsync();
                    using (FileStream fs = File.Create(@"..\" + Guid.NewGuid().ToString()))
                    {
                        downloadStream.CopyTo(fs);
                    }
                }
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Exception caught!\n" + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangOutApp.Models
{
    public class Music
    {
        public string MusicName { get; set; }
        public string MusicType { get; set; }

        public Music() { }
        public Music(string musicName, string musicType)
        {
            MusicName = musicName;
            MusicType = musicType;
        }
    }
}

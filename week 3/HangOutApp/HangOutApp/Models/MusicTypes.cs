using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangOutApp.Models
{
    public static class MusicTypes
    {
        public static List<string>Types = new List<string>();
        static MusicTypes()
        {
            Types.Add("HardBass");
            Types.Add("Latino");
            Types.Add("Rock");
        }
        public static void AddMusicType(string musicType)
        {
            Types.Add(musicType);
        }
    }
}

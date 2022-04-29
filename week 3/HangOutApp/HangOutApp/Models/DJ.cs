using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangOutApp.Models
{
    public class DJ
    {
        public List<Music> trackList;
        public void CreateTrackList(List<string> musicTypes)
        {
            Random random = new Random();
            trackList = new List<Music>();

            for (int i = 0; i < 2; i++)
            {
                trackList.Add(
                    new Music
                    {
                        MusicName = "Music" + random.Next(5000).ToString(),
                        MusicType = musicTypes.ElementAt(random.Next(musicTypes.Count))
                    });
            }
        }
        public void StartNewTrack(int counter, Music currentMusic)
        {
            if (counter < trackList.Count)
            {
                currentMusic.MusicName = trackList.ElementAt(counter).MusicName;
                currentMusic.MusicType = trackList.ElementAt(counter).MusicType;
            }
        }
    }
}

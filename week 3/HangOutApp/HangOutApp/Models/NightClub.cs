using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangOutApp.Models
{
    public class NightClub
    {
        private int counter = 0;

        private List<Dancer> _dancers;
        private Music _currentMusic;

        public DJ ClubDJ;

        private Random random = new Random();
        public NightClub()
        {
            _dancers = new List<Dancer>();
            _currentMusic = new Music();
            ClubDJ = new DJ();

            DancingPeople();
        }
        public void StartToHangOut()
        {
            ClubDJ.CreateTrackList(MusicTypes.Types);

            PlayMusicAndDance();

            Console.WriteLine("End Of Party!");
        }
        private void PlayMusicAndDance()
        {
            Console.WriteLine("Start DANCING!");
            while (counter < ClubDJ.trackList.Count)
            {
                ClubDJ.StartNewTrack(counter, _currentMusic);

                Console.WriteLine(_currentMusic.MusicName + "\n" + _currentMusic.MusicType);

                _dancers.ForEach(dancer => dancer.Dance(_currentMusic.MusicType));

                Thread.Sleep(5000);

                counter++;
            }
        }

        public void DancingPeople()
        {
            for (int i = 0; i < random.Next(5, 20); i++)
            {
                _dancers.Add(new Dancer());
            }
        }
    }
}

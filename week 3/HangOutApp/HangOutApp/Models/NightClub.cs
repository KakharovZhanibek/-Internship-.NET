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
        public bool IsTrackListEnded = false;
        private Random random = new Random();

        private ManualResetEvent _manualResetEvent;
        public NightClub()
        {
            _dancers = new List<Dancer>();
            _currentMusic = new Music() { MusicType = "Nothing" };
            ClubDJ = new DJ();
            _manualResetEvent = new ManualResetEvent(false);
            DancingPeople();
        }
        public void StartMultiThreadHangOut()
        {
            Thread startPartyThread = new Thread(StartToHangOut);
            startPartyThread.Start();
        }
        private void StartToHangOut()
        {
            ClubDJ.CreateTrackList(MusicTypes.Types);

            PlayMusicAndDance();

            Console.WriteLine("\nEnd Of Party!");
        }
        private void PlayMusicAndDance()
        {
            Console.WriteLine("Start DANCING!");

            _dancers.ForEach(dancer => new Thread(() => dancer.Dance(_currentMusic, _manualResetEvent,ref IsTrackListEnded)).Start());

            while (counter < ClubDJ.trackList.Count)
            {
                ClubDJ.StartNewTrack(counter, _currentMusic);
                Console.WriteLine($"\n{_currentMusic.MusicName} \n {_currentMusic.MusicType}");
                _manualResetEvent.Set();
                Thread.Sleep(1000);

                counter++;
            }
            IsTrackListEnded = true;
            _manualResetEvent.Set();
        }

        private void DancingPeople()
        {
            int rnd = random.Next(5, 20);
            for (int i = 0; i < rnd; i++)
            {
                _dancers.Add(new Dancer());
            }
        }
    }
}

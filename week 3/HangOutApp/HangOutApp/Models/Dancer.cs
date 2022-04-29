using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangOutApp.Models
{
    public class Dancer
    {
        private delegate void PrintInfo();
        private Dictionary<string, PrintInfo> _howToDance = new Dictionary<string, PrintInfo>();
        public Dancer()
        {
            _howToDance.Add("Nothing", () => Console.Write(""));
            _howToDance.Add("HardBass", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Elbow dance!"));
            _howToDance.Add("Rock", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Head Shake dance!"));
            _howToDance.Add("Latino", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Hips dance!"));
        }
        public void Dance(Music music, ManualResetEvent manualResetEvent, ref bool IsTrackListEnded)
        {
            if (!_howToDance.ContainsKey(music.MusicType))
                LearnToDance(music.MusicType, new Models.Dance() { DanceMoveType = music.MusicType });
            while (true)
            {

                manualResetEvent.WaitOne(); 

                if (IsTrackListEnded)
                    break;

                _howToDance[music.MusicType].Invoke();
                manualResetEvent.Reset();
            }
        }
        private void LearnToDance(string musicType, Dance dance)
        {
            if (!_howToDance.ContainsKey(musicType))
                _howToDance.Add(musicType, () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   " + dance.DanceMoveType + " dance!"));
        }
    }
}

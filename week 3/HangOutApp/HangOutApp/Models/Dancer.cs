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
        private Dictionary<string, ThreadStart> _howToDance = new Dictionary<string, ThreadStart>();
        public Dancer()
        {
            _howToDance.Add("HardBass", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Elbow dance!"));
            _howToDance.Add("Rock", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Head Shake dance!"));
            _howToDance.Add("Latino", () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   Hips dance!"));
        }
        public void Dance(string musicType)
        {
            if (!_howToDance.ContainsKey(musicType))
                LearnToDance(musicType, new Models.Dance() { DanceMoveType = musicType });

            Thread thread = new Thread(_howToDance[musicType]);
            thread.Start();
        }
        public void LearnToDance(string musicType, Dance dance)
        {
            if (!_howToDance.ContainsKey(musicType))
                _howToDance.Add(musicType, () => Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "   " + dance.DanceMoveType + " dance!"));
        }
    }
}

using HangOutApp.Models;
using System;
using System.Threading;

namespace HangOutApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NightClub nightClub = new NightClub();
            nightClub.StartMultiThreadHangOut();
        }
    }
}

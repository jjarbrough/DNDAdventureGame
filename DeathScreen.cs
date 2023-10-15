using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DnDAdventureGame
{
    internal static class DeathScreen
    {
        public static void deathScreen()
        {
            Console.WriteLine(@" __     __                               _____  ______          _____   ");
            Thread.Sleep(500);
            Console.WriteLine(@" \ \   / /              /\              |  __ \|  ____|   /\   |  __ \  ");
            Thread.Sleep(500);
            Console.WriteLine(@"  \ \_/ /__  _   _     /  \   _ __ ___  | |  | | |__     /  \  | |  | | ");
            Thread.Sleep(500);
            Console.WriteLine(@"   \   / _ \| | | |   / /\ \ | '__/ _ \ | |  | |  __|   / /\ \ | |  | | ");
            Thread.Sleep(500);
            Console.WriteLine(@"    | | (_) | |_| |  / ____ \| | |  __/ | |__| | |____ / ____ \| |__| | ");
            Thread.Sleep(500);
            Console.WriteLine(@"    |_|\___/ \__,_| /_/    \_\_|  \___| |_____/|______/_/    \_\_____/  ");
            Thread.Sleep(500);
            Console.WriteLine(@"  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ");
            Thread.Sleep(500);
            Console.WriteLine(@" |______|______|______|______|______|______|______|______|______|______|");
            Thread.Sleep(15000);
            System.Environment.Exit(1);
        }
    }
}

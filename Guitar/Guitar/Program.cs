using System;
using System.Collections.Generic;
using System.Linq;

namespace Guitar
{
    class MainClass
    {
        static Stack<Melody> melodies = new Stack<Melody>();
        static Stack<Song> songs = new Stack<Song>();
        public static void Main(string[] args)
        { 
            /*
                (0) END
                (1) Add Melody
                    <GuitarString> <Frets>
                example: 1
                    e 3 2 3
                (2) Delete Last Melody
                (3) Delete All Melodies
                (4) Print Last Melody
                (5) Print All Melodies
                (6) Create Song
                (7) Delete Last Song
                (8) Delete All Songs
                (9) Print Last Song
                (10) Print All Songs
             */
            try
            {
                int command = int.Parse(Console.ReadLine());
                while (command != 0)
                {
                    switch (command)
                    {
                        case 1: AddMelody(); break;
                        case 2: DeleteLastMelody(); break;
                        case 3: DeleteAllMelodies(); break;
                        case 4: PrintLastMelody(); break;
                        case 5: PrintAllMelodies(); break;
                        case 6: CreateSong(); break;
                        case 7: DeleteLastSong(); break;
                        case 8: DeleteAllSongs(); break;
                        case 9: PrintLastSong(); break;
                        case 10: PrintAllSongs(); break;
                    }
                    command = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!\n" + ex.Message);
            }
        }

        static void AddMelody()
        { 
            string[] arguments = Console.ReadLine().Split().ToArray();
            GuitarString guitarString = GuitarString.e;
            switch (arguments[0])
            {
                case "e": guitarString = GuitarString.e; break;
                case "b": guitarString = GuitarString.e; break;
                case "g": guitarString = GuitarString.e; break;
                case "D": guitarString = GuitarString.e; break;
                case "A": guitarString = GuitarString.e; break;
                case "E": guitarString = GuitarString.e; break;
            }
            List<int> frets = arguments.Skip(1).Select(int.Parse).ToList();
            Melody melody = new Melody(guitarString, frets);
            melodies.Push(melody);
        }

        static void DeleteLastMelody() => melodies.Pop();
        static void DeleteAllMelodies() => melodies.Clear();
        static void PrintLastMelody() => Console.WriteLine(melodies.Peek());
        static void PrintAllMelodies() => Console.WriteLine(string.Join("\n", melodies));

        static void CreateSong()
        {
            Song song = new Song(melodies.ToList());
            songs.Push(song);
            melodies.Clear();
        }

        static void DeleteLastSong() => songs.Pop();
        static void DeleteAllSongs() => songs.Clear();
        static void PrintLastSong() => Console.WriteLine(songs.Peek());
        static void PrintAllSongs() => Console.WriteLine(string.Join("\n", songs));
    }
}

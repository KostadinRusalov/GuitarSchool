using System;
using System.Collections.Generic;

namespace Guitar
{
    public class Melody
    {
        private GuitarString guitarString;
        private List<int> frets;

        private const int noteCount = 12;

        public GuitarString GuitarString
        {
            get => guitarString;
            set => guitarString = value;
        }
        public List<int> Frets
        {
            get => frets;
            set => frets = value;
        }

        public List<Note> Notes => GetNotes();

        public Melody(GuitarString guitarString, List<int> frets)
        {
            GuitarString = guitarString;
            Frets = frets;
        }

        public Melody()
        {
            Frets = new List<int>();
        }

        public Melody PlayOn(GuitarString guitarString)
        {

            Melody melody = new Melody();
            melody.GuitarString = guitarString;

            List<int> frets = new List<int>();
            foreach (int fret in Frets)
            {
                int distance = (int)melody.GuitarString - ((int)GuitarString + fret);
                frets.Add(noteCount - distance);
            }

            melody.Frets = frets;
            return melody;

        }

        private List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();
            foreach (int fret in Frets)
            {
                int note = ((int)GuitarString + fret) % noteCount;
                switch (note)
                {
                    case 0:
                        notes.Add(Note.c); break;
                    case 1:
                        notes.Add(Note.cSharp); break;
                    case 2:
                        notes.Add(Note.d); break;
                    case 3:
                        notes.Add(Note.dSharp); break;
                    case 4:
                        notes.Add(Note.e); break;
                    case 5:
                        notes.Add(Note.f); break;
                    case 6:
                        notes.Add(Note.fSharp); break;
                    case 7:
                        notes.Add(Note.g); break;
                    case 8:
                        notes.Add(Note.gSharp); break;
                    case 9:
                        notes.Add(Note.a); break;
                    case 10:
                        notes.Add(Note.aSharp); break;
                    case 11:
                        notes.Add(Note.b); break;
                }
            }
            return notes;
        }

        public override string ToString()
        {
            string description = $"{GuitarString}: ";
            foreach (int fret in Frets)
            {
                description += $"{fret}-";
            }
            return description;
        }
    }
}

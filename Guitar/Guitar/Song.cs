using System;
using System.Collections.Generic;

namespace Guitar
{
    public class Song
    {
        private List<Melody> melodies;

        public List<Melody> Melodies
        {
            get => melodies;
            set => melodies = value;
        }

        public List<Note> Notes => GetNotes();

        public Song()
        {
            Melodies = new List<Melody>();
        }

        public Song(List<Melody> melodies)
        {
            Melodies = melodies;
        }

        public List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();
            foreach (Melody melody in Melodies)
            {
                foreach (Note note in melody.Notes)
                {
                    notes.Add(note);
                }
            }
            return notes;
        }

        public override string ToString()
        {
            return string.Join(" ", Notes);
        }
    }
}

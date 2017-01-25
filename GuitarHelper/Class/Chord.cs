using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toub.Sound.Midi;
namespace GuitarHelper.Class
{
    class Chord
    {
        public ChordRecipe recipe;
        public Note rootNote;

        public Chord(ChordRecipe _recipe, Note _rootNote)
        {
            this.recipe = _recipe;
            this.rootNote = new Note(_rootNote);
        }
        public void play()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                MidiPlayer.OpenMidi();
                MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.JazzElectricGuitar));

                for (int i = 0; i < recipe.intervals.Count(); ++i)
                {

                    MidiPlayer.Play(new NoteOn(3, 1, (rootNote + recipe.intervals.ElementAt(i)).noteToPlay, 100));
                    System.Threading.Thread.Sleep(30);
                }
                System.Threading.Thread.Sleep(2790);
                MidiPlayer.CloseMidi();
            }).Start();
        }

        public List<Note> getNotes()
        {
            List<Note> result = new List<Note>();
            foreach (int i in this.recipe.intervals)
            {
                result.Add(this.rootNote + i);
            }
            return result;
        }
    }
}

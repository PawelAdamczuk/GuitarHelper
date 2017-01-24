using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toub.Sound.Midi;
namespace GuitarHelper.Class
{
    class Chord
    {
        ChordRecipe recipe;
        Note rootNote;
        void play()
        {
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.JazzElectricGuitar));
            MidiPlayer.OpenMidi();
            for (int i = 0; i < recipe.intervals.Count(); ++i)
            {
                
                MidiPlayer.Play(new NoteOn(3, 1, (rootNote + recipe.intervals.ElementAt(i)).noteToPlay, 100));
                // System.Threading.Thread.Sleep(3000);
            }
            System.Threading.Thread.Sleep(2790);
            MidiPlayer.CloseMidi();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class KeyboardInterface : InstrumentInterface
    {
        public Note currentSelection;
        public MainInterface mainInterface;
        public Note[] notes;
        public int[] state;

        public KeyboardInterface()
        {
            this.notes = new Note[72];
            for (int i = 0; i < 72; i++)
            {
                this.notes[i] = new Note((i / 12) + 2, i % 12);
            }
            this.state = new int[72];
        }
        public void changeSelection( int selection)
        {

        }
        public void displayChord(Chord chord)
        {
            this.state = new int[72];
            int rootKey = 12 * chord.rootNote.absolutePitch + chord.rootNote.chromaticPitch - 24;

            foreach (int i in chord.recipe.intervals)
            {
                if (rootKey + i < 72)
                {
                    this.state[rootKey + i] = 1; 
                }
            }
        }

        public Note getCurrentSelection()
        {
            throw new NotImplementedException();
        }

        public void reDraw()
        {
            throw new NotImplementedException();
        }

        public void updateSelection()
        {
            throw new NotImplementedException();
        }
    }
}

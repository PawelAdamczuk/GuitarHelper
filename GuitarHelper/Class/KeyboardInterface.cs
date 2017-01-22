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

        public void changeSelection( int selection)
        {

        }
        public void displayChord(Chord chord)
        {
            throw new NotImplementedException();
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

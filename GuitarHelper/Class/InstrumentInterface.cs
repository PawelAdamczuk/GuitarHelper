using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    interface InstrumentInterface
    {
        void displayChord(Chord chord);
        Note getCurrentSelection();
        void reDraw();
        void updateSelection();
    }
}

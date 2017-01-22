using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class MainInterface
    {
        public ChordRecipe chordRecipe;
        public Note rootNote;
        public List<InstrumentInterface> interfaces;

        void updateInterfaces()
        {

        }
        void changeRootNote(Note note)
        {
            this.rootNote = note;
        }
        void changeChordRecipe(ChordRecipe recipe)
        {
            this.chordRecipe = recipe;
        }
    }
}

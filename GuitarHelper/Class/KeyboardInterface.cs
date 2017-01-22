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
        public List<Note> notes;


        public KeyboardInterface(Note currentSelection)
        {
            int KeyBordLenght = 77;
            this.currentSelection = currentSelection;
            for ( int i = 1; i <= KeyBordLenght; ++i) 
            {
                Note newNote;
                if (currentSelection.chromaticPitch + i%12 == 12)
                {
                    newNote = new Note(0, currentSelection.absolutePitch + i % 12);
                }
                else
                {
                    newNote = new Note(currentSelection.chromaticPitch + i % 12, currentSelection.absolutePitch);
                }
                notes.Add(newNote);
            }
        }

        public void setMainInterface(MainInterface mainInterface)
        {
            this.mainInterface = mainInterface;
        }
        public void changeSelection( int selection)
        {
            Note newNote;
            if (currentSelection.chromaticPitch + selection == 12)
            {
                newNote = new Note(0, currentSelection.absolutePitch + 1);
            }
            else
            {
                newNote = new Note(currentSelection.chromaticPitch + 1, currentSelection.absolutePitch);
            }
            currentSelection = newNote;
        }


        //Metody z Interface

        public void changeSelection(Note currentSelection)
        {
            this.currentSelection = currentSelection;
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

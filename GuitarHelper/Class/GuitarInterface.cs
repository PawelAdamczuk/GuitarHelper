using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class GuitarInterface: InstrumentInterface
    {
        Tuple<int, int> currentMouseover;
        MainInterface mainInterface;
        public Fretboard chosenBase;
        public Note[,] grid;
        public int[,] gridState;
        Form1 parent;

        public GuitarInterface(Fretboard _fretboard, Form1 _parent)
        {
            this.parent = _parent;
            this.chosenBase = _fretboard;
            this.buildGrid();
        }
        public GuitarInterface(Form1 _parent)
        {
            this.parent = _parent;
            this.chosenBase = Database.getInstance().getFretboard("standard");
            this.buildGrid();
        }
        //Metody z klasy
        public void buildGrid()
        {
            this.grid = new Note[this.chosenBase.strings.Count, 12];

            for (int i = 0; i < this.chosenBase.strings.Count; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    this.grid[i, j] = new Note(this.chosenBase.strings[i] + (1+ j));
                }
            }
            this.gridState = new int[this.chosenBase.strings.Count, 12];
        }
        public void changeMouseover(Tuple<int,int> pair)
        {
            this.parent.rootNote = new Note(this.grid[pair.Item1, pair.Item2]);
        }
        //Metody z interface
        public void displayChord(Chord chord)
        {
            this.gridState = new int[this.chosenBase.strings.Count, 12];
            List<Note> notes = chord.getNotes();

            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    foreach (Note n in notes)
                    {
                        if (this.grid[i, j].chromaticPitch == n.chromaticPitch)
                        {
                            this.gridState[i,j] = 1;
                        }
                    }
                }
            }
        }

        Note InstrumentInterface.getCurrentSelection()
        {
            throw new NotImplementedException();
        }

        void InstrumentInterface.reDraw()
        {
            throw new NotImplementedException();
        }

        void InstrumentInterface.updateSelection()
        {
            throw new NotImplementedException();
        }
    }
}

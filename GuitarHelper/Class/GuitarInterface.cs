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
        Fretboard chosenBase;
        Note[,] grid;
        int[][] gridState;
        Form1 parent;

        public GuitarInterface(Fretboard _fretboard, Form1 _parent)
        {
            this.parent = _parent;
            this.chosenBase = _fretboard;
            this.grid = new Note[this.chosenBase.strings.Count, 12];

            for (int i = 0; i < this.chosenBase.strings.Count; i++)
            {
                this.grid[i, 0] = new Note(this.chosenBase.strings[i]);
            }
        }
        public GuitarInterface(Form1 _parent)
        {

            this.parent = _parent;
            this.chosenBase = Database.getInstance().getFretboard("standard");
            this.grid = new Note[this.chosenBase.strings.Count, 12];

            for (int i = 0; i < this.chosenBase.strings.Count; i++)
            {
                this.grid[i, 0] = new Note(this.chosenBase.strings[i]);
            }
        }
        //Metody z klasy
        private void buildGrid()
        {

        }
        public void changeMouseover(Tuple<int,int> pair)
        {

        }
        //Metody z interface
        void InstrumentInterface.displayChord(Chord chord)
        {
            throw new NotImplementedException();
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

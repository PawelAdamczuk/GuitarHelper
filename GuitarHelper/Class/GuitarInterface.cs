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
        Note[][] grid;
        int[][] gridState;

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

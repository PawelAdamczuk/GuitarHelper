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
        //Lista list - gdyż potrzebujemy dynamicznego alokowania pamięci ( fretBoard może się zmieniać! ) 
        List<List<Note>> grid;
        //Note[][] grid;
        int[][] gridState;

        public GuitarInterface(Fretboard fretboard, MainInterface mainInterface)
        {
            this.chosenBase = fretboard;
            this.mainInterface = mainInterface;
            grid = new List<List<Note>>();
            setFretboard(this.chosenBase);
        }
        void setFretboard(Fretboard board)
        {
            //Czyścimy stary fretBoard
            try {

                foreach (List<Note> row in grid)
                {
                    row.Clear();
                }

                grid.Clear();

            } catch(Exception ex) { }
          
            this.chosenBase = board;
            int boardLenght = 13;
            for ( int j = 0; j < board.strings.Count; ++j )
            {
                //Przypisujemy wartość otwartej strunie ( a więc index 0 ) 
                grid[j][0] = board.strings[j];
                

                //Przypisujemy gryfowi dziwięki
                for ( int i = 1; i < boardLenght; ++i)
                {
                    
                }
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

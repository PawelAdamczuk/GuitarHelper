using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class Fretboard
    {
        public List<Note> strings;

        public Fretboard()
        {
            strings = new List<Note>();
        }

        public Fretboard(List<Note> strings)
        {
            this.strings = strings;
        }
        public void addNode(Note note)
        {
            this.strings.Add(note);
        }
        
    }
}

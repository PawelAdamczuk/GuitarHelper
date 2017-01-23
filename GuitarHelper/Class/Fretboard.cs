using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    [Serializable]
    class Fretboard
    {
        public List<Note> strings;
        public string name;

        public Fretboard(List<Note> _strings, string _name)
        {
            this.strings = _strings;
            this.name = _name;
        }
    }
}

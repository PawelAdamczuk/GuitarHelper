using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{

    [Serializable]
    public class ChordRecipe
    {
        public List<int> intervals;
        public string name;

        public ChordRecipe(List<int> _intervals, string _name)
        {
            this.intervals = _intervals;
            this.name = _name;
        }
    }
}

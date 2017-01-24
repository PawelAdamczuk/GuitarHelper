using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace GuitarHelper.Class
{
    [XmlType("ChordRecipe")]
    public class ChordRecipe
    {
        [XmlArray("intervalsArray")]
        [XmlArrayItem("interval")]
        public List<int> intervals;
        [XmlElement("name")]
        public string name;

        public ChordRecipe(List<int> _intervals, string _name)
        {
            this.intervals = _intervals;
            this.name = _name;
        }
        public ChordRecipe()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace GuitarHelper.Class
{
    [Serializable]
    [XmlRoot("Fretboard")]
    [XmlInclude(typeof(Note))]
    public class Fretboard
    {
        [XmlArray("NoteArray")]
        [XmlArrayItem("NoteObjekt")]
        public List<Note> strings;

        [XmlElement("FretboardName")]
        public string name;

        public Fretboard(List<Note> _strings, string _name)
        {
            this.strings = _strings;
            this.name = _name;
        }
        public Fretboard()
        {

        }
    }
}

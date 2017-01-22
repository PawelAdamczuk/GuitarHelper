using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class NoteBank
    {
        private List<string> notesBank;
        public NoteBank()
        {
            notesBank = new List<string>();

            notesBank.Add("C");
            notesBank.Add("Cis");
            notesBank.Add("D");
            notesBank.Add("Dis");
            notesBank.Add("G");
            notesBank.Add("Gis");
            notesBank.Add("D");
            notesBank.Add("Dis");
            notesBank.Add("E");
            notesBank.Add("F");
            notesBank.Add("Fis");
            notesBank.Add("G");
            notesBank.Add("Gis");
            notesBank.Add("H");
        }
        public int getValue(string note)
        {
            return notesBank.IndexOf(note);
        }
        public string getNote(int index)
        {
            return notesBank.ElementAt(index);
        }
    }
}

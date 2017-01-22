using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class Note
    {
        public  int chromaticPitch;
        //Typ enum by łatwiej można rozpoznawać i przyspisywać dzwięki
        public NoteValue humanReadable;
        public  int absolutePitch;
        public Note(NoteValue value)
        {
            this.humanReadable = value;
        }
        void play()
        {

        }
    }
}

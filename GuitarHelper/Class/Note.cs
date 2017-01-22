using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    class Note
    {
        public int chromaticPitch;
        //Typ enum by łatwiej można rozpoznawać i przyspisywać dzwięki
        public string humanReadable;
        public int absolutePitch;
        public Note (int chromatic, int absolute)
        {
            this.chromaticPitch = chromatic;
            this.absolutePitch = absolute;
            this.humanReadable = new NoteBank().getNote(chromatic);
        }
        void play()
        {

        }
    }
}

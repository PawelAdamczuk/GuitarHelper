using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    [Serializable]
    public class Note
    {
        public int chromaticPitch;
        public string humanReadable;
        public int absolutePitch;

        public Note(Note another)
        {
            this.absolutePitch = another.absolutePitch;
            this.chromaticPitch = another.chromaticPitch;
        }
        public Note(int _absolutePitch, int _chromaticPitch)
        {
            this.absolutePitch = _absolutePitch;
            this.chromaticPitch = _chromaticPitch;
            string[] hr = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            this.humanReadable = hr[this.chromaticPitch];
        }



        public static Note operator+ (Note obj, int a)
        {
            Note newObj = new Note(obj.absolutePitch, obj.chromaticPitch);
            newObj.absolutePitch += (a / 12);
            newObj.chromaticPitch += (a % 12);
            if (newObj.chromaticPitch >11)
            {
                newObj.absolutePitch++;
                newObj.chromaticPitch = newObj.chromaticPitch % 12;
            }
            return newObj;
        }

        void play()
        {

        }
    }
}

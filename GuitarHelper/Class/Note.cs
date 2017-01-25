using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toub.Sound.Midi;
using System.Xml.Serialization;
using System.Threading;

namespace GuitarHelper.Class
{
    [XmlType("Note")]
    public class Note
    {
        [XmlElement("chromaticPitch")]
        public int chromaticPitch;
        [XmlElement("humanReadable")]
        public string humanReadable;
        [XmlElement("absolutePitch")]
        public int absolutePitch;
        [XmlElement("noteToPlay")]
        public string noteToPlay;

        public Note(Note another)
        {
            this.absolutePitch = another.absolutePitch;
            this.chromaticPitch = another.chromaticPitch;
            this.noteToPlay = String.Concat(this.humanReadable, this.absolutePitch);
        }
        public Note(int _absolutePitch, int _chromaticPitch)
        {
            this.absolutePitch = _absolutePitch;
            this.chromaticPitch = _chromaticPitch;
            string[] hr = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            this.humanReadable = hr[this.chromaticPitch];
            this.noteToPlay = String.Concat(this.humanReadable, this.absolutePitch);
        }
        public Note()
        {

        }


        public static Note operator +(Note obj, int a)
        {

            int _absolutePitch = obj.absolutePitch + (a / 12);
            int _chromaticPitch = obj.chromaticPitch + (a % 12);
            if (_chromaticPitch > 11)
            {
                _absolutePitch++;
                _chromaticPitch = _chromaticPitch % 12;
            }

            return new Note(_absolutePitch, _chromaticPitch);
        }

        public void play()
        {

            var th = new Thread(playMidi);
            th.Start();

        }
        private void playMidi()
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.JazzElectricGuitar));
            MidiPlayer.Play(new NoteOn(0, 1, this.noteToPlay, 100));
            System.Threading.Thread.Sleep(2790);
            MidiPlayer.CloseMidi();
        }
    }
}

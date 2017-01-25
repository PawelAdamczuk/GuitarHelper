using GuitarHelper.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHelper
{
    public partial class Form_fretboard_input : Form
    {
        private ComboBox[] octaveBoxes;
        private ComboBox[] noteBoxes;
        public int stringCount = 1;
        Form1 parent;
        public Form_fretboard_input(Form1 _parent)
        {
            InitializeComponent();
            this.parent = _parent;

            this.octaveBoxes = new ComboBox[] { this.comboBox1, this.comboBox2, this.comboBox3, this.comboBox4, this.comboBox5, this.comboBox6, this.comboBox7, this.comboBox8};

            foreach (ComboBox b in octaveBoxes)
            {
                b.Items.Add(" ");
                for (int i = 0; i < 6; i++)
                {
                    b.Items.Add(i);
                }
                b.SelectedIndex = 0;
            }

            this.noteBoxes = new ComboBox[] { this.comboBox9, this.comboBox10, this.comboBox11, this.comboBox12, this.comboBox13, this.comboBox14, this.comboBox15, this.comboBox16};

            string[] notes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

            
            foreach (ComboBox b in noteBoxes)
            {
                b.Items.Add("<none>");
                for (int i = 0; i < 12; i++)
                {
                    b.Items.Add(notes[i]);
                }
                b.SelectedIndex = 0;
            }

            this.stringCount = 4;
            this.refreshBoxes();

        }

        private void refreshBoxes()
        {
            if(this.stringCount == 1)
            {
                this.button_decrement.Enabled = false;
            }
            else
            {
                this.button_decrement.Enabled = true;
            }

            if(this.stringCount == 8)
            {
                this.button_increment.Enabled = false;
            }
            else
            {
                this.button_increment.Enabled = true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (i < this.stringCount)
                {
                    this.octaveBoxes[i].Enabled = true;
                    this.noteBoxes[i].Enabled = true;
                }
                else
                {
                    this.octaveBoxes[i].Enabled = false;
                    this.noteBoxes[i].Enabled = false;
                }
            }
        }

        private void button_decrement_Click(object sender, EventArgs e)
        {
            this.stringCount--;
            this.refreshBoxes();
        }

        private void button_increment_Click(object sender, EventArgs e)
        {
            this.stringCount++;
            this.refreshBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Note> strings = new List<Note>();
            for (int i = 0; i < this.stringCount; i++)
            {
                if (this.octaveBoxes[i].SelectedIndex == 0 || this.noteBoxes[i].SelectedIndex == 0)
                    break;
                Note note = new Note(this.octaveBoxes[i].SelectedIndex - 1, this.noteBoxes[i].SelectedIndex - 1);
                strings.Add(note);
            }

            if (strings.Count < 1 || this.textBox1.Text.Equals(""))
            {
                MessageBox.Show("Invalid data!");
                return;
            }

            Fretboard fb = new Fretboard(strings, this.textBox1.Text);
            this.parent.Database.fretboards.Add(fb);
            this.parent.UpdateBoxes();
            this.Close();
        }
    }
}

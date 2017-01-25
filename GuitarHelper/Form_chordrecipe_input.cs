using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuitarHelper.Class;
namespace GuitarHelper
{
    public partial class Form_chordrecipe_input : Form
    {
        Form1 parent;
        public Form_chordrecipe_input(Form1 _parent)
        {
            InitializeComponent();
            this.parent = _parent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int convertIntervalToInt(string name)
        {
            if (name.Equals("Perfect unison")) return 1;
            if (name.Equals("Minor second")) return 2;
            if (name.Equals("Major second")) return 3;
            if (name.Equals("Minor third")) return 4;
            if (name.Equals(" Major third")) return 5;
            if (name.Equals("Perfect fourth")) return 6;
            if (name.Equals("Tritone")) return 7;
            if (name.Equals("Perfect fifth")) return 8;
            if (name.Equals("Minor sixth")) return 9;
            if (name.Equals("Major sixth")) return 10;
            if (name.Equals("Minor seventh")) return 11;
            if (name.Equals("Major seventh")) return 12;
            if (name.Equals("Perfect octave")) return 13;
            return 0;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameChordBox.Text))
            {
                MessageBox.Show("Enter name of chord!");
            }else
            {
                List<int> intervals = new List<int>();
                foreach (string s in checkedListBox1.CheckedItems)
                {
                    intervals.Add(convertIntervalToInt(s));
                }
                if (intervals.Count == 0)
                {
                    MessageBox.Show("Select intervals!");
                }
                else
                {
                    string name = nameChordBox.Text;
                    ChordRecipe chord = new ChordRecipe(intervals, name);
                    this.parent.Database.chordRecipes.Add(chord);
                    MessageBox.Show("Your chord is add to database");
                    nameChordBox.Clear();
                    checkedListBox1.ClearSelected();
                    parent.Refresh();
                }
            }
        }
    }
}

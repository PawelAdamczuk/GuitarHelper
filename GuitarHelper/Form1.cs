using GuitarHelper.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHelper
{
    public partial class Form1 : Form
    {
        private MainDatabase database;

        GuitarInterface guitar;
        KeyboardInterface piano;

        public ChordRecipe chordRecipe;
        public Note rootNote;

        internal MainDatabase Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            IFormatter formatter = new BinaryFormatter();
            try
            {
                Stream stream = new FileStream("db.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                this.database = (MainDatabase)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException e)
            {
                this.database = new MainDatabase();
                MessageBox.Show(e.Message + "\nCreating fresh database.");
            }

            this.guitar = new GuitarInterface(this.database.fretboards[0], this);
            //populate the comboboxes
            this.UpdateBoxes();

            this.rootNote = new Note(this.guitar.grid[5, 5]);
            this.chordRecipe = this.database.chordRecipes[0];

            Chord chord = new Chord(this.chordRecipe, this.rootNote);

            Note test = new Note(1, 10);
            Note test2 = test + 1;

            (this.guitar as InstrumentInterface).displayChord(chord);
            this.piano = new KeyboardInterface();

            

        }

        public void UpdateBoxes()
        {
            this.comboBox1.Items.Clear();
            foreach (Fretboard fb in this.database.fretboards)
            {
                this.comboBox1.Items.Add(fb.name);
            }

            this.comboBox2.Items.Clear();
            foreach (ChordRecipe cr in this.database.chordRecipes)
            {
                this.comboBox2.Items.Add(cr.name);
            }

            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;

            this.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Chord chord = new Chord(this.chordRecipe, this.rootNote);

            (this.guitar as InstrumentInterface).displayChord(chord);
            this.piano.displayChord(chord);

            int startingPosX = 70;
            int startingPosY = 100;

            int fretCount = 12;
            int stringCount = this.guitar.chosenBase.strings.Count;

            Bitmap background = new Bitmap("..\\..\\res\\background.png");
            Bitmap strings = new Bitmap("..\\..\\res\\string.png");
            Bitmap background_top = new Bitmap("..\\..\\res\\background_top.png");
            Bitmap background_bottom = new Bitmap("..\\..\\res\\background_bottom.png");
            Bitmap background_left_coverup = new Bitmap("..\\..\\res\\background_left_coverup.png");
            Bitmap background_right_coverup = new Bitmap("..\\..\\res\\background_right_coverup.png");
            Bitmap nut = new Bitmap("..\\..\\res\\nut.png");

            Bitmap whiteKey = new Bitmap("..\\..\\res\\white_key.png");
            Bitmap blackKey = new Bitmap("..\\..\\res\\black_key.png");
            Bitmap whiteKeyHighlight = new Bitmap("..\\..\\res\\white_key_highlight.png");
            Bitmap blackKeyHighlight = new Bitmap("..\\..\\res\\black_key_highlight.png");


            //background
            for (int i = 0; i < fretCount + 2; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    e.Graphics.DrawImage(background, startingPosX + i * 60, startingPosY + j * 30, 60, 30);
                }
            }

            
            //strings
            for (int i = 0; i < fretCount + 2; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    e.Graphics.DrawImage(strings, startingPosX + i * 60, startingPosY + j * 30, 60, 30);
                }
            }

            //the nut
            for (int i = 0; i < stringCount; i++)
            {
                e.Graphics.DrawImage(nut, startingPosX, startingPosY + i * 30, 60, 30);
            }

            //top background fadeout
            for (int i = 0; i < fretCount + 2; i++)
            {
                e.Graphics.DrawImage(background_top, startingPosX + i * 60, startingPosY - 16, 60, 30);
            }

            //bottom background fadeout
            for (int i = 0; i < fretCount + 2; i++)
            {
                e.Graphics.DrawImage(background_bottom, startingPosX + i * 60, startingPosY - 14 + stringCount * 30, 60, 30);
            }

            //left fade coverup
            for (int i = 0; i < stringCount+2; i++)
            {
                e.Graphics.DrawImage(background_left_coverup, startingPosX, startingPosY - 30 + i * 30, 60, 30);
            }

            //right fade coverup
            for (int i = 0; i < stringCount + 2; i++)
            {
                e.Graphics.DrawImage(background_right_coverup, startingPosX + (fretCount + 1) * 60, startingPosY - 30 + i * 30, 60, 30);
            }

            //open string sounds
            for (int i = 0; i < stringCount; i++)
            {
                Bitmap note = new Bitmap("..\\..\\res\\notes\\note_" + this.guitar.chosenBase.strings[i].chromaticPitch + ".png");
                e.Graphics.DrawImage(note, startingPosX, startingPosY + i * 30, 60, 30);
            }

            //note marks
            for (int i = 0; i < fretCount; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    if (this.guitar.gridState[j,i] == 1)
                    {
                        Bitmap note = new Bitmap("..\\..\\res\\notes\\note_" + this.guitar.grid[j,i].chromaticPitch + ".png");
                        e.Graphics.DrawImage(note, startingPosX + (i+1) * 60, startingPosY + j * 30, 60, 30);
                    }
                    
                }
            }


            int startingPosXKeyboard = 70;
            int startingPosYKeyboard = 400;

            //6 octaves
            int keyNumber = 0;
            int verticalIterator = 0;
            while (keyNumber < 72)
            {
                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //C
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //C
                }                
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //D
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //D
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //E
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //E 
                }
                verticalIterator += 20;
                keyNumber += 1;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //F
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //F 
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //G
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //G 
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                    e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //A 
                }
                else
                {
                e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //A
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //B
                }
                else
                {
                    e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //B 
                }
                verticalIterator += 20;
                keyNumber += 1;
            }

            keyNumber = 1;
            verticalIterator = 15;
            while (keyNumber < 72)
            {
                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //C#
                }
                else
                {
                    e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //C# 
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                    e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //D# 
                }
                else
                {
                e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //D#
                }
                verticalIterator += 40;
                keyNumber += 3;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //F#
                }
                else
                {
                    e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //F# 
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //G#
                }
                else
                {
                    e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //G# 
                }
                verticalIterator += 20;
                keyNumber += 2;

                if (this.piano.state[keyNumber] == 0)
                {
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //A#
                }
                else
                {
                    e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //A# 
                }
                verticalIterator += 40;
                keyNumber += 3;
            }
            //e.Graphics.DrawImage(bitmap, 50, 100, 60, 30);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("db.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.database);
            stream.Close();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Form1_MouseDoubleClick(sender, e);
                return;
            }


            int startingPosX = 70 + 60;
            int startingPosY = 100;

            //guitar interface
            if(e.X > startingPosX && e.X < (startingPosX + 12*60) && e.Y > startingPosY && e.Y < (startingPosY + this.guitar.chosenBase.strings.Count * 30))
            {
                int gridX = (e.X-startingPosX) / 60;
                int gridY = (e.Y-startingPosY) / 30;

                this.rootNote = new Note(this.guitar.grid[gridY, gridX]);                
            }

            //keyboard interface [Wokulsky]
            int startingPosXKey = 70;
            int startingPosYKey = 400;
            int endingPosX = 42 * 20 + startingPosXKey;
            int endingPosY = startingPosYKey + 100;
            Note note;
            if (e.X > startingPosXKey && e.X < endingPosX && e.Y > startingPosYKey && e.Y < endingPosY)
            {
                int octavNumber = (int)((e.X - startingPosXKey) / (140));
                if (e.X > startingPosXKey + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 20))//C lub Cis
                {
                    if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X >= startingPosXKey + (140 * octavNumber) + 15 && e.X <= startingPosXKey + (140 * octavNumber) + 35)
                        note = new Note(octavNumber + 2, 1);
                    else note = new Note(octavNumber + 2, 0);
                }
                else
                {
                    if (e.X > startingPosXKey + 20 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 40))//D lub Dis lub Cis
                    {
                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                        {
                            if (e.X < startingPosXKey + 20 + (140 * octavNumber) + 5)//Cis
                            {
                                note = new Note(octavNumber + 2, 1);
                            }
                            else
                            {
                                if (e.X >= startingPosXKey + 20 + (140 * octavNumber) + 15)//Dis
                                {
                                    note = new Note(octavNumber + 2, 3);
                                }
                                else//D
                                {
                                    note = new Note(octavNumber + 2, 2);
                                }
                            }
                        }
                        else//D
                        {
                            note = new Note(octavNumber + 2, 2);
                        }

                    }
                    else
                    {
                        if (e.X > startingPosXKey + 40 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 60))//Dis lub E
                        {
                            if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X < startingPosXKey + 45 + (140 * octavNumber)) //Dis
                            {
                                note = new Class.Note(octavNumber + 2, 3);
                            }
                            else//E
                            {
                                note = new Note(octavNumber + 2, 4);
                            }
                        }
                        else
                        {
                            if (e.X > startingPosXKey + 60 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 80))//F lub Fis
                            {
                                if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X > startingPosXKey + 75 + (140 * octavNumber)) //Fis
                                {
                                    note = new Class.Note(octavNumber + 2, 6);
                                }
                                else//F
                                {
                                    note = new Note(octavNumber + 2, 5);
                                }
                            }
                            else
                            {
                                if (e.X > startingPosXKey + 80 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 100))//Fis lub G lub Gis
                                {
                                    if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                                    {
                                        if (e.X < startingPosXKey + 80 + (140 * octavNumber) + 5)//Fis
                                        {
                                            note = new Note(octavNumber + 2, 6);
                                        }
                                        else
                                        {
                                            if (e.X >= startingPosXKey + 80 + (140 * octavNumber) + 15)//Gis
                                            {
                                                note = new Note(octavNumber + 2, 8);
                                            }
                                            else//G
                                            {
                                                note = new Note(octavNumber + 2, 7);
                                            }
                                        }
                                    }
                                    else//G
                                    {
                                        note = new Note(octavNumber + 2, 7);
                                    }

                                }
                                else
                                {
                                    if (e.X > startingPosXKey + 100 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 120))//D lub Dis lub Cis
                                    {
                                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                                        {
                                            if (e.X < startingPosXKey + 100 + (140 * octavNumber) + 5)//Gis
                                            {
                                                note = new Note(octavNumber + 2, 8);
                                            }
                                            else
                                            {
                                                if (e.X >= startingPosXKey + 100 + (140 * octavNumber) + 15)//Ais
                                                {
                                                    note = new Note(octavNumber + 2, 10);
                                                }
                                                else//A
                                                {
                                                    note = new Note(octavNumber + 2, 9);
                                                }
                                            }
                                        }
                                        else//A
                                        {
                                            note = new Note(octavNumber + 2, 9);
                                        }

                                    }
                                    else
                                    {
                                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X < startingPosXKey + 120 + (140 * octavNumber) + 5)
                                        {
                                            note = new Note(octavNumber + 2, 10);
                                        }
                                        else
                                        {
                                            note = new Note(octavNumber + 2, 11);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.rootNote = new Note(note);
                //MessageBox.Show(note.humanReadable + " Oktawa: " + octavNumber + " (" + e.X + "," + e.Y + ")\n");
            }
            this.Refresh();

            this.label3.Text = this.rootNote.humanReadable;
            this.label4.Text = this.chordRecipe.name;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int startingPosX = 70 + 60;
            int startingPosY = 100;

            //guitar interface
            if (e.X > startingPosX && e.X < (startingPosX + 12 * 60) && e.Y > startingPosY && e.Y < (startingPosY + this.guitar.chosenBase.strings.Count * 30))
            {
                int gridX = (e.X - startingPosX) / 60;
                int gridY = (e.Y - startingPosY) / 30;

                this.rootNote = new Note(this.guitar.grid[gridY, gridX]);

                Chord chord = new Chord(this.chordRecipe, this.rootNote);

                chord.play();
            }

            //keyboard interface [Wokulsky]
            int startingPosXKey = 70;
            int startingPosYKey = 400;
            int endingPosX = 42 * 20 + startingPosXKey;
            int endingPosY = startingPosYKey + 100;
            Note note;
            if (e.X > startingPosXKey && e.X < endingPosX && e.Y > startingPosYKey && e.Y < endingPosY)
            {
                int octavNumber = (int)((e.X - startingPosXKey) / (140));
                if (e.X > startingPosXKey + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 20))//C lub Cis
                {
                    if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X >= startingPosXKey + (140 * octavNumber) + 15 && e.X <= startingPosXKey + (140 * octavNumber) + 35)
                        note = new Note(octavNumber + 2, 1);
                    else note = new Note(octavNumber + 2, 0);
                }
                else
                {
                    if (e.X > startingPosXKey + 20 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 40))//D lub Dis lub Cis
                    {
                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                        {
                            if (e.X < startingPosXKey + 20 + (140 * octavNumber) + 5)//Cis
                            {
                                note = new Note(octavNumber + 2, 1);
                            }
                            else
                            {
                                if (e.X >= startingPosXKey + 20 + (140 * octavNumber) + 15)//Dis
                                {
                                    note = new Note(octavNumber + 2, 3);
                                }
                                else//D
                                {
                                    note = new Note(octavNumber + 2, 2);
                                }
                            }
                        }
                        else//D
                        {
                            note = new Note(octavNumber + 2, 2);
                        }

                    }
                    else
                    {
                        if (e.X > startingPosXKey + 40 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 60))//Dis lub E
                        {
                            if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X < startingPosXKey + 45 + (140 * octavNumber)) //Dis
                            {
                                note = new Class.Note(octavNumber + 2, 3);
                            }
                            else//E
                            {
                                note = new Note(octavNumber + 2, 4);
                            }
                        }
                        else
                        {
                            if (e.X > startingPosXKey + 60 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 80))//F lub Fis
                            {
                                if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X > startingPosXKey + 75 + (140 * octavNumber)) //Fis
                                {
                                    note = new Class.Note(octavNumber + 2, 6);
                                }
                                else//F
                                {
                                    note = new Note(octavNumber + 2, 5);
                                }
                            }
                            else
                            {
                                if (e.X > startingPosXKey + 80 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 100))//Fis lub G lub Gis
                                {
                                    if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                                    {
                                        if (e.X < startingPosXKey + 80 + (140 * octavNumber) + 5)//Fis
                                        {
                                            note = new Note(octavNumber + 2, 6);
                                        }
                                        else
                                        {
                                            if (e.X >= startingPosXKey + 80 + (140 * octavNumber) + 15)//Gis
                                            {
                                                note = new Note(octavNumber + 2, 8);
                                            }
                                            else//G
                                            {
                                                note = new Note(octavNumber + 2, 7);
                                            }
                                        }
                                    }
                                    else//G
                                    {
                                        note = new Note(octavNumber + 2, 7);
                                    }

                                }
                                else
                                {
                                    if (e.X > startingPosXKey + 100 + (140 * octavNumber) && e.X < (startingPosXKey + (140 * octavNumber) + 120))//D lub Dis lub Cis
                                    {
                                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60)//Czarna strefa
                                        {
                                            if (e.X < startingPosXKey + 100 + (140 * octavNumber) + 5)//Gis
                                            {
                                                note = new Note(octavNumber + 2, 8);
                                            }
                                            else
                                            {
                                                if (e.X >= startingPosXKey + 100 + (140 * octavNumber) + 15)//Ais
                                                {
                                                    note = new Note(octavNumber + 2, 10);
                                                }
                                                else//A
                                                {
                                                    note = new Note(octavNumber + 2, 9);
                                                }
                                            }
                                        }
                                        else//A
                                        {
                                            note = new Note(octavNumber + 2, 9);
                                        }
            
        }
                                    else
                                    {
                                        if (e.Y > startingPosYKey && e.Y < startingPosYKey + 60 && e.X < startingPosXKey + 120 + (140 * octavNumber) + 5)
                                        {
                                            note = new Note(octavNumber + 2, 10);
                                        }
                                        else
                                        {
                                            note = new Note(octavNumber + 2, 11);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //MessageBox.Show(note.humanReadable+ " Oktawa: " + octavNumber+ " ("+e.X+"," + e.Y + ")\n");
                note.play();
            }
        }

        private void button_add_fretboard_Click(object sender, EventArgs e)
        {
            Form_fretboard_input fi = new Form_fretboard_input(this);
            fi.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.guitar.chosenBase = this.database.fretboards[this.comboBox1.SelectedIndex];
            this.guitar.buildGrid();
            this.Refresh();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.chordRecipe = this.database.chordRecipes[this.comboBox2.SelectedIndex];
            this.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_chordrecipe_input chordWindow = new Form_chordrecipe_input(this);
            chordWindow.ShowDialog();
            comboBox1.Refresh();
            comboBox2.Refresh();
        }
    }
}

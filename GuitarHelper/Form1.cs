﻿using GuitarHelper.Class;
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
        //MainDatabase database;

        InstrumentInterface guitar;
        InstrumentInterface piano;

        public ChordRecipe chordRecipe;
        public Note rootNote;

        public Form1()
        {
            InitializeComponent();

            this.guitar = new GuitarInterface(this);
            this.piano = new KeyboardInterface();

            IFormatter formatter = new BinaryFormatter();
            /*try
            {
                //Stream stream = new FileStream("db.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                //this.database = (MainDatabase)formatter.Deserialize(stream);
                //stream.Close();
            }
            catch (FileNotFoundException e)
            {
               // this.database = new MainDatabase();
                //MessageBox.Show(e.Message + "\nCreating fresh database.");
            }*/

            //populate the comboboxes
            this.UpdateBoxes();

        }

        public void UpdateBoxes()
        {
            this.comboBox1.Items.Clear();
            foreach (Fretboard fb in Database.getInstance().fretboards)
            {
                this.comboBox1.Items.Add(fb.name);
            }

            this.comboBox2.Items.Clear();
            foreach (ChordRecipe cr in Database.getInstance().chordRecipes)
            {
                this.comboBox2.Items.Add(cr.name);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int startingPosX = 70;
            int startingPosY = 100;

            int fretCount = 12;
            int stringCount = 6;

            Bitmap background = new Bitmap("..\\..\\res\\background.png");
            Bitmap strings = new Bitmap("..\\..\\res\\string.png");
            Bitmap background_top = new Bitmap("..\\..\\res\\background_top.png");
            Bitmap background_bottom = new Bitmap("..\\..\\res\\background_bottom.png");
            Bitmap background_left_coverup = new Bitmap("..\\..\\res\\background_left_coverup.png");
            Bitmap background_right_coverup = new Bitmap("..\\..\\res\\background_right_coverup.png");
            Bitmap nut = new Bitmap("..\\..\\res\\nut.png");

            for (int i = 0; i < fretCount + 2; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    e.Graphics.DrawImage(background, startingPosX + i * 60, startingPosY + j * 30, 60, 30);
                }
            }

            
            for (int i = 0; i < fretCount + 2; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    e.Graphics.DrawImage(strings, startingPosX + i * 60, startingPosY + j * 30, 60, 30);
                }
            }

            for (int i = 0; i < stringCount; i++)
            {
                e.Graphics.DrawImage(nut, startingPosX, startingPosY + i * 30, 60, 30);
            }

            for (int i = 0; i < fretCount + 2; i++)
            {
                e.Graphics.DrawImage(background_top, startingPosX + i * 60, startingPosY - 16, 60, 30);
            }

            for (int i = 0; i < fretCount + 2; i++)
            {
                e.Graphics.DrawImage(background_bottom, startingPosX + i * 60, startingPosY - 14 + stringCount * 30, 60, 30);
            }

            for (int i = 0; i < stringCount+2; i++)
            {
                e.Graphics.DrawImage(background_left_coverup, startingPosX, startingPosY - 30 + i * 30, 60, 30);
            }

            for (int i = 0; i < stringCount + 2; i++)
            {
                e.Graphics.DrawImage(background_right_coverup, startingPosX + (fretCount + 1) * 60, startingPosY - 30 + i * 30, 60, 30);
            }

            for (int i = 0; i < stringCount; i++)
            {
                Bitmap note = new Bitmap("..\\..\\res\\notes\\note_" + i + ".png");
                e.Graphics.DrawImage(note, startingPosX, startingPosY + i * 30, 60, 30);
            }

            int startingPosXKeyboard = 70;
            int startingPosYKeyboard = 400;

            Bitmap whiteKey = new Bitmap("..\\..\\res\\white_key.png");
            Bitmap blackKey = new Bitmap("..\\..\\res\\black_key.png");
            Bitmap whiteKeyHighlight = new Bitmap("..\\..\\res\\white_key_highlight.png");
            Bitmap blackKeyHighlight = new Bitmap("..\\..\\res\\black_key_highlight.png");

            //6 octaves
            int keyNumber = 0;
            int verticalIterator = 0;
            while (keyNumber < 72)
            {
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //C
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //D
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //E
                verticalIterator += 20;
                keyNumber += 1;
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //F
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //G
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(whiteKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //A
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //B
                verticalIterator += 20;
                keyNumber += 1;
            }

            keyNumber = 1;
            verticalIterator = 15;
            while (keyNumber < 72)
            {
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //C#
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(blackKeyHighlight, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //D#
                verticalIterator += 40;
                keyNumber += 3;
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //F#
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //G#
                verticalIterator += 20;
                keyNumber += 2;
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //A#
                verticalIterator += 40;
                keyNumber += 3;
            }




            //e.Graphics.DrawImage(bitmap, 50, 100, 60, 30);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("db.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.database);
            stream.Close();*/
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int startingPosXKey = 70;
            int startingPosYKey = 400;
            int endingPosX = 42 * 20 + startingPosXKey;
            int endingPosY = startingPosYKey + 100;
            Note note ;
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
                            }else
                            {
                                if ( e.X >= startingPosXKey + 20 + (140 * octavNumber) + 15)//Dis
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
                Console.Write("note\n");
            }
        }
    }
}

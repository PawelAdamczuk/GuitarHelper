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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            int startingPosXKeyboard = 70;
            int startingPosYKeyboard = 400;

            Bitmap whiteKey = new Bitmap("..\\..\\res\\white_key.png");
            Bitmap blackKey = new Bitmap("..\\..\\res\\black_key.png");

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
                e.Graphics.DrawImage(whiteKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 20, 100); //A
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
                e.Graphics.DrawImage(blackKey, startingPosXKeyboard + verticalIterator, startingPosYKeyboard, 10, 60); //D#
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
    }
}

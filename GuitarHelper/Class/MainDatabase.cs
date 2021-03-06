﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHelper.Class
{
    [Serializable]
    class MainDatabase
    {
        public List<ChordRecipe> chordRecipes;
        public List<Fretboard> fretboards;

        public MainDatabase()
        {
            this.chordRecipes = new List<ChordRecipe>();
            this.fretboards = new List<Fretboard>();

            List<int> intervals = new List<int>();
            intervals.Add(0);
            intervals.Add(4);
            intervals.Add(7);
            ChordRecipe major = new ChordRecipe(intervals, "major");
            this.chordRecipes.Add(major);

            List<int> intervals2 = new List<int>();
            intervals2.Add(0);
            intervals2.Add(3);
            intervals2.Add(7);
            ChordRecipe minor = new ChordRecipe(intervals2, "minor");
            this.chordRecipes.Add(minor);

            Note e = new Note(5, 4);
            Note b = new Note(4, 11);
            Note g = new Note(4, 7);
            Note d = new Note(4, 2);
            Note a = new Note(3, 9);
            Note e_low = new Note(3, 4);

            List<Note> strings = new List<Note>();
            strings.Add(e);
            strings.Add(b);
            strings.Add(g);
            strings.Add(d);
            strings.Add(a);
            strings.Add(e_low);

            Fretboard fb = new Fretboard(strings, "standard");

            this.fretboards.Add(fb);


        }
    }
}

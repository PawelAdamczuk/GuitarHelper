using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GuitarHelper.Class
{
    class Database
    {
        private static Database baseInstance = null;
        private List<ChordRecipe> chordRecipes;
        private List<Fretboard> fretboards;

        private Database()
        {
            //Wczytujemy do systemu dane z plików XML
            this.chordRecipes = new List<ChordRecipe>();
            this.fretboards = new List<Fretboard>();

            if (this.getFretboard("standard") == null)
            {
                List<Note> strings = new List<Note>();

                strings.Add(new Note(3, 4));
                strings.Add(new Note(3, 9));
                strings.Add(new Note(4, 2));
                strings.Add(new Note(4, 7));
                strings.Add(new Note(5, 4));

                this.addFretboard(new Fretboard(strings, "standard"));
            }

        }

        public static Database getInstance()
        {
            if (baseInstance == null)
                baseInstance = new Database();
            return baseInstance;
        }

        public void addChord(ChordRecipe recipe)
        {
            //Dodajemy do XML
            this.chordRecipes.Add(recipe);
            XmlSerializer writer =
                new XmlSerializer(typeof(ChordRecipe));

            FileStream file = new FileStream(Environment.CurrentDirectory + "//chordsBase.xml", FileMode.OpenOrCreate, FileAccess.Write);
            writer.Serialize(file, recipe);
            file.Close();
        }
        public void addFretboard(Fretboard fretBoard)
        {
            this.fretboards.Add(fretBoard);
            //Dodajemy do XML
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(Fretboard), new Type[] { typeof(Note) });
                FileStream file = new FileStream(Environment.CurrentDirectory + "//fretBoardBase.xml", FileMode.OpenOrCreate, FileAccess.Write);
                writer.Serialize(file, fretBoard);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString() + "\n");
            }

        }
        public Fretboard getFretboard(string name)
        {
            foreach (Fretboard _fretboard in fretboards)
            {
                if (_fretboard.name.Equals(name))
                    return _fretboard;
            }
            return null;
        }
    }
}

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
        List<ChordRecipe> chordRecipes;
        List<Fretboard> fretboards;
        public Database()
        {
            //Wczytujemy do systemu dane z plików XML
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//chordBase.xml";
            
        }
        void addChord(ChordRecipe recipe)
        {
            //Dodajemy do XML
            XmlSerializer writer =
                new XmlSerializer(typeof(ChordRecipe));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ "//chordBase.xml";
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, recipe);
            file.Close();
        }
        void addFretboard(Fretboard fretBoard)
        {
            //Dodajemy do XML
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Fretboard));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//fretBoardBase.xml";
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, fretBoard);
            file.Close();
        }
        void addAnyThink(Object o,string filename)
        {
            XmlSerializer sr = new XmlSerializer(o.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, o);
            writer.Close();
        }
    }
}

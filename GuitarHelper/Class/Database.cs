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
            this.chordRecipes = new List<ChordRecipe>();
            this.fretboards = new List<Fretboard>();
            XmlSerializer reader = new XmlSerializer(typeof(ChordRecipe));
            try
            {
                //Wczytujemy rekordy z chordBase.xml
                FileStream file = new FileStream(Environment.CurrentDirectory + "//chordsBase.xml", FileMode.Open, FileAccess.Read);
                chordRecipes = reader.Deserialize(file) as List<ChordRecipe>;
                file.Close();
                
            } catch(Exception ex){}

            try 
            {
                //Wczytujemy rekordy z fretBoarBase.xml
                FileStream file = new FileStream(Environment.CurrentDirectory + "//fretBoardBase.xml.xml", FileMode.Open, FileAccess.Read);
                fretboards = reader.Deserialize(file) as List<Fretboard>;
                file.Close();
            }
            catch (Exception ex) { }
        }


        public void addChord(ChordRecipe recipe)
        {
            //Dodajemy do XML
            this.chordRecipes.Add(recipe);
            XmlSerializer writer =
                new XmlSerializer(typeof(ChordRecipe));

            FileStream file = new FileStream(Environment.CurrentDirectory + "//chordsBase.xml", FileMode.OpenOrCreate,FileAccess.Write );
            writer.Serialize(file, recipe);
            file.Close();
        }
        void addFretboard(Fretboard fretBoard)
        {
            this.fretboards.Add(fretBoard);
            //Dodajemy do XML
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Fretboard));

            FileStream file = new FileStream(Environment.CurrentDirectory + "//fretBoardBase.xml", FileMode.OpenOrCreate, FileAccess.Write );
            writer.Serialize(file, fretBoard);
            file.Close();
        }
    }
}

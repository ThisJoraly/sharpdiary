using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asswecan
{
    public class Note
    {
        public static List<Note> notes = new List<Note>();

        

        // модель заметки
        public static string noteName { get; set; }
        public static string noteDescripton { get; set; }
        public static DateTime? noteDate { get; set; }

        public string getNoteName() { return noteName; }
        public Note(string nN, string nD, DateTime? nDt)
        {
            noteName = nN;
            noteDescripton = nD;
            noteDate = nDt;
        }

    }

}

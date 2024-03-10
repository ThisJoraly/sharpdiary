using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asswecan
{
    public class Note
    {

        // модель заметки
        public static string noteName { get; set; }
        public static string noteDescription { get; set; }
        public static DateTime? noteDate { get; set; }

        public string NoteName
        {
            get { return noteName; }
            set { noteName = value; }
        }
        public string NoteDescription
        {
            get { return noteDescription; }
            set { noteDescription = value; }
        }
        public DateTime? NoteDate
        {
            get { return noteDate; }
            set { noteDate = value; }
        }
        public Note(string nN, string nD, DateTime? nDt)
        {
            noteName = nN;
            noteDescription = nD;
            noteDate = nDt;
        }

    }

    public static class Notes
    {
        public static List<Note> notes = new List<Note>();
        public static List<Note> finalNotes = new List<Note>();
        public static Json<List<Note>> json = new Json<List<Note>>(); 
        public static List<Note> GetNotesForDate(DateTime date)
        {
            return notes.Where(x => x.NoteDate.Value.Date == date.Date).ToList();
        }
        public static void AddNote(Note note)
        {
            notes.Add(note);
            finalNotes = notes;
            SaveChanges();
        }
        public static void EditNote(Note note)
        {
            Note existingNote = notes.FirstOrDefault(x => x.NoteDate.Value.Date == note.NoteDate.Value.Date);
            if (existingNote != null)
            {
                existingNote.NoteName = note.NoteName;
                existingNote.NoteDescription = note.NoteDescription;
                SaveChanges();
            }
        }

        public static void SaveChanges() => json.Serialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\notes.json", notes);

    }

    public class Json<T>
    {
        public void Serialize(string fileName, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, json);
        }

        public T Deserialize(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T _Deserialize(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public static class JsonUtil<T>
    {
        public static void Add(string filename, T obj, List<T> list) {
            if(list != null)
            {
                list = Json<List<T>>._Deserialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\notes.json");
            }
            list.Add(obj);
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filename, json);
        }
    }
}

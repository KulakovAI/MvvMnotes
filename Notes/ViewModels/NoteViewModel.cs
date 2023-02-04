using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Notes.Models;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Notes.ViewModels
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        NotesListViewModel lvm;

        public Note Note { get; private set; }
        public NoteViewModel()
        {
            Note = new Note();
        }
        public NotesListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string TitleNote
        {
            get { return Note.TitleNote; }
            set
            {
                if (Note.TitleNote != value)
                {
                    Note.TitleNote = value;
                    OnPropertyChanged("TitleNote");
                }
            }
        }
        public string TextNote
        {
            get { return Note.TextNote; }
            set
            {
                if (Note.TextNote != value)
                {
                    Note.TextNote = value;
                    OnPropertyChanged("TextNote");
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(TitleNote.Trim())) ||
                    (!string.IsNullOrEmpty(TextNote.Trim())));
                   
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

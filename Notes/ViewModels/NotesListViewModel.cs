using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Notes.Views;

namespace Notes.ViewModels
{
    public class NotesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NoteViewModel> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateNoteCommand { protected set; get; }
        public ICommand DeleteNoteCommand { protected set; get; }
        public ICommand SaveNoteCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        NoteViewModel selectedNote;

        public INavigation Navigation { get; set; }

        public NotesListViewModel()
        {
            Notes = new ObservableCollection<NoteViewModel>();
            CreateNoteCommand = new Command(CreateNote);
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            BackCommand = new Command(Back);
        }
        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }    
            set
            {
                if (selectedNote != value)
                {
                    NoteViewModel tempNote = value;
                    selectedNote = null;
                    OnPropertyChanged("SelectedNote");
                    Navigation.PushAsync(new NotePage(tempNote));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateNote()
        {
            Navigation.PushAsync(new NotePage(new NoteViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveNote(object noteObject)
        {
            NoteViewModel note = noteObject as NoteViewModel;
            if (note != null && note.IsValid && !Notes.Contains(note))
            {
                Notes.Add(note);
            }
            Back();
        }
        private void DeleteNote(object noteObject)
        {
            NoteViewModel note = noteObject as NoteViewModel;
            if (note != null)
            {
                Notes.Remove(note);
            }
            Back();
        }
    }
}

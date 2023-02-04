using Notes.ViewModels;

namespace Notes.Views;

public partial class NoteListPage : ContentPage
{
	public NoteListPage()
	{
		InitializeComponent();
        BindingContext = new NotesListViewModel() { Navigation = this.Navigation };
    }
}
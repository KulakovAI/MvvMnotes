	namespace Notes.Views;
using Notes.ViewModels;

public partial class NotePage : ContentPage
{
    public NoteViewModel ViewModel { get; private set; }
    public NotePage(NoteViewModel vm)
	{
		InitializeComponent();
        ViewModel = vm;
        this.BindingContext = ViewModel;
    }
}
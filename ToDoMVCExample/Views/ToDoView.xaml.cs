using System.Collections.ObjectModel;

namespace ToDoMVCExample.Views;

public partial class ToDoView : ContentPage
{
	public Controllers.ToDoController controller { get; set; }
	public ToDoView()
	{
		InitializeComponent();
		controller = new Controllers.ToDoController(collToDoItems);

	}
}
namespace ToDoMVCExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ToDoView();
        }
    }
}

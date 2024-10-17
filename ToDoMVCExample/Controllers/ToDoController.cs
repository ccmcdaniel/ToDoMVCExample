using System.Collections.ObjectModel;

namespace ToDoMVCExample.Controllers
{
    public class ToDoItemConverter: BindableObject
    {
        public Models.ToDoModel ToDoModel { get; set; }

        public ToDoItemConverter(Models.ToDoModel data)
        {
                ToDoModel = data;
        }

        public string ColorRadio
        {
            get
            {
                if (ToDoModel.isCompleted) return "#238932";
                else return "#892332";
            }
        }
        public string ColorBackDrop
        {
            get
            {
                if (ToDoModel.isCompleted) return "#45AB54";
                else return "#AB4554";
            }
        }

        public string AssignedTo 
        {
            get { return $"Assigned To: {ToDoModel.issuedTo}"; }     
        }

        public string DateAssigned
        {
            get { return $"{ToDoModel.dateAssigned.ToString()}"; }
        }

        public string DateCompleted
        {
            get 
            {
                if (ToDoModel.isCompleted)
                    return $"Completed On {ToDoModel.dateCompleted.ToString()}";
                else
                    return "Not Completed";
            }
        }

        public bool IsCompleted
        {
            get
            {
                return ToDoModel.isCompleted;
            }
            set
            {
                ToDoModel.CompleteItem();
                NotifyView();
            }
        }


        public string Detail { get { return ToDoModel.Detail; } }

        //If a setter function is called for any property,
        //this notifies the bound view (in this case, the Collection View,
        //to refresh.
        private void NotifyView()
        {
            OnPropertyChanged(nameof(ColorRadio));
            OnPropertyChanged(nameof(ColorBackDrop));
            OnPropertyChanged(nameof(AssignedTo));
            OnPropertyChanged(nameof(DateAssigned));
            OnPropertyChanged(nameof(DateCompleted));
            OnPropertyChanged(nameof(DateAssigned));
            OnPropertyChanged(nameof(IsCompleted));
        }
    }

    public class ToDoController
    {
        public ObservableCollection<ToDoItemConverter> Items { get; set; }

        public ToDoController(CollectionView view)
        {
            Items = new ObservableCollection<ToDoItemConverter>();

            //Create a set of test items
            var item = new Models.ToDoModel
            {
                Detail = "Do the Dishes",
                issuedTo = "Corey"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Clean the curtains",
                issuedTo = "Sarah"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Take out the Trash",
                issuedTo = "Jake"
            };
            Items.Add(new ToDoItemConverter(item));

            item = new Models.ToDoModel
            {
                Detail = "Mop the Floor",
                issuedTo = "Katey"
            };
            item.CompleteItem();
            Items.Add(new ToDoItemConverter(item));


            item = new Models.ToDoModel
            {
                Detail = "Clean the Bathroom",
                issuedTo = "Seth"
            };
            Items.Add(new ToDoItemConverter(item));

            view.ItemsSource = Items;
        }
    }
}

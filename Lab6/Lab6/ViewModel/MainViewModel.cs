using Lab6.Commands;
using Lab6.Memento;
using System.Windows;
using System.Windows.Input;

namespace Lab6.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        internal ChangesHistory Changes = new();

        public ICommand SwitchViewCommand { get; set; }
        public ICommand ShowEmailCommand { get; set; }

        private string _email = "hyzerki@gmail.com";
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }

        public MainViewModel(BaseViewModel? parentViewModel = null) : base(parentViewModel)
        {
            SwitchViewCommand = new SwitchViewCommand(this);
            ShowEmailCommand = new DelegateCommand(ShowEmail);
            _selectedViewModel = new CatalogViewModel(this);
        }
        private void ShowEmail()
        {
            MessageBox.Show(Email);
        }
    }
}

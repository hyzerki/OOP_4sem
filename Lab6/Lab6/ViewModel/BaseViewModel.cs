using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab6.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private BaseViewModel? _parentViewModel;
        public BaseViewModel? ParentViewModel { get { return _parentViewModel; } set => _parentViewModel = value; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected BaseViewModel(BaseViewModel? parentViewModel = null)
        {
            _parentViewModel = parentViewModel;
        }
    }
}

namespace Lab6.ViewModel
{
    internal class WindowViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel = new MainViewModel();
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public WindowViewModel()
        {

        }
    }
}

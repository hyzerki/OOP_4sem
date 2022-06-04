using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab6.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        private ResourceDictionary Pink;
        private ResourceDictionary Dark;

        public ObservableCollection<ResourceDictionary> Colors { get; set; } = new();

        private ResourceDictionary _currentColor;
        public ResourceDictionary CurrentColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                OnPropertyChanged(nameof(_currentColor));
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public WindowViewModel(BaseViewModel? parentViewModel = null) : base(parentViewModel)
        {
            _currentViewModel = new MainViewModel(this);
            Pink = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resources/Dictionaries/Pink.xaml") };
            Dark = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resources/Dictionaries/Dark.xaml") };
            _currentColor = Dark;
            Colors.Add(Pink);
            Colors.Add(Dark);
        }
    }
}

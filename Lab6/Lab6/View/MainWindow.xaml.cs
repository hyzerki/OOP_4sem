using Lab6.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab6.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResourceDictionary Pink;
        private ResourceDictionary Dark;
        public ObservableCollection<string> Colors { get; set; } = new() { nameof(Dark), nameof(Pink) };


        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            InitializeComponent();
            this.DataContext = new WindowViewModel(null);
            Pink = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resources/Dictionaries/Pink.xaml") };
            Dark = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resources/Dictionaries/Dark.xaml") };
            ColorComboBox.SelectionChanged += ColorSelecrionHandler;
            ColorComboBox.ItemsSource = Colors;
            this.Resources = Dark;
        }

        private void ColorSelecrionHandler(object sender, EventArgs e)
        {

            switch (ColorComboBox.SelectedItem)
            {
                case nameof(Pink):
                    this.Resources = Pink;
                    break;
                case nameof(Dark):
                    this.Resources = Dark;
                    break;
            }
        }
    }
}

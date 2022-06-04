using System.Windows.Controls;

namespace Lab6.View
{
    /// <summary>
    /// Логика взаимодействия для EventsDemo.xaml
    /// </summary>
    public partial class EventsDemo : UserControl
    {
        public EventsDemo()
        {
            InitializeComponent();
        }

        private void Control_MouseDown(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Button_MouseDown(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlock1.Text = string.Empty;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlock1.Text = string.Empty;

        }
    }
}

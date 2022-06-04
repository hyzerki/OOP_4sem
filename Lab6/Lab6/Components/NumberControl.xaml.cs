using System.Windows;
using System.Windows.Controls;

namespace Lab6.Components
{
    /// <summary>
    /// Логика взаимодействия для NumberControl.xaml
    /// </summary>
    public partial class NumberControl : UserControl
    {
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(NumberControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnNumberChanged), new CoerceValueCallback(CoerceNumber)), new ValidateValueCallback(ValidateNumber));

        private static bool ValidateNumber(object value)
        {
            if ((int)value >= 0)
            {
                return true;
            }
            return false;
        }
        private static object CoerceNumber(DependencyObject d, object value)
        {
            if ((int)value > 1000)
                return 1000;
            return value;
        }
        private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumberControl numberInput)
            {
                numberInput.UpdateNumber();
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Number = int.Parse(((TextBox)sender).Text);
        }

        private void UpdateNumber()
        {
            NumberBox.Text = Number.ToString();
        }
        public NumberControl()
        {
            InitializeComponent();
        }
    }
}

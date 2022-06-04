using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Lab6.Components
{
    /// <summary>
    /// Логика взаимодействия для EmailInput.xaml
    /// </summary>
    public partial class EmailInput : UserControl
    {
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register("Email", typeof(string), typeof(EmailInput), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnEmailChanged), new CoerceValueCallback(CoerceEmail)), new ValidateValueCallback(ValidateEmail));

        private static bool ValidateEmail(object value)
        {
            if ((string)value == string.Empty || new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$").IsMatch((string)value))
            {
                return true;
            }
            return false;
        }
        private static object CoerceEmail(DependencyObject d, object value)
        {
            return "hyzerki@gmail.com";
        }
        private static void OnEmailChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EmailInput emailInput)
            {
                emailInput.UpdateEmail();
            }
        }

        public EmailInput()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = ((TextBox)sender).Text;
        }

        private void UpdateEmail()
        {
            emailBox.Text = Email;
        }
    }
}

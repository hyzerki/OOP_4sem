using Lab1;
using Lab2.Singletone;

namespace Lab2.Command
{
    public class ChangeBackgroundCommand : ICommand
    {
        private Form1 form;

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            FormSettings.GetInstance().BGColor = colorDialog.Color;
            form.BackColor = FormSettings.GetInstance().BGColor; ;
        }

        public ChangeBackgroundCommand(Form1 form)
        {
            this.form = form;
        }
    }
}

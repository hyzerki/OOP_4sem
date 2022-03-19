using Lab2;
using Lab2.Model;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public MainFormController _controller;
        public Form1()
        {
            InitializeComponent();
            this._controller = new MainFormController(this);
            this.timer1.Tick += tick!;

        }

        [DllImport("user32.dll")]
        private static extern int GetGuiResources(IntPtr hProcess, int uiFlags);
        private void tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = DateTime.Now.ToString();
            this.toolStripStatusLabel2.Text = GetGuiResources(Process.GetCurrentProcess().Handle, 1).ToString();
            //StackTrace st = (new System.Diagnostics.StackTrace());
            //this.toolStripStatusLabel3.Text = st.GetFrame(1)!.GetMethod()!.Name;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Недоверсия Мелешко Никита", "О программе");
        }


        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(this);
            searchForm.Show();
        }


    }
}
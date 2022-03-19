using Lab1;
using Lab1.Model;
using System.Text.RegularExpressions;

namespace Lab2
{
    public partial class SearchForm : Form
    {
        Form1 _parentForm;
        public SearchForm(Form1 form1)
        {
            InitializeComponent();
            _parentForm = form1;

            foreach (PlaneType planeType in Enum.GetValues(typeof(PlaneType)))
            {
                this.SearcPlaneByTypeListBox.Items.Add(planeType);
            }

            this.SortPlanesByComboBox.Items.Add("Без сортировки");
            this.SortPlanesByComboBox.Items.Add("Год выпуска возр.");
            this.SortPlanesByComboBox.Items.Add("Год выпуска убыв.");
            this.SortPlanesByComboBox.Items.Add("Дата ТО возр.");
            this.SortPlanesByComboBox.Items.Add("Дата ТО убыв.");
            this.SortPlanesByComboBox.SelectedIndex = 0;
        }

        private void SearchPlaneButton_Click(object sender, EventArgs e)
        {
            List<Plane> planes = _parentForm._controller.readPlanesFromFile();
            Regex regex = new Regex(this.SearchPlaneTextBox.Text);
            List<Plane> result = (planes as IEnumerable<Plane>).Where(p => regex.IsMatch(p.Model) && p.Capatity >= this.SearchPlaneByCapacityUD.Value && p.PassengerSeats >= this.SearchPlaneBySeatsUD.Value && this.SearcPlaneByTypeListBox.SelectedItems.Count > 0 ? this.SearcPlaneByTypeListBox.SelectedItems.Contains(p.Type) : true).ToList<Plane>();
            switch (this.SortPlanesByComboBox.SelectedItem as string)
            {
                case "Год выпуска возр.":
                    result = result.OrderBy(p => p.ReleasedAt).ToList<Plane>();
                    break;
                case "Год выпуска убыв.":
                    result = result.OrderByDescending(p => p.ReleasedAt).ToList<Plane>();
                    break;
                case "Дата ТО возр.":
                    result = result.OrderBy(p => p.LastMaintenance).ToList<Plane>();
                    break;
                case "Дата ТО убыв.":
                    result = result.OrderByDescending(p => p.LastMaintenance).ToList<Plane>();
                    break;
            }
            _parentForm._controller.updatePlaneView(result);
        }
    }
}

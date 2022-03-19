using Lab1;
using Lab1.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Model
{
    public class MainFormController
    {
        #region Поля и константы
        private Form1 form;
        private const string PLANES_PATH = "Planes.json";
        private const string MANUFACTURERS_PATH = "Manufacturers.json";
        #endregion

        #region Открытые методы
        public void AddPlane(object sender, EventArgs e)
        {
            List<Plane> planes = readPlanesFromFile();
            Plane plane = new Plane(Guid.NewGuid(), "Новый самолёт", PlaneType.Passenger, 0, 2000, 0, DateTime.Now, new List<CrewMate>(), null!);
            planes.Add(plane);
            planeListToFile(planes);
            updatePlaneView(planes, planes.IndexOf(plane));
        }

        public void RemovePlane(object sender, EventArgs e)
        {
            List<Plane> planes = readPlanesFromFile();
            Plane toRemove = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;
            planes.Remove(toRemove);
            planeListToFile(planes);
            if (planes.Count == 0)
                flushInputs();
            updatePlaneView(planes);
        }



        public void AddCrewMate(object sender, EventArgs e)
        {
            List<Plane> planes = readPlanesFromFile();
            Plane plane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;
            plane.CrewList.Add(new CrewMate("Новый челен", CrewMatePost.Stewart, DateTime.Now, DateTime.Now));
            planeListToFile(planes);
            updateCrewComboBox(plane);
        }

        public void RemoveCrewMate(object sender, EventArgs e)
        {
            List<Plane> planes = readPlanesFromFile();
            Plane plane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;
            CrewMate mate = plane.CrewList[form.CrewmatesComboBox.SelectedIndex];
            plane.CrewList.Remove(mate);
            planeListToFile(planes);
            updateCrewComboBox(plane);
        }

        public bool Validate<T>(object obj)
        {
            List<ValidationResult> pmerrors = new List<ValidationResult>();
            if (!Validator.TryValidateObject((T)obj, new ValidationContext((T)obj), pmerrors))
            {
                foreach (ValidationResult res in pmerrors)
                {
                    MessageBox.Show(res.ErrorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OnDataEdited(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            List<Plane> planes = readPlanesFromFile();
            Plane selectedPlane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;


            List<Manufacturer> manufacturers = readManufacturersFromFile();
            Manufacturer manufacturer = (manufacturers as IEnumerable<Manufacturer>).Where<Manufacturer>(p => p.Id == selectedPlane.Manufacturer?.Id).FirstOrDefault()!;

            switch (control.Tag)
            {
                case "PlaneModel":
                    string prevPlaneModel = selectedPlane.Model;
                    selectedPlane.Model = form.PlaneModelTextBox.Text;
                    if (!Validate<Plane>(selectedPlane))
                    {
                        selectedPlane.Model = prevPlaneModel;
                        form.PlaneModelTextBox.Text = prevPlaneModel;
                    }
                    planeListToFile(planes);
                    form.PlanesListView.SelectedItems[0].Text = selectedPlane.Model;
                    break;
                case "PlaneType":
                    selectedPlane.Type = (PlaneType)form.PlaneTypeComboBox.SelectedItem;
                    if (Validate<Plane>(selectedPlane))
                    {
                        planeListToFile(planes);
                    }
                    break;
                case "PlaneCapacity":
                    selectedPlane.Capatity = (int)form.PlaneCapacityUD.Value;
                    if (Validate<Plane>(selectedPlane))
                    {
                        planeListToFile(planes);
                    }
                    break;
                case "PlaneSeats":
                    selectedPlane.PassengerSeats = (int)form.PlanePassengerSeatsUD.Value;
                    if (Validate<Plane>(selectedPlane))
                    {
                        planeListToFile(planes);
                    }
                    break;
                case "PlaneReleased":
                    selectedPlane.ReleasedAt = (int)form.PlaneReleasedUD.Value;
                    if (Validate<Plane>(selectedPlane))
                    {
                        planeListToFile(planes);
                    }
                    break;
                case "PlaneMaintenance":
                    selectedPlane.LastMaintenance = form.PlaneMaintenance.Value;
                    planeListToFile(planes);
                    break;

                //here it goes for Manufacturer input
                case "ManufacturerCountry":
                    manufacturer.Country = form.ManufacrurerCountryTextBox.Text;
                    manufacturersListToFile(manufacturers);
                    break;
                case "ManufacturerName":
                    manufacturer.Name = form.ManufacturerNameTextBox.Text;
                    manufacturersListToFile(manufacturers);
                    UpdateManufacturersComboBox(manufacturers, selectedPlane);
                    break;
                case "ManufacturerFounded":
                    manufacturer.Founded = (int)form.ManufacturerFoundedNumericUD.Value;
                    manufacturersListToFile(manufacturers);
                    break;
                case "ManufacturerPlaneType":
                    manufacturer.PlaneTypes.Clear();
                    foreach (PlaneType planeType in form.ManufacturerPlaneType.CheckedItems)
                    {
                        manufacturer.PlaneTypes.Add(planeType);
                    }
                    manufacturersListToFile(manufacturers);
                    break;

                //crewmates management
                case "CrewmateFullName":
                    selectedPlane.CrewList[form.CrewmatesComboBox.SelectedIndex].FullName = form.CrewmateNameTextBox.Text;
                    planeListToFile(planes);
                    form.CrewmatesComboBox.Items[form.CrewmatesComboBox.SelectedIndex] = form.CrewmateNameTextBox.Text;
                    break;
                case "CrewmateBdate":
                    selectedPlane.CrewList[form.CrewmatesComboBox.SelectedIndex].BirthDay = form.CrewmateBirthDayDateTimePicker.Value;
                    planeListToFile(planes);
                    break;
                case "CrewmateFirstFlight":
                    selectedPlane.CrewList[form.CrewmatesComboBox.SelectedIndex].FirstFlight = form.CrewmateFirstFlightDateTimePicker.Value;
                    planeListToFile(planes);
                    break;
                case "CrewmatePost":
                    selectedPlane.CrewList[form.CrewmatesComboBox.SelectedIndex].Post = (CrewMatePost)form.CrewmatePostComboBox.SelectedItem;
                    planeListToFile(planes);
                    break;


            }
        }


        public void AddManufacturer(object sender, EventArgs e)
        {
            List<Manufacturer> manufacturers = readManufacturersFromFile();
            manufacturers.Add(new Manufacturer(Guid.NewGuid(), "undefined", "undefined", DateTime.Now.Year, new List<PlaneType>()));
            manufacturersListToFile(manufacturers);
            UpdateManufacturersComboBox(manufacturers);
        }

        public void RemoveManufacturer(object sender, EventArgs e)
        {
            List<Manufacturer> manufacturers = readManufacturersFromFile();
            manufacturers.RemoveAt(form.ManufacturerComboBox.SelectedIndex);
            manufacturersListToFile(manufacturers);
            UpdateManufacturersComboBox(manufacturers);
        }

        public void SelectedManufacturerChanged(object sender, EventArgs e)
        {
            ComboBox cbManufacturer = (ComboBox)sender;
            List<Plane> planes = readPlanesFromFile();
            List<Manufacturer> manufacturers = readManufacturersFromFile();
            Plane edittedPlane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;
            Manufacturer selectedManufacturer = (manufacturers as IEnumerable<Manufacturer>).Where<Manufacturer>(p => p.Id == (cbManufacturer.SelectedItem as Manufacturer)!.Id).FirstOrDefault()!;
            edittedPlane.Manufacturer = selectedManufacturer;
            planeListToFile(planes);

            form.ManufacrurerCountryTextBox.Text = selectedManufacturer.Country;
            form.ManufacturerNameTextBox.Text = selectedManufacturer.Name;
            form.ManufacturerFoundedNumericUD.Value = selectedManufacturer.Founded;
            form.ManufacturerPlaneType.Items.Clear();
            foreach (PlaneType planeType in Enum.GetValues(typeof(PlaneType)))
            {
                form.ManufacturerPlaneType.Items.Add(planeType, selectedManufacturer.PlaneTypes.Contains(planeType));
            }

            if (cbManufacturer.SelectedIndex < 0)
                isManufacturerInputsEnabled(false);
            else
                isManufacturerInputsEnabled(true);
        }

        public void SelectedCrewmateChanged(object sender, EventArgs e)
        {
            ComboBox cbCrewmate = (ComboBox)sender;

            List<Plane> planes = readPlanesFromFile();
            Plane plane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;

            CrewMate crewMate = plane.CrewList[cbCrewmate.SelectedIndex];

            form.CrewmateNameTextBox.Text = crewMate.FullName;
            form.CrewmateBirthDayDateTimePicker.Value = crewMate.BirthDay;
            form.CrewmateFirstFlightDateTimePicker.Value = crewMate.FirstFlight;

            form.CrewmatePostComboBox.Items.Clear();
            int currId = 0;
            foreach (CrewMatePost post in Enum.GetValues(typeof(CrewMatePost)))
            {
                form.CrewmatePostComboBox.Items.Add(post);
                if (crewMate.Post == post)
                    form.CrewmatePostComboBox.SelectedIndex = currId++;
                currId++;
            }

            if (cbCrewmate.SelectedIndex < 0)
                isCrewmateInputsEnabled(false);
            else
                isCrewmateInputsEnabled(true);
        }

        public void SelectedPlaneChanged(object sender, EventArgs e)
        {
            ListView listView = (sender as ListView)!;
            flushInputs();

            if (listView.SelectedItems.Count > 0)
            {
                List<Plane> planes = readPlanesFromFile();
                Plane plane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (listView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;

                form.PlaneCapacityUD.Value = plane.Capatity;
                form.PlaneIdentifierTextBox.Text = plane.Id.ToString();
                form.PlaneModelTextBox.Text = plane.Model;
                form.PlanePassengerSeatsUD.Value = plane.PassengerSeats;
                form.PlaneReleasedUD.Value = plane.ReleasedAt;
                form.PlaneMaintenance.Value = plane.LastMaintenance;

                updateCrewComboBox(plane);

                List<Manufacturer> manufacturers = readManufacturersFromFile();
                UpdateManufacturersComboBox(manufacturers, plane);

                form.PlaneTypeComboBox.Items.Clear();

                int currId = 0;
                foreach (PlaneType planeType in Enum.GetValues(typeof(PlaneType)))
                {
                    form.PlaneTypeComboBox.Items.Add(planeType);
                    if (plane.Type == planeType)
                        form.PlaneTypeComboBox.SelectedIndex = currId;
                    currId++;
                }
                isPlaneInputsEnabled(true);
            }
            else
            {
                isPlaneInputsEnabled(false);
            }
        }


        #endregion

        #region Конструкторы
        public MainFormController(Form1 form)
        {
            this.form = form;
            updatePlaneView(readPlanesFromFile());
            this.form.AddNewPlaneButton.Click += AddPlane!;
            this.form.RemovePlaneButton.Click += RemovePlane!;
            this.form.PlanesListView.ItemSelectionChanged += SelectedPlaneChanged!;
            this.form.PlaneModelTextBox.Leave += OnDataEdited!;
            this.form.PlaneTypeComboBox.SelectionChangeCommitted += OnDataEdited!;
            this.form.PlaneCapacityUD.Leave += OnDataEdited!;
            this.form.PlanePassengerSeatsUD.Leave += OnDataEdited!;
            this.form.PlaneReleasedUD.Leave += OnDataEdited!;
            this.form.PlaneMaintenance.Leave += OnDataEdited!;

            this.form.ManufacturerComboBox.SelectedValueChanged += SelectedManufacturerChanged!;
            this.form.AddNewManufacturerButon.Click += AddManufacturer!;
            this.form.RemoveManufacturerButton.Click += RemoveManufacturer!;
            this.form.ManufacrurerCountryTextBox.Leave += OnDataEdited!;
            this.form.ManufacturerNameTextBox.Leave += OnDataEdited!;
            this.form.ManufacturerFoundedNumericUD.Leave += OnDataEdited!;
            this.form.ManufacturerPlaneType.SelectedValueChanged += OnDataEdited!;

            this.form.CrewmatesComboBox.SelectedValueChanged += SelectedCrewmateChanged!;
            this.form.AddNewCrewmateButton.Click += AddCrewMate!;
            this.form.RemoveCrewmateButton.Click += RemoveCrewMate!;
            this.form.CrewmateNameTextBox.Leave += OnDataEdited!;
            this.form.CrewmateBirthDayDateTimePicker.Leave += OnDataEdited!;
            this.form.CrewmateFirstFlightDateTimePicker.Leave += OnDataEdited!;
            this.form.CrewmatePostComboBox.SelectedValueChanged += OnDataEdited!;

        }
        #endregion

        #region Инкапсулированные методы
        private void flushInputs()
        {
            this.form.PlaneIdentifierTextBox.ResetText();
            this.form.PlaneModelTextBox.ResetText();
            this.form.PlaneTypeComboBox.Items.Clear();
            this.form.PlaneCapacityUD.Value = this.form.PlaneCapacityUD.Minimum;
            this.form.PlanePassengerSeatsUD.Value = this.form.PlanePassengerSeatsUD.Minimum;
            this.form.PlaneReleasedUD.Value = this.form.PlaneReleasedUD.Minimum;
            this.form.PlaneMaintenance.ResetText();
            this.form.ManufacturerComboBox.Items.Clear();
            this.form.ManufacrurerCountryTextBox.ResetText();
            this.form.ManufacturerNameTextBox.ResetText();
            this.form.ManufacturerFoundedNumericUD.Value = this.form.ManufacturerFoundedNumericUD.Minimum;
            this.form.ManufacturerPlaneType.Items.Clear();
            this.form.CrewmatesComboBox.Items.Clear();
            this.form.CrewmateNameTextBox.ResetText();
            this.form.CrewmateBirthDayDateTimePicker.ResetText();
            this.form.CrewmateFirstFlightDateTimePicker.ResetText();
            this.form.CrewmatePostComboBox.Items.Clear();

            isCrewmateInputsEnabled(false);
            isPlaneInputsEnabled(false);
            isManufacturerInputsEnabled(false);
        }

        private void isPlaneInputsEnabled(bool enable)
        {
            this.form.PlaneModelTextBox.Enabled = enable;
            this.form.PlaneTypeComboBox.Enabled = enable;
            this.form.PlaneCapacityUD.Enabled = enable;
            this.form.PlanePassengerSeatsUD.Enabled = enable;
            this.form.PlaneReleasedUD.Enabled = enable;
            this.form.PlaneMaintenance.Enabled = enable;
            this.form.RemovePlaneButton.Enabled = enable;
        }

        private void isManufacturerInputsEnabled(bool enable)
        {
            this.form.RemoveManufacturerButton.Enabled = enable;
            this.form.ManufacrurerCountryTextBox.Enabled = enable;
            this.form.ManufacturerNameTextBox.Enabled = enable;
            this.form.ManufacturerFoundedNumericUD.Enabled = enable;
            this.form.ManufacturerPlaneType.Enabled = enable;
        }

        private void isCrewmateInputsEnabled(bool enable)
        {
            this.form.RemoveCrewmateButton.Enabled = enable;
            this.form.CrewmateNameTextBox.Enabled = enable;
            this.form.CrewmateBirthDayDateTimePicker.Enabled = enable;
            this.form.CrewmateFirstFlightDateTimePicker.Enabled = enable;
            this.form.CrewmatePostComboBox.Enabled = enable;
        }

        public List<Plane> readPlanesFromFile()
        {
            using FileStream fs = new FileStream(PLANES_PATH, FileMode.OpenOrCreate);
            using StreamReader sr = new StreamReader(fs);
            return JsonConvert.DeserializeObject<List<Plane>>(sr.ReadToEnd()) ?? new List<Plane>();
        }

        private void planeListToFile(List<Plane> planes)
        {
            using FileStream fs = new(PLANES_PATH, FileMode.Truncate);
            using StreamWriter sw = new(fs);
            sw.Write(JsonConvert.SerializeObject(planes));
        }

        private List<Manufacturer> readManufacturersFromFile()
        {
            using FileStream fs = new FileStream(MANUFACTURERS_PATH, FileMode.OpenOrCreate);
            using StreamReader sr = new StreamReader(fs);
            return JsonConvert.DeserializeObject<List<Manufacturer>>(sr.ReadToEnd()) ?? new List<Manufacturer>();
        }

        private void manufacturersListToFile(List<Manufacturer> manufacturers)
        {
            using FileStream fs = new(MANUFACTURERS_PATH, FileMode.Truncate);
            using StreamWriter sw = new(fs);
            sw.Write(JsonConvert.SerializeObject(manufacturers));
        }
        private void updateCrewComboBox(Plane plane)
        {
            form.CrewmatesComboBox.Items.Clear();
            foreach (CrewMate crewMate in plane.CrewList)
            {
                form.CrewmatesComboBox.Items.Add(crewMate);
            }
            if (plane.CrewList.Count > 0)
                form.CrewmatesComboBox.SelectedIndex = 0;

            if (plane.CrewList.Count < 0)
                isCrewmateInputsEnabled(false);
        }

        private void updateCrewComboBox(Plane plane, int selectedId)
        {
            form.CrewmatesComboBox.Items.Clear();
            foreach (CrewMate crewMate in plane.CrewList)
            {
                form.CrewmatesComboBox.Items.Add(crewMate);
            }
            if (plane.CrewList.Count > 0)
                form.CrewmatesComboBox.SelectedIndex = selectedId;
            if (plane.CrewList.Count < 0)
                isCrewmateInputsEnabled(false);
        }

        private void UpdateManufacturersComboBox(List<Manufacturer> manufacturers)
        {
            form.ManufacturerComboBox.Items.Clear();
            form.ManufacturerComboBox.Items.AddRange(manufacturers.ToArray());
            if (form.PlanesListView.SelectedItems.Count > 0)
            {
                List<Plane> planes = readPlanesFromFile();
                Plane plane = (planes as IEnumerable<Plane>).Where<Plane>(p => p.Id == (form.PlanesListView.SelectedItems[0].Tag as Plane)!.Id).FirstOrDefault()!;
                form.ManufacturerComboBox.SelectedIndex = manufacturers.IndexOf(((manufacturers as IEnumerable<Manufacturer>).Where(m => m.Id == plane.Manufacturer?.Id).FirstOrDefault() as Manufacturer) ?? new Manufacturer());
            }

            if (manufacturers.Count < 0)
                isManufacturerInputsEnabled(false);
        }


        private void UpdateManufacturersComboBox(List<Manufacturer> manufacturers, Plane plane)
        {
            form.ManufacturerComboBox.Items.Clear();
            form.ManufacturerComboBox.Items.AddRange(manufacturers.ToArray());
            if (form.PlanesListView.SelectedItems.Count > 0)
            {
                form.ManufacturerComboBox.SelectedIndex = manufacturers.IndexOf(((manufacturers as IEnumerable<Manufacturer>).Where(m => m.Id == plane.Manufacturer?.Id).FirstOrDefault() as Manufacturer) ?? new Manufacturer());
            }
            if (manufacturers.Count < 0)
                isManufacturerInputsEnabled(false);
        }

        public void updatePlaneView(List<Plane> planes, int selectedIndex = 0)
        {
            if (planes is not null)
            {
                int index = 0;
                form.PlanesListView.Items.Clear();
                foreach (Plane plane in planes)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = plane.Model;
                    item.Tag = plane;
                    if (index == selectedIndex)
                    {
                        item.Selected = true;
                    }
                    form.PlanesListView.Items.Add(item);
                    index++;
                }
            }
        }
        #endregion
    }
}
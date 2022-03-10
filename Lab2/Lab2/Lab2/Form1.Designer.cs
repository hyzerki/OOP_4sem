namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlanesListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlaneModelTextBox = new System.Windows.Forms.TextBox();
            this.PlaneIdentifierTextBox = new System.Windows.Forms.TextBox();
            this.PlaneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AddNewPlaneButton = new System.Windows.Forms.Button();
            this.RemovePlaneButton = new System.Windows.Forms.Button();
            this.ManufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ManufacrurerCountryTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PlaneCapacityUD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.PlanePassengerSeatsUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.PlaneMaintenance = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.PlaneReleasedUD = new System.Windows.Forms.NumericUpDown();
            this.ManufacturerFoundedNumericUD = new System.Windows.Forms.NumericUpDown();
            this.ManufacturerPlaneType = new System.Windows.Forms.CheckedListBox();
            this.RemoveManufacturerButton = new System.Windows.Forms.Button();
            this.AddNewManufacturerButon = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CrewmatesComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CrewmateNameTextBox = new System.Windows.Forms.TextBox();
            this.CrewmatePostComboBox = new System.Windows.Forms.ComboBox();
            this.CrewmateBirthDayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.CrewmateFirstFlightDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddNewCrewmateButton = new System.Windows.Forms.Button();
            this.RemoveCrewmateButton = new System.Windows.Forms.Button();
            this.ManufacturerNameTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneCapacityUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanePassengerSeatsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneReleasedUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManufacturerFoundedNumericUD)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanesListView
            // 
            this.PlanesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PlanesListView.Location = new System.Drawing.Point(12, 12);
            this.PlanesListView.MultiSelect = false;
            this.PlanesListView.Name = "PlanesListView";
            this.PlanesListView.Size = new System.Drawing.Size(366, 462);
            this.PlanesListView.TabIndex = 0;
            this.PlanesListView.UseCompatibleStateImageBehavior = false;
            this.PlanesListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Модель:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Идентификатор:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Тип самолёта";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaneModelTextBox
            // 
            this.PlaneModelTextBox.Location = new System.Drawing.Point(407, 30);
            this.PlaneModelTextBox.Name = "PlaneModelTextBox";
            this.PlaneModelTextBox.Size = new System.Drawing.Size(389, 23);
            this.PlaneModelTextBox.TabIndex = 4;
            this.PlaneModelTextBox.Tag = "PlaneModel";
            // 
            // PlaneIdentifierTextBox
            // 
            this.PlaneIdentifierTextBox.Enabled = false;
            this.PlaneIdentifierTextBox.Location = new System.Drawing.Point(407, 74);
            this.PlaneIdentifierTextBox.Name = "PlaneIdentifierTextBox";
            this.PlaneIdentifierTextBox.Size = new System.Drawing.Size(100, 23);
            this.PlaneIdentifierTextBox.TabIndex = 5;
            // 
            // PlaneTypeComboBox
            // 
            this.PlaneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaneTypeComboBox.FormattingEnabled = true;
            this.PlaneTypeComboBox.Location = new System.Drawing.Point(513, 74);
            this.PlaneTypeComboBox.Name = "PlaneTypeComboBox";
            this.PlaneTypeComboBox.Size = new System.Drawing.Size(155, 23);
            this.PlaneTypeComboBox.TabIndex = 6;
            this.PlaneTypeComboBox.Tag = "PlaneType";
            // 
            // AddNewPlaneButton
            // 
            this.AddNewPlaneButton.Location = new System.Drawing.Point(408, 147);
            this.AddNewPlaneButton.Name = "AddNewPlaneButton";
            this.AddNewPlaneButton.Size = new System.Drawing.Size(143, 23);
            this.AddNewPlaneButton.TabIndex = 7;
            this.AddNewPlaneButton.Text = "Добавить самолёт";
            this.AddNewPlaneButton.UseVisualStyleBackColor = true;
            // 
            // RemovePlaneButton
            // 
            this.RemovePlaneButton.Location = new System.Drawing.Point(557, 147);
            this.RemovePlaneButton.Name = "RemovePlaneButton";
            this.RemovePlaneButton.Size = new System.Drawing.Size(143, 23);
            this.RemovePlaneButton.TabIndex = 8;
            this.RemovePlaneButton.Text = "Удалить самолёт";
            this.RemovePlaneButton.UseVisualStyleBackColor = true;
            // 
            // ManufacturerComboBox
            // 
            this.ManufacturerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ManufacturerComboBox.FormattingEnabled = true;
            this.ManufacturerComboBox.Location = new System.Drawing.Point(407, 201);
            this.ManufacturerComboBox.Name = "ManufacturerComboBox";
            this.ManufacturerComboBox.Size = new System.Drawing.Size(121, 23);
            this.ManufacturerComboBox.TabIndex = 9;
            this.ManufacturerComboBox.Tag = "Manufacturer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Производитель:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Страна:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(701, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Основан:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManufacrurerCountryTextBox
            // 
            this.ManufacrurerCountryTextBox.Location = new System.Drawing.Point(539, 248);
            this.ManufacrurerCountryTextBox.Name = "ManufacrurerCountryTextBox";
            this.ManufacrurerCountryTextBox.Size = new System.Drawing.Size(100, 23);
            this.ManufacrurerCountryTextBox.TabIndex = 13;
            this.ManufacrurerCountryTextBox.Tag = "ManufacturerCountry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Мест:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaneCapacityUD
            // 
            this.PlaneCapacityUD.Location = new System.Drawing.Point(674, 74);
            this.PlaneCapacityUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PlaneCapacityUD.Name = "PlaneCapacityUD";
            this.PlaneCapacityUD.Size = new System.Drawing.Size(122, 23);
            this.PlaneCapacityUD.TabIndex = 16;
            this.PlaneCapacityUD.Tag = "PlaneCapacity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(674, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Грузоподъёмность:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlanePassengerSeatsUD
            // 
            this.PlanePassengerSeatsUD.Location = new System.Drawing.Point(408, 118);
            this.PlanePassengerSeatsUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PlanePassengerSeatsUD.Name = "PlanePassengerSeatsUD";
            this.PlanePassengerSeatsUD.Size = new System.Drawing.Size(74, 23);
            this.PlanePassengerSeatsUD.TabIndex = 19;
            this.PlanePassengerSeatsUD.Tag = "PlaneSeats";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Год Выпуска:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaneMaintenance
            // 
            this.PlaneMaintenance.Location = new System.Drawing.Point(601, 118);
            this.PlaneMaintenance.Name = "PlaneMaintenance";
            this.PlaneMaintenance.Size = new System.Drawing.Size(128, 23);
            this.PlaneMaintenance.TabIndex = 22;
            this.PlaneMaintenance.Tag = "PlaneMaintenance";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(601, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Дата последнего ТО:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaneReleasedUD
            // 
            this.PlaneReleasedUD.Location = new System.Drawing.Point(495, 118);
            this.PlaneReleasedUD.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PlaneReleasedUD.Name = "PlaneReleasedUD";
            this.PlaneReleasedUD.Size = new System.Drawing.Size(100, 23);
            this.PlaneReleasedUD.TabIndex = 24;
            this.PlaneReleasedUD.Tag = "PlaneReleased";
            // 
            // ManufacturerFoundedNumericUD
            // 
            this.ManufacturerFoundedNumericUD.Location = new System.Drawing.Point(701, 202);
            this.ManufacturerFoundedNumericUD.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ManufacturerFoundedNumericUD.Name = "ManufacturerFoundedNumericUD";
            this.ManufacturerFoundedNumericUD.Size = new System.Drawing.Size(95, 23);
            this.ManufacturerFoundedNumericUD.TabIndex = 25;
            this.ManufacturerFoundedNumericUD.Tag = "ManufacturerFounded";
            // 
            // ManufacturerPlaneType
            // 
            this.ManufacturerPlaneType.CheckOnClick = true;
            this.ManufacturerPlaneType.FormattingEnabled = true;
            this.ManufacturerPlaneType.Location = new System.Drawing.Point(407, 230);
            this.ManufacturerPlaneType.Name = "ManufacturerPlaneType";
            this.ManufacturerPlaneType.Size = new System.Drawing.Size(120, 58);
            this.ManufacturerPlaneType.TabIndex = 26;
            this.ManufacturerPlaneType.Tag = "ManufacturerPlaneType";
            // 
            // RemoveManufacturerButton
            // 
            this.RemoveManufacturerButton.Location = new System.Drawing.Point(483, 293);
            this.RemoveManufacturerButton.Name = "RemoveManufacturerButton";
            this.RemoveManufacturerButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveManufacturerButton.TabIndex = 27;
            this.RemoveManufacturerButton.Text = "Убрать";
            this.RemoveManufacturerButton.UseVisualStyleBackColor = true;
            // 
            // AddNewManufacturerButon
            // 
            this.AddNewManufacturerButon.Location = new System.Drawing.Point(407, 294);
            this.AddNewManufacturerButon.Name = "AddNewManufacturerButon";
            this.AddNewManufacturerButon.Size = new System.Drawing.Size(75, 23);
            this.AddNewManufacturerButon.TabIndex = 27;
            this.AddNewManufacturerButon.Text = "Добавить";
            this.AddNewManufacturerButon.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(539, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "ФИО";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(407, 364);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Должность:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(536, 364);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "Родился:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CrewmatesComboBox
            // 
            this.CrewmatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CrewmatesComboBox.FormattingEnabled = true;
            this.CrewmatesComboBox.Location = new System.Drawing.Point(407, 338);
            this.CrewmatesComboBox.Name = "CrewmatesComboBox";
            this.CrewmatesComboBox.Size = new System.Drawing.Size(121, 23);
            this.CrewmatesComboBox.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(407, 320);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Члены экипажа:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CrewmateNameTextBox
            // 
            this.CrewmateNameTextBox.Location = new System.Drawing.Point(539, 338);
            this.CrewmateNameTextBox.Name = "CrewmateNameTextBox";
            this.CrewmateNameTextBox.Size = new System.Drawing.Size(257, 23);
            this.CrewmateNameTextBox.TabIndex = 30;
            this.CrewmateNameTextBox.Tag = "CrewmateFullName";
            // 
            // CrewmatePostComboBox
            // 
            this.CrewmatePostComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CrewmatePostComboBox.FormattingEnabled = true;
            this.CrewmatePostComboBox.Location = new System.Drawing.Point(409, 382);
            this.CrewmatePostComboBox.Name = "CrewmatePostComboBox";
            this.CrewmatePostComboBox.Size = new System.Drawing.Size(121, 23);
            this.CrewmatePostComboBox.TabIndex = 31;
            this.CrewmatePostComboBox.Tag = "CrewmatePost";
            // 
            // CrewmateBirthDayDateTimePicker
            // 
            this.CrewmateBirthDayDateTimePicker.Location = new System.Drawing.Point(536, 382);
            this.CrewmateBirthDayDateTimePicker.Name = "CrewmateBirthDayDateTimePicker";
            this.CrewmateBirthDayDateTimePicker.Size = new System.Drawing.Size(132, 23);
            this.CrewmateBirthDayDateTimePicker.TabIndex = 32;
            this.CrewmateBirthDayDateTimePicker.Tag = "CrewmateBdate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(674, 364);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 15);
            this.label15.TabIndex = 28;
            this.label15.Text = "Первый вылет:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CrewmateFirstFlightDateTimePicker
            // 
            this.CrewmateFirstFlightDateTimePicker.Location = new System.Drawing.Point(674, 382);
            this.CrewmateFirstFlightDateTimePicker.Name = "CrewmateFirstFlightDateTimePicker";
            this.CrewmateFirstFlightDateTimePicker.Size = new System.Drawing.Size(122, 23);
            this.CrewmateFirstFlightDateTimePicker.TabIndex = 32;
            this.CrewmateFirstFlightDateTimePicker.Tag = "CrewmateFirstFlight";
            // 
            // AddNewCrewmateButton
            // 
            this.AddNewCrewmateButton.Location = new System.Drawing.Point(407, 411);
            this.AddNewCrewmateButton.Name = "AddNewCrewmateButton";
            this.AddNewCrewmateButton.Size = new System.Drawing.Size(75, 23);
            this.AddNewCrewmateButton.TabIndex = 33;
            this.AddNewCrewmateButton.Text = "Добавить";
            this.AddNewCrewmateButton.UseVisualStyleBackColor = true;
            // 
            // RemoveCrewmateButton
            // 
            this.RemoveCrewmateButton.Location = new System.Drawing.Point(488, 411);
            this.RemoveCrewmateButton.Name = "RemoveCrewmateButton";
            this.RemoveCrewmateButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveCrewmateButton.TabIndex = 34;
            this.RemoveCrewmateButton.Text = "Убрать";
            this.RemoveCrewmateButton.UseVisualStyleBackColor = true;
            // 
            // ManufacturerNameTextBox
            // 
            this.ManufacturerNameTextBox.Location = new System.Drawing.Point(539, 201);
            this.ManufacturerNameTextBox.Name = "ManufacturerNameTextBox";
            this.ManufacturerNameTextBox.Size = new System.Drawing.Size(156, 23);
            this.ManufacturerNameTextBox.TabIndex = 35;
            this.ManufacturerNameTextBox.Tag = "ManufacturerName";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(539, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 15);
            this.label16.TabIndex = 10;
            this.label16.Text = "Производитель:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.ManufacturerNameTextBox);
            this.Controls.Add(this.RemoveCrewmateButton);
            this.Controls.Add(this.AddNewCrewmateButton);
            this.Controls.Add(this.CrewmateFirstFlightDateTimePicker);
            this.Controls.Add(this.CrewmateBirthDayDateTimePicker);
            this.Controls.Add(this.CrewmatePostComboBox);
            this.Controls.Add(this.CrewmateNameTextBox);
            this.Controls.Add(this.CrewmatesComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AddNewManufacturerButon);
            this.Controls.Add(this.RemoveManufacturerButton);
            this.Controls.Add(this.ManufacturerPlaneType);
            this.Controls.Add(this.ManufacturerFoundedNumericUD);
            this.Controls.Add(this.PlaneReleasedUD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PlaneMaintenance);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PlanePassengerSeatsUD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PlaneCapacityUD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ManufacrurerCountryTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ManufacturerComboBox);
            this.Controls.Add(this.RemovePlaneButton);
            this.Controls.Add(this.AddNewPlaneButton);
            this.Controls.Add(this.PlaneTypeComboBox);
            this.Controls.Add(this.PlaneIdentifierTextBox);
            this.Controls.Add(this.PlaneModelTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlanesListView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PlaneCapacityUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanePassengerSeatsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaneReleasedUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManufacturerFoundedNumericUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        public DateTimePicker CrewmateFirstFlightDateTimePicker;
        public Button AddNewCrewmateButton;
        public Button RemoveCrewmateButton;
        public ListView PlanesListView;
        public TextBox PlaneModelTextBox;
        public TextBox PlaneIdentifierTextBox;
        public ComboBox PlaneTypeComboBox;
        public Button AddNewPlaneButton;
        public Button RemovePlaneButton;
        public ComboBox ManufacturerComboBox;
        public TextBox ManufacrurerCountryTextBox;
        public NumericUpDown PlaneCapacityUD;
        public NumericUpDown PlanePassengerSeatsUD;
        public DateTimePicker PlaneMaintenance;
        public NumericUpDown PlaneReleasedUD;
        public NumericUpDown ManufacturerFoundedNumericUD;
        public CheckedListBox ManufacturerPlaneType;
        public Button RemoveManufacturerButton;
        public Button AddNewManufacturerButon;
        public ComboBox CrewmatesComboBox;
        public TextBox CrewmateNameTextBox;
        public ComboBox CrewmatePostComboBox;
        public DateTimePicker CrewmateBirthDayDateTimePicker;
        private Label label16;
        public TextBox ManufacturerNameTextBox;
    }
}
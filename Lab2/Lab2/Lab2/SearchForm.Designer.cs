namespace Lab2
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SortPlanesByComboBox = new System.Windows.Forms.ComboBox();
            this.SearchPlaneByCapacityUD = new System.Windows.Forms.NumericUpDown();
            this.SearchPlaneBySeatsUD = new System.Windows.Forms.NumericUpDown();
            this.SearcPlaneByTypeListBox = new System.Windows.Forms.CheckedListBox();
            this.SearchPlaneButton = new System.Windows.Forms.Button();
            this.SearchPlaneTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPlaneByCapacityUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPlaneBySeatsUD)).BeginInit();
            this.SuspendLayout();
            // 
            // SortPlanesByComboBox
            // 
            this.SortPlanesByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortPlanesByComboBox.FormattingEnabled = true;
            this.SortPlanesByComboBox.Location = new System.Drawing.Point(138, 70);
            this.SortPlanesByComboBox.Name = "SortPlanesByComboBox";
            this.SortPlanesByComboBox.Size = new System.Drawing.Size(159, 23);
            this.SortPlanesByComboBox.TabIndex = 49;
            // 
            // SearchPlaneByCapacityUD
            // 
            this.SearchPlaneByCapacityUD.Location = new System.Drawing.Point(113, 41);
            this.SearchPlaneByCapacityUD.Name = "SearchPlaneByCapacityUD";
            this.SearchPlaneByCapacityUD.Size = new System.Drawing.Size(54, 23);
            this.SearchPlaneByCapacityUD.TabIndex = 48;
            // 
            // SearchPlaneBySeatsUD
            // 
            this.SearchPlaneBySeatsUD.Location = new System.Drawing.Point(12, 41);
            this.SearchPlaneBySeatsUD.Name = "SearchPlaneBySeatsUD";
            this.SearchPlaneBySeatsUD.Size = new System.Drawing.Size(54, 23);
            this.SearchPlaneBySeatsUD.TabIndex = 47;
            // 
            // SearcPlaneByTypeListBox
            // 
            this.SearcPlaneByTypeListBox.CheckOnClick = true;
            this.SearcPlaneByTypeListBox.FormattingEnabled = true;
            this.SearcPlaneByTypeListBox.Location = new System.Drawing.Point(12, 70);
            this.SearcPlaneByTypeListBox.Name = "SearcPlaneByTypeListBox";
            this.SearcPlaneByTypeListBox.Size = new System.Drawing.Size(120, 58);
            this.SearcPlaneByTypeListBox.TabIndex = 46;
            // 
            // SearchPlaneButton
            // 
            this.SearchPlaneButton.Location = new System.Drawing.Point(12, 134);
            this.SearchPlaneButton.Name = "SearchPlaneButton";
            this.SearchPlaneButton.Size = new System.Drawing.Size(75, 23);
            this.SearchPlaneButton.TabIndex = 45;
            this.SearchPlaneButton.Text = "Найти";
            this.SearchPlaneButton.UseVisualStyleBackColor = true;
            this.SearchPlaneButton.Click += new System.EventHandler(this.SearchPlaneButton_Click);
            // 
            // SearchPlaneTextBox
            // 
            this.SearchPlaneTextBox.Location = new System.Drawing.Point(12, 12);
            this.SearchPlaneTextBox.Name = "SearchPlaneTextBox";
            this.SearchPlaneTextBox.Size = new System.Drawing.Size(285, 23);
            this.SearchPlaneTextBox.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(173, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 15);
            this.label18.TabIndex = 42;
            this.label18.Text = "Тонн";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(72, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 15);
            this.label17.TabIndex = 43;
            this.label17.Text = "Мест";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 169);
            this.Controls.Add(this.SortPlanesByComboBox);
            this.Controls.Add(this.SearchPlaneByCapacityUD);
            this.Controls.Add(this.SearchPlaneBySeatsUD);
            this.Controls.Add(this.SearcPlaneByTypeListBox);
            this.Controls.Add(this.SearchPlaneButton);
            this.Controls.Add(this.SearchPlaneTextBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.SearchPlaneByCapacityUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPlaneBySeatsUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComboBox SortPlanesByComboBox;
        public NumericUpDown SearchPlaneByCapacityUD;
        public NumericUpDown SearchPlaneBySeatsUD;
        public CheckedListBox SearcPlaneByTypeListBox;
        public Button SearchPlaneButton;
        public TextBox SearchPlaneTextBox;
        private Label label18;
        private Label label17;
    }
}
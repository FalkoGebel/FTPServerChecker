namespace CheckerUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ServerNameLabel = new Label();
            UserIdLabel = new Label();
            ConnectButton = new Button();
            PasswordLabel = new Label();
            UseSslLabel = new Label();
            ServerNameTextBox = new TextBox();
            UserIdTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UseSslCheckBox = new CheckBox();
            OutputTextBox = new TextBox();
            SaveDataCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // ServerNameLabel
            // 
            resources.ApplyResources(ServerNameLabel, "ServerNameLabel");
            ServerNameLabel.Name = "ServerNameLabel";
            // 
            // UserIdLabel
            // 
            resources.ApplyResources(UserIdLabel, "UserIdLabel");
            UserIdLabel.Name = "UserIdLabel";
            // 
            // ConnectButton
            // 
            resources.ApplyResources(ConnectButton, "ConnectButton");
            ConnectButton.Name = "ConnectButton";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // PasswordLabel
            // 
            resources.ApplyResources(PasswordLabel, "PasswordLabel");
            PasswordLabel.Name = "PasswordLabel";
            // 
            // UseSslLabel
            // 
            resources.ApplyResources(UseSslLabel, "UseSslLabel");
            UseSslLabel.Name = "UseSslLabel";
            // 
            // ServerNameTextBox
            // 
            resources.ApplyResources(ServerNameTextBox, "ServerNameTextBox");
            ServerNameTextBox.BackColor = Color.FromArgb(53, 53, 53);
            ServerNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            ServerNameTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            ServerNameTextBox.Name = "ServerNameTextBox";
            // 
            // UserIdTextBox
            // 
            resources.ApplyResources(UserIdTextBox, "UserIdTextBox");
            UserIdTextBox.BackColor = Color.FromArgb(53, 53, 53);
            UserIdTextBox.BorderStyle = BorderStyle.FixedSingle;
            UserIdTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            UserIdTextBox.Name = "UserIdTextBox";
            // 
            // PasswordTextBox
            // 
            resources.ApplyResources(PasswordTextBox, "PasswordTextBox");
            PasswordTextBox.BackColor = Color.FromArgb(53, 53, 53);
            PasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            PasswordTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UseSslCheckBox
            // 
            resources.ApplyResources(UseSslCheckBox, "UseSslCheckBox");
            UseSslCheckBox.Name = "UseSslCheckBox";
            UseSslCheckBox.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            resources.ApplyResources(OutputTextBox, "OutputTextBox");
            OutputTextBox.BackColor = Color.FromArgb(112, 140, 117);
            OutputTextBox.BorderStyle = BorderStyle.None;
            OutputTextBox.ForeColor = Color.FromArgb(14, 14, 14);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.TabStop = false;
            // 
            // SaveDataCheckBox
            // 
            resources.ApplyResources(SaveDataCheckBox, "SaveDataCheckBox");
            SaveDataCheckBox.Name = "SaveDataCheckBox";
            SaveDataCheckBox.TabStop = false;
            SaveDataCheckBox.UseVisualStyleBackColor = true;
            SaveDataCheckBox.CheckedChanged += SaveDataCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(SaveDataCheckBox);
            Controls.Add(OutputTextBox);
            Controls.Add(UseSslCheckBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserIdTextBox);
            Controls.Add(ServerNameTextBox);
            Controls.Add(UseSslLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(ConnectButton);
            Controls.Add(UserIdLabel);
            Controls.Add(ServerNameLabel);
            ForeColor = Color.FromArgb(87, 255, 93);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ServerNameLabel;
        private Label UserIdLabel;
        private Button ConnectButton;
        private Label PasswordLabel;
        private Label UseSslLabel;
        private TextBox ServerNameTextBox;
        private TextBox UserIdTextBox;
        private TextBox PasswordTextBox;
        private CheckBox UseSslCheckBox;
        private TextBox OutputTextBox;
        private CheckBox SaveDataCheckBox;
    }
}
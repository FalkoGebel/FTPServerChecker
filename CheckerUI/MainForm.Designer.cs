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
            ServerNameLabel.AutoSize = true;
            ServerNameLabel.Location = new Point(12, 9);
            ServerNameLabel.Name = "ServerNameLabel";
            ServerNameLabel.Size = new Size(117, 19);
            ServerNameLabel.TabIndex = 0;
            ServerNameLabel.Text = "Server Name:";
            // 
            // UserIdLabel
            // 
            UserIdLabel.AutoSize = true;
            UserIdLabel.Location = new Point(12, 38);
            UserIdLabel.Name = "UserIdLabel";
            UserIdLabel.Size = new Size(81, 19);
            UserIdLabel.TabIndex = 1;
            UserIdLabel.Text = "User ID:";
            // 
            // ConnectButton
            // 
            ConnectButton.AutoSize = true;
            ConnectButton.FlatStyle = FlatStyle.Flat;
            ConnectButton.Location = new Point(488, 318);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(84, 31);
            ConnectButton.TabIndex = 2;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 66);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(90, 19);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password:";
            // 
            // UseSslLabel
            // 
            UseSslLabel.AutoSize = true;
            UseSslLabel.Location = new Point(12, 94);
            UseSslLabel.Name = "UseSslLabel";
            UseSslLabel.Size = new Size(81, 19);
            UseSslLabel.TabIndex = 4;
            UseSslLabel.Text = "Use SSL:";
            // 
            // ServerNameTextBox
            // 
            ServerNameTextBox.BackColor = Color.FromArgb(53, 53, 53);
            ServerNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            ServerNameTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            ServerNameTextBox.Location = new Point(135, 7);
            ServerNameTextBox.Name = "ServerNameTextBox";
            ServerNameTextBox.Size = new Size(437, 26);
            ServerNameTextBox.TabIndex = 5;
            ServerNameTextBox.Text = "<server name>";
            // 
            // UserIdTextBox
            // 
            UserIdTextBox.BackColor = Color.FromArgb(53, 53, 53);
            UserIdTextBox.BorderStyle = BorderStyle.FixedSingle;
            UserIdTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            UserIdTextBox.Location = new Point(135, 36);
            UserIdTextBox.Name = "UserIdTextBox";
            UserIdTextBox.Size = new Size(437, 26);
            UserIdTextBox.TabIndex = 6;
            UserIdTextBox.Text = "<user id>";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = Color.FromArgb(53, 53, 53);
            PasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
            PasswordTextBox.ForeColor = Color.FromArgb(87, 255, 93);
            PasswordTextBox.Location = new Point(135, 64);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(437, 26);
            PasswordTextBox.TabIndex = 7;
            PasswordTextBox.Text = "<password>";
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UseSslCheckBox
            // 
            UseSslCheckBox.FlatStyle = FlatStyle.Popup;
            UseSslCheckBox.Location = new Point(135, 94);
            UseSslCheckBox.Name = "UseSslCheckBox";
            UseSslCheckBox.Size = new Size(13, 19);
            UseSslCheckBox.TabIndex = 8;
            UseSslCheckBox.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = Color.FromArgb(112, 140, 117);
            OutputTextBox.BorderStyle = BorderStyle.None;
            OutputTextBox.ForeColor = Color.FromArgb(14, 14, 14);
            OutputTextBox.Location = new Point(12, 128);
            OutputTextBox.Multiline = true;
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.Size = new Size(560, 184);
            OutputTextBox.TabIndex = 9;
            OutputTextBox.TabStop = false;
            OutputTextBox.Text = "<output>";
            // 
            // SaveDataCheckBox
            // 
            SaveDataCheckBox.AutoSize = true;
            SaveDataCheckBox.FlatStyle = FlatStyle.Popup;
            SaveDataCheckBox.Location = new Point(12, 324);
            SaveDataCheckBox.Name = "SaveDataCheckBox";
            SaveDataCheckBox.Size = new Size(107, 23);
            SaveDataCheckBox.TabIndex = 10;
            SaveDataCheckBox.TabStop = false;
            SaveDataCheckBox.Text = "Save Data";
            SaveDataCheckBox.UseVisualStyleBackColor = true;
            SaveDataCheckBox.CheckedChanged += SaveDataCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            ClientSize = new Size(584, 361);
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
            Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(87, 255, 93);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FTP Server Checker";
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
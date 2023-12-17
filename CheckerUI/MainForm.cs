using CheckerLibrary;
using CheckerLibraryHelpers;

namespace CheckerUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        /// <summary>
        /// Calls FtpConnection test functionality with the given inputs and sets result to output.
        /// </summary>
        private void TestConnection()
        {
            FtpConnection ftpConnection = CreateFtpConnectionFromForm();

            OutputTextBox.Clear();
            foreach (var line in ftpConnection.TestConnection().Split("\n"))
            {
                if (OutputTextBox.Text != "")
                    OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText(line);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataToFile();
        }

        /// <summary>
        /// Saves the form data to the save file, if the check box is set
        /// </summary>
        private void SaveDataToFile()
        {
            if (!SaveDataCheckBox.Checked)
                return;

            FtpConnection ftpConnection = CreateFtpConnectionFromForm();

            CheckerLibraryHelpers.CheckerLibraryHelpers.SaveToSaveFile(ftpConnection.CreateFileString());
        }

        /// <summary>
        /// Creates and returns and FTP Connection from the fields in the form.
        /// </summary>
        /// <returns>The created FTP Connection.</returns>
        private FtpConnection CreateFtpConnectionFromForm()
        {
            return new FtpConnection()
            {
                ServerName = ServerNameTextBox.Text,
                UserId = UserIdTextBox.Text,
                Password = PasswordTextBox.Text,
                UseSsl = UseSslCheckBox.Checked
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FtpConnection? ftpConnection = CheckerLibraryHelpers.CheckerLibraryHelpers.LoadFromSaveFile()
                .CreateFtpConnectionFromFileString();

            if (ftpConnection != null)
            {
                ServerNameTextBox.Text = ftpConnection.ServerName;
                UserIdTextBox.Text = ftpConnection.UserId;
                PasswordTextBox.Text = ftpConnection.Password;
                UseSslCheckBox.Checked = ftpConnection.UseSsl;
                SaveDataCheckBox.Checked = true;
            }
        }

        private void SaveDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DeleteSaveDataFile();
        }

        /// <summary>
        /// Deletes save date file if check box is not set.
        /// </summary>
        private void DeleteSaveDataFile()
        {
            if (!SaveDataCheckBox.Checked)
            {
                CheckerLibraryHelpers.CheckerLibraryHelpers.DeleteSaveFile();
            }
        }
    }
}

using CheckerLibrary;

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
            FtpConnection ftpConnection = new()
            {
                ServerName = ServerNameTextBox.Text,
                UserId = UserIdTextBox.Text,
                Password = PasswordTextBox.Text,
                UseSsl = UseSslCheckBox.Checked
            };

            OutputTextBox.Clear();
            foreach (var line in ftpConnection.TestConnection().Split("\n"))
            {
                if (OutputTextBox.Text != "")
                    OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText(line);
            }
        }
    }
}

using RSAPseRandoCrypter;

namespace RSAPseRandoCrypterGUI
{
    public partial class MainForm : Form
    {
        private readonly Crypter _crypter;

        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _crypter = new Crypter();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            var openKey = OpenKeyTextBox.Text;
            MessageTextBox.Text = _crypter.Encrypt(MessageTextBox.Text, openKey);
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            var secretKey = SecretKeyTextBox.Text;
            MessageTextBox.Text = _crypter.Decrypt(MessageTextBox.Text, secretKey);
        }

        private void GenerateKeysButton_Click(object sender, EventArgs e)
        {
            var keys = _crypter.GenerateKeys();
            OpenKeyTextBox.Text = keys.OpenKey;
            SecretKeyTextBox.Text = keys.SecretKey;
        }
    }
}
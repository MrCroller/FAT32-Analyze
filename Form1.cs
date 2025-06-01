namespace CCAA
{

    public partial class Form1 : Form
    {
        public delegate void TryStart(string sourcePath, string destPath);
        public TryStart OnTryStart;

        public Form1()
        {
            InitializeComponent();
        }

        #region Handlers

        private void OriginPathField_MouseDoubleClickAsync(object sender, MouseEventArgs e)
        {
            OriginPathField.Text = SelectExplorerFolder();
        }

        private void TargetPathField_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TargetPathField.Text = SelectExplorerFolder();
        }
        
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            OnTryStart?.Invoke(OriginPathField.Text, TargetPathField.Text);
        }

        #endregion

        public void ShowProgress(string progress)
        {
            progressLabel.Text = progress;
        }
        
        public void ShowProgress(double progress)
        {
            int progressInt = (int)(progress * 100);
            progressBar.Value = progressInt;
        }


        private string SelectExplorerFolder()
        {
            using var folderDialog = new FolderBrowserDialog();
            // ��������� �������
            folderDialog.Description = "�������� �����";
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderDialog.ShowNewFolderButton = true; // ��������� �������� ����� �����

            DialogResult result = folderDialog.ShowDialog();

            // ��������� ������ � ���������, ����� �� ������������ OK
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                return folderDialog.SelectedPath; // ���������� ���� � ��������� �����
            }
            return string.Empty;
        }
    }
}
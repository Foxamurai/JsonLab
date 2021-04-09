using System.IO;
using System.Windows.Forms;

namespace Json
{
    class FileSelector
    {
        private OpenFileDialog openFileDialog;
        private string fileContent;
        private string filePath;

        public FileSelector()
        {
            this.openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
        }

        public void selectFile() 
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
        }

        public string getFilePath() {
            return filePath;
        }

        public string getFileContent()
        {
            return fileContent;
        }

    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;

namespace Json
{
    class FileSelector
    {
        private OpenFileDialog openFileDialog;
        private JObject content;
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

                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    var reader = new JsonTextReader(streamReader);
                    content = JObject.Load(reader);
                }
            }
        }

        public string getFilePath() {
            return filePath;
        }

        public JObject getContent()
        {
            return content;
        }

        
    }
}

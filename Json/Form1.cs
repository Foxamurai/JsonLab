using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace Json
{
    public partial class Form1 : Form
    {
        JObject json;
        public Form1()
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader(@"C:\Users\Foxamurai\source\repos\Foxamurai\JsonLab\Json\Res\ОПОП.json"))
            {
                var reader = new JsonTextReader(streamReader);
                json = JObject.Load(reader);
            }
        }        

        private void btnP1Ex1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Ex1().getProfStandarts(json);
        }
    }
}

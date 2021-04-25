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
        Services services;
        public Form1()
        {
            InitializeComponent();
            using (StreamReader streamReader = new StreamReader(@"C:\Users\Foxamurai\source\repos\Json\Json\Res\ОПОП.json"))
            {
                var reader = new JsonTextReader(streamReader);
                json = JObject.Load(reader);
            }
            services = new Services();
            cbP1Ex2.Items.AddRange(services.getCompetenciesEx2(json));
        }        

        private void btnP1Ex1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Ex1().getProfStandarts(json);
        }

        private void btnP1Ex2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Ex2().getCompitencyIndicators(json, cbP1Ex2.SelectedItem.ToString());
        }
    }
}

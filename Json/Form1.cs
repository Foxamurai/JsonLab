using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;
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
            cbP1Ex3.Items.AddRange(services.getSubjectsEx3(json));
            var terms = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            cbP1Ex4.Items.AddRange(terms.Cast<object>().ToArray());
            var courses = new int[4] { 1, 2, 3, 4 };
            cbP1Ex5.Items.AddRange(courses.Cast<object>().ToArray());
        }        

        private void btnP1Ex1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = new Ex1().getProfStandarts(json);
        }

        private void btnP1Ex2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = new Ex2().getCompitencyIndicators(json, cbP1Ex2.SelectedItem.ToString());
        }

        private void btnP1Ex3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = new Ex3().getSubjectInfo(json, cbP1Ex3.SelectedItem.ToString());
        }

        private void btnP1Ex4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = new Ex4().getSubjectsEx4(json, int.Parse(cbP1Ex4.SelectedItem.ToString()));
        }

        private void btnP1Ex5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DataTable();
            dataGridView1.DataSource = new Ex5().getEducationalProccessEx5(json, int.Parse(cbP1Ex5.SelectedItem.ToString()));
        }
    }
}

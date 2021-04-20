using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json
{
    public partial class Form1 : Form
    {
        FileSelector fileSelector;
        public Form1()
        {
            InitializeComponent();
            fileSelector = new FileSelector();
        }

        private void btnP1SelectFile_Click(object sender, EventArgs e)
        {
            fileSelector.selectFile();
            tbP1filePath.Text = fileSelector.getFilePath();
        }

        private void btnP1Ex1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Ex1().getProfStandarts(fileSelector.getContent());
        }
    }
}

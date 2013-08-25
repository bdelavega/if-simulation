using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulator
{
    public partial class Form1 : Form
    {
        IncrementalSimulator _sim;
           
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numDays = (int) numDaysOfHourlies.Value;
            int numBackups = (int) numBackupsPerHour.Value;

            _sim = new IncrementalSimulator(this.CreateGraphics(), numDays, numBackups);
            _sim.WorkerSupportsCancellation = true;
            _sim.WorkerReportsProgress = false;

            if (_sim.IsBusy != true)
            {
                _sim.RunWorkerAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_sim != null)
                _sim.CancelAsync();
        }
    }
}

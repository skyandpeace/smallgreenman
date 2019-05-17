using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace green_people
{
    public partial class frmsmallgreenman : Form
    {
        public frmsmallgreenman()
        {
            InitializeComponent();
        }
        int imgindex = 1;
        int passtime;

        private void frmsmallgreenman_Load(object sender, EventArgs e)
        {
            picsmallgreenman.Image = imgsmallgreenman.Images[0];
            btnstop.Enabled = false;
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            passtime=0;
            tmrsmallgreenman.Enabled = true;
            tmrsmallgreenman.Interval = 500;
            btnstart.Enabled = false;
            btnstop.Enabled = true;
        }

        private void tmrsmallgreenman_Tick(object sender, EventArgs e)
        {
            passtime += tmrsmallgreenman.Interval;
            if (passtime == 60000)
            {
                btnstop.PerformClick();
                return;
            }
            else if (passtime >= 50000)
                tmrsmallgreenman.Interval = 100;
            else if (passtime >= 30000)
                tmrsmallgreenman.Interval = 200;

            picsmallgreenman.Image = imgsmallgreenman.Images[imgindex];
            imgindex++;
            imgindex = imgindex % 7;
            if (imgindex == 0)
                imgindex = 1;
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            tmrsmallgreenman.Enabled = false;
            picsmallgreenman.Image = imgsmallgreenman.Images[0];
            btnstop.Enabled = false;
            btnstart.Enabled = true;
        }


    }
}

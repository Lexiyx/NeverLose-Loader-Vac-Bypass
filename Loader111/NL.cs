using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverLose
{
    public partial class NL : Form
    {
        public NL()
        {

            InitializeComponent();
           
        }

        private void Cheap_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // kill steam
            foreach (var process in Process.GetProcessesByName("steam"))
            {
                process.Kill();
               
            }

           
            // and then go to loading screen
            LOAD main = new LOAD();
            this.Hide();
            main.Show();
        


        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        Point lastPoint;

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

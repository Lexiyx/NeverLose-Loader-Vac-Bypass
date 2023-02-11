using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using Bypass;

namespace NeverLose
{
    public partial class LOAD : Form
    {
        public LOAD()
        {

            InitializeComponent();


            // start timer which downloads dll and start injector
            timer1.Enabled = true;
        }

        private void Cheap_Load(object sender, EventArgs e)
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();


            string dll = @"C:\Windows\Web\dll.dll";

            var client = new WebClient();

            // check if dll exists
            // it does not exist so download
            // replace the download link with your dll
            if (!Directory.Exists(dll))
            {
                client.DownloadFile("https://google.com/cheat.dll", dll);
            }

            // check if dll exists
            // i used discord link as example
            // you can use your own upload which is better
            // also it deletes the old dll so the hack is on newest version, but there is one require
            // the link should be static, so you can replace the dll without downloading new loader
            // but then you also have to change the label "Version:" you can do it with pastebin actually
            // you just have to make the loader stream the text from pastebin raw by reading the post
            if (Directory.Exists(dll))
            {
                Directory.Delete(dll);
                client.DownloadFile("https://google.com/cheat.dll", dll);
            }

            // start secound timer more info is under
            timer2.Start();

            // so lets inject now :)
            Bypass.Bypass.Run();

            // stop the timer so it wont spamming downloading dll´s
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // The loader should hide when the game starts :)

            Process[] processes = Process.GetProcessesByName("csgo");

            if (processes.Length == 0)
            {
                // we are waiting until the game starts and making a loop
                return; // returning for the loop

            }
            else
            {
                // game was found and we are hiding now
                this.Hide();
            }
        }
    }
}

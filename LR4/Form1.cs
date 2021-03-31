using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4
{
    public partial class Form1 : Form
    {
        private Mp3Player mp3Player;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                dlgOpen.Filter = "Mp3 File|*.mp3";
                dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if(dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mp3Player = new Mp3Player(dlgOpen.FileName);
                    mp3Player.Repeat = true;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (mp3Player != null)
                mp3Player.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mp3Player != null)
                mp3Player.Stop();
        }
    }
}

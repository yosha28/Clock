using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
        
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }


        }
    }
}

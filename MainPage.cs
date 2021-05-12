using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register frm4 = new Register(this);
            frm4.Show();
            this.Hide();
        }
    }
}

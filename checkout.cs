using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }
        public checkout(List<string> value, string time, string moviename, string theatername, string username)
        {

            InitializeComponent();
            this.Value = value;
            this.Time = time;
            this.Moviename = moviename;
            this.Theatername = theatername;
            this.Username = username;
            
        }
        public List<string> Value { get; set; }
        public string Time { get; set; }
        public string Moviename { get; set; }

        public string Username { get; set; }
        public string Theatername { get; set; }

        private Theater mainForm = null;
        public checkout(Form callingForm)
        {
            mainForm = callingForm as Theater;
            InitializeComponent();
        }
        private void checkout_Load(object sender, EventArgs e)
        {
            string seatstring = "";
            label6.Text = Username;
            label7.Text = Moviename;
            label10.Text = Theatername;
            for(int i = 0; i< Value.Count; i++)
            {
                seatstring += Value[i] + " ";

            }
            label9.Text = seatstring;
            label8.Text = "" + Value.Count * 15 + "$";
            label18.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

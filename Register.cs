using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private MainMenu mainForm = null;
        public Register(Form callingForm)
        {
            mainForm = callingForm as MainMenu;
            InitializeComponent();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            


            string constring = "server=localhost;user id=root;database=onlinecinemav2";
            MySqlConnection conn = new MySqlConnection(constring);
            using MySqlCommand cmd = new MySqlCommand("insert into onlinecinemav2.users(username, surname,password, email, tel) values(@username, @surname,@password, @email, @tel)", conn);
            conn.Open();
            cmd.Parameters.Add(new MySqlParameter("@username", textBox1.Text));
            cmd.Parameters.Add(new MySqlParameter("@surname", textBox2.Text));
            cmd.Parameters.Add(new MySqlParameter("@password", textBox3.Text));
            cmd.Parameters.Add(new MySqlParameter("@email", textBox4.Text));
            cmd.Parameters.Add(new MySqlParameter("@tel", textBox5.Text));
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            Form3 frm3 = new Form3(this);
            frm3.Show();
            this.Hide();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Please fill blanks");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}


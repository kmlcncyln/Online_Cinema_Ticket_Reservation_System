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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        
        private MainMenu mainForm = null;
        
        public Form3(Form callingForm)
        {
            mainForm = callingForm as MainMenu;
            InitializeComponent();

        }
        string cs = "server=localhost;user id=root;database=onlinecinemav2";
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                MySqlConnection conn = new MySqlConnection(cs); 
                MySqlCommand cmd = new MySqlCommand("Select * from users where username=@username and password=@password", conn);
                cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                conn.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                conn.Close();
                int count = ds.Tables[0].Rows.Count;
                
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    
                    MainMenu fm = new MainMenu(txt_UserName.Text);
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage mnpg = new MainPage();
            mnpg.Show();
            this.Hide();
        }
    }
}



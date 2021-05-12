using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=onlinecinemav2");
        MySqlCommand cmd;
        

        
        
        
        
        
        
        private MainMenu mainForm = null;
        public AdminPanel(Form callingForm)
        {
            mainForm = callingForm as MainMenu;
            InitializeComponent();


        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=onlinecinemav2");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM theater";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;                                        // ComboBox
            
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["theaterID"]);
            }
            conn.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)

        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            string constring = "server=localhost;user id=root;database=onlinecinemav2";
            MySqlConnection conn1 = new MySqlConnection(constring);
            conn1.Open();

            
            String insertQuery = "insert into onlinecinemav2.movies(moviename,image,theaterID) values(@moviename,@image,@theaterID)";
            
            

            
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            cmd = new MySqlCommand(insertQuery, conn1);
            //cmd = new MySqlCommand(insertQuery2, conn1);

            cmd.Parameters.Add("@moviename", MySqlDbType.VarChar);
            cmd.Parameters.Add("@theaterID", MySqlDbType.Int32);
            cmd.Parameters.Add("@image", MySqlDbType.Blob);

            cmd.Parameters["@moviename"].Value = textBox1.Text;
            cmd.Parameters["@theaterID"].Value = comboBox1.Text;
            cmd.Parameters["@image"].Value = img;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            this.mainForm.LabelText = textBox1.Text;
            this.Hide();
            mainForm.Show();

        }

        
    }
    
}

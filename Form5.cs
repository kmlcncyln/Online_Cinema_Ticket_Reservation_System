using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class Form5 : Form
    {
        public Form5()
        {

            InitializeComponent();
            

        }
        public Form5(string value, string username)
        {

            InitializeComponent();
            this.Value = value;
            this.Username = username;
            
        }

        public string Value { get; set; }

        public string Theatername { get; set; }
        public string Username { get; set; }
        

        private MainMenu mainForm = null;
        public Form5(Form callingForm)
        {
            mainForm = callingForm as MainMenu;
            InitializeComponent();


            



        }
        void button1_click(object sender, EventArgs e)
        {
            //get button clicked
            Button btn = sender as Button;
            MessageBox.Show(btn.Name + " clicked");

            Theater Thtr = new Theater(btn.Name,Value,Theatername,Username);

            Thtr.Show();

        }
        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = Value;
            

            string constring = "server=localhost;user id=root;database=onlinecinemav2";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            MySqlConnection conn1 = new MySqlConnection(constring);
            conn1.Open();
            MySqlConnection conn2 = new MySqlConnection(constring);
            conn2.Open();
            MySqlConnection conn3 = new MySqlConnection(constring);
            conn3.Open();

            using MySqlCommand cmd3 = new MySqlCommand("SELECT theaterID FROM movies WHERE moviename = '" + Value + "'", conn2);
            MySqlDataReader myReader3;
            myReader3 = cmd3.ExecuteReader();
            int tID = 0;
            
            while (myReader3.Read())
            {

               tID = myReader3.GetInt32("theaterID");



            }
            
            using MySqlCommand cmd = new MySqlCommand("select theatername from theater WHERE showingtimeID2 = "+tID+"", conn);
            using MySqlCommand cmd2 = new MySqlCommand("SELECT movietimes FROM showingtime WHERE showingtimeID2 = " + tID + "", conn1);
            using MySqlCommand cmd4 = new MySqlCommand("SELECT image FROM movies WHERE theaterID = " + tID + "", conn3);
            
            MySqlDataReader myReader4;
            myReader4 = cmd4.ExecuteReader();
            while (myReader4.Read())
            {

                

                byte[] imgg = (byte[])(myReader4["image"]);
                if (imgg == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream mstream = new MemoryStream(imgg);
                    pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                }


            }




            MySqlDataReader myReader;
            try
            {

                myReader = cmd.ExecuteReader();
                
                while (myReader.Read())
                {
                    Label lbl2 = new Label();
                    lbl2.Location = new Point(250, 80);
                    lbl2.Text = myReader.GetString("theatername");
                    lbl2.Name = "DynamicLabel";
                    lbl2.Font = new Font("Georgia", 14);
                    lbl2.Height = 50;
                    lbl2.Width = 200;
                    this.Controls.Add(lbl2);
                    Theatername = myReader.GetString("theatername");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();


            MySqlDataReader myReader1;
            myReader1 = cmd2.ExecuteReader();
            List<string> movietimes = new List<string>();
              

            while (myReader1.Read())
            {

                movietimes.Add(myReader1.GetString("movietimes"));
                
            }
                int a, b;
            a = 250;
            b = 130;
            int counter = 0;

            

            for (int i = 0; i < movietimes.Count; i++)
            {
                if (i == 3) 
                {
                    a = 250;
                    b = 300;
                    
                }
                
                Button dynamicButton = new Button();
                dynamicButton.Text = movietimes[counter];
                dynamicButton.Location = new Point(a, b);
                dynamicButton.Height = 50;
                dynamicButton.Width = 100;
                this.Controls.Add(dynamicButton); 
                a = a + 130;
                dynamicButton.Name = movietimes[counter];
                dynamicButton.Click += new EventHandler(this.button1_click);
                counter++;
            
            }
            
            
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

        }
        public MainMenu(string username)
        {

            InitializeComponent();
            this.Username = username;
        }
        public string Username { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            string constring = "server=localhost;user id=root;database=onlinecinemav2";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
           
            MySqlConnection conn2 = new MySqlConnection(constring);
            conn2.Open();

            using MySqlCommand cmd = new MySqlCommand("SELECT image FROM movies", conn);
            using MySqlCommand cmd2 = new MySqlCommand("SELECT moviename FROM movies", conn2);
            MySqlDataReader myReader1;
            MySqlDataReader myReader2;
            myReader1 = cmd.ExecuteReader();
            List<Image> images = new List<Image>();
            myReader2 = cmd2.ExecuteReader();
            List<string> movienames = new List<string>();
            byte[] imgg;
            int a, b;
            a = 150;
            b = 100;
            int counter = 0;

            while (myReader2.Read())
            {
                movienames.Add(myReader2.GetString("moviename"));

            }
            while (myReader1.Read())
            {
                if( counter >= 3)
                {
                    if( counter == 3)
                    {
                        a = 150;

                    }
                    b = 400;

                }
                imgg = (byte[])(myReader1["image"]);
                MemoryStream ms = new MemoryStream(imgg);
                Button dynamicButton = new Button();
                dynamicButton.Height = 215;
                dynamicButton.Width = 146;
                dynamicButton.Image = System.Drawing.Image.FromStream(ms);
                //dynamicButton.Image = images[counter];
                dynamicButton.Location = new Point(a, b);
                this.Controls.Add(dynamicButton);
                dynamicButton.Name = movienames[counter];
                dynamicButton.Click += new EventHandler(this.button_click);

                a = a + 300;
                counter++;
                

            }
            
            

        }   
        void button_click(object sender, EventArgs e)
        {
            //get button clicked
            Button btn = sender as Button;
            MessageBox.Show(btn.Name + " clicked");

            Form5 frm5 = new Form5(btn.Name,Username);
            frm5.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5(this);
            frm5.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Theater Thtr = new Theater(this);
            Thtr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.Show();
            this.Hide();
        }
        public string LabelText
        {
            get { return label2.Text; }
            set { label2.Text = value; }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Register frm4 = new Register(this);
            frm4.Show();
            this.Hide();
        }

        

        private void button11_Click(object sender, EventArgs e)
        {
            AdminPanel admpnl = new AdminPanel(this);
            admpnl.Show();
            this.Hide();
        }

        
    }
}

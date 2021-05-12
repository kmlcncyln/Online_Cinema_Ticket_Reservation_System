using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Online_Cinema_Ticket_Reservation_System
{
    public partial class Theater : Form
    {
        public Theater()
        {
            InitializeComponent();
        }
        public Theater(string time, string moviename, string theatername, string username)
        {

            InitializeComponent();
            this.Time = time;
            this.Moviename = moviename;
            this.Theatername = theatername;
            this.Username = username;
            
        }


        private MainMenu mainForm = null;
        private List<string> seatArray = new List<string>();
        public string Time { get; set; }
        public string Moviename { get; set; }

       
        public string Username { get; set; }
        public string Theatername { get; set; }
        public Theater(Form callingForm)
        {
            mainForm = callingForm as MainMenu;
            InitializeComponent();
            
        }
        void button_click(object sender, EventArgs e)
        {
            //get button clicked
            CheckBox chck = sender as CheckBox;   
            
            int index = 0;
            bool ctrl = false;
            if(seatArray.Count != 0)
            {
                if (seatArray.Contains(chck.Name))
                {
                    index = seatArray.IndexOf(chck.Name);
                    seatArray.RemoveAt(index);
                    ctrl = true;
                 }
            }
            
            if(ctrl == false)
            {
                seatArray.Add(chck.Name);

            }
            ctrl = false;
           

        }
        
        private void Theater_Load(object sender, EventArgs e)
        {

            Label lbl1 = new Label();
            lbl1.ForeColor = Color.Black;
            lbl1.Location = new Point(450, 20);
            lbl1.Text = "Theater";
            lbl1.Name = "DynamicLabel";
            lbl1.Font = new Font("Georgia", 16);
            lbl1.Height = 50;
            lbl1.Width = 200;
            this.Controls.Add(lbl1);

            int a, b;
            a = 50;
            b = -30;
            int harf;
            harf = 65;
            String car = "A";
            for (int i = 0; i < 40; i++)
            {
                if (i%10 == 0)
                {
                    
                    car = Convert.ToString(Convert.ToChar(harf));
                    a = 50;
                    b += 100;
                    Label sıraismi = new Label();
                    sıraismi.ForeColor = Color.Black;
                    sıraismi.Location = new Point(10, b);
                    sıraismi.Text = car;
                    sıraismi.Name = "DynamicLabel";
                    sıraismi.Font = new Font("Georgia", 16);
                    sıraismi.Height = 30;
                    sıraismi.Width = 30;
                    this.Controls.Add(sıraismi);
                    harf = harf + 1;

                    

                }
                
                CheckBox dynamicCheckbox = new CheckBox();
                dynamicCheckbox.Height = 50;
                dynamicCheckbox.Width = 50;
                dynamicCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
                const int padding = 6;
                Size size = new Size(dynamicCheckbox.Width - padding, dynamicCheckbox.Height - padding);
                dynamicCheckbox.Image = ResizeImage(new Icon("../../../Properties/koltuk3.ico").ToBitmap(), size);
                dynamicCheckbox.Name = ""+car+""+((i % 10) + 1).ToString()+"";
                dynamicCheckbox.Click += new EventHandler(this.button_click);

                dynamicCheckbox.Location = new Point(a, b);
                Button dynamicButton = new Button();
                dynamicButton.Location = new Point(a, b);
                dynamicButton.Height = 50;
                dynamicButton.Width = 50;
                Label dynamiclabel = new Label();
                dynamiclabel.Location = new Point(a+15, b+50);
                dynamiclabel.Font = new Font("Georgia", 16);
                dynamiclabel.ForeColor = Color.Black;
                dynamiclabel.Text = ((i % 10) + 1).ToString();
                dynamiclabel.Height = 30;
                dynamiclabel.Width = 50;
                this.Controls.Add(dynamicCheckbox);
                this.Controls.Add(dynamiclabel);
                a = a + 100;
                

            }


        }
        public static Bitmap ResizeImage(Image image, Size size)
        {
            Bitmap result = new Bitmap(size.Width, size.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            checkout chc = new checkout(seatArray,Time,Moviename,Theatername,Username);
            chc.Show();
        }
    }
}

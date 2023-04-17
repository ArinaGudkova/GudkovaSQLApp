using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GudkovaSQLApp
{
    public partial class RegistrForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public RegistrForm()
        {
            
            InitializeComponent();
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 46);
            UserName.Text = "Введите имя";
            UserName.ForeColor = Color.Gray;
            UserSurname.Text = "Введите фамилию";
            UserSurname.ForeColor = Color.Gray;
            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Gray;
            passField.UseSystemPasswordChar = false;
            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
      private void UserName_Enter(object sender, EventArgs e)
        {
            if (UserName.Text == "Введите имя")
            {
             UserName.Text = "";
                UserName.ForeColor = Color.Black;
            }
            
        }

        private void UserName_Leave(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "Введите имя";
                UserName.ForeColor = Color.Gray;
            }
        }
        private void SurnameName_Leave(object sender, EventArgs e)
        {
            if (UserSurname.Text == "")
            {
                UserSurname.Text = "Введите фамилию";
                UserSurname.ForeColor = Color.Gray;
            }
        }
          private void SurnameName_Enter(object sender, EventArgs e)
        {
            if (UserSurname.Text == "Введите фамилию")
            {
                UserSurname.Text = "";
                UserSurname.ForeColor = Color.Black;
            }

        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = false;
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Gray;
            }
            
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.UseSystemPasswordChar = true;
                passField.ForeColor = Color.Black;
                
            }
            
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Уверены, что хотите выйти?", "Сообщение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }
        Point lastpoint;
        private void mainmenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void mainmenu_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }


        Point lastpoint1;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

            lastpoint1 = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint1.X;
                this.Top += e.Y - lastpoint1.Y;

            }
        }

       
      

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text =="Введите имя")
                {
                MessageBox.Show("Пожалуйста, введите имя");
                return;
            }
            if (UserSurname.Text == "Введите фамилию")
            {
                MessageBox.Show("Пожалуйста, введите фамилию");
                return;
            }
            if (loginField.Text == "Введите логин")
            {
                MessageBox.Show("Пожалуйста, введите логин");
                return;
            }
            if (passField.Text == "Введите пароль")
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }
            if (CheckUsers())
                return;
            DB db = new DB();
            MySqlCommand Sqlcommand = new MySqlCommand("INSERT INTO `users` ( `Name`, `Surname`, `login`, `pass`) VALUES (@Name, @Surname,  @Login, @Pass)", db.GetConnection());
            Sqlcommand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = loginField.Text;
            Sqlcommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = UserName.Text;
            Sqlcommand.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = UserSurname.Text;
            Sqlcommand.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = passField.Text;
            db.openConnect();

            if (Sqlcommand.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }
            db.closeConnect();

        }
        public Boolean CheckUsers()
        {
            DB db = new DB();
            DataTable dtable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            mySqlCommand.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин уже используется, введите другой");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lform = new LoginForm();
            lform.Show();
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.DarkCyan;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.DarkGray;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Back_MouseEnter(object sender, EventArgs e)
        {
            Back.ForeColor = Color.White;
        }

        private void Back_MouseLeave(object sender, EventArgs e)
        {
            Back.ForeColor = Color.Black;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            passField.UseSystemPasswordChar = true;
            pictureBox1.Image = Image.FromFile("C:/Users/Arina/Desktop/7тема1/GudkovaSQLApp/GudkovaSQLApp/images/eyes1.png");
            if (passField.Text == "Введите пароль")
            {
                passField.UseSystemPasswordChar = false;
                passField.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            passField.UseSystemPasswordChar = false;
            pictureBox1.Image = Image.FromFile("C:/Users/Arina/Desktop/7тема1/GudkovaSQLApp/GudkovaSQLApp/images/eyes.png");
        }
    }
}

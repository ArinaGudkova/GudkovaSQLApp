using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GudkovaSQLApp
{
   
    public partial class MainForm : Form
    {

        private void LoadData()
        {
            DB db = new DB();
            DataTable dtable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `list_of_articles` ", db.GetConnection());
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(dtable);
            Table1.DataSource = dtable;

            Table1.Columns[0].HeaderText = "Код статьи";
            Table1.Columns[1].HeaderText = "Название статьи";
            Table1.Columns[2].HeaderText = "Код темы";
            Table1.Columns[3].HeaderText = "Код автора";
            Table1.Columns[4].HeaderText = "Код журнала";
            
            Table1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Font = new Font(Table1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            
        }

        private void LoadData1()
        {
            DB db = new DB();
            DataTable dtable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `list_of_avtors` ", db.GetConnection());
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(dtable);
            Table1.DataSource = dtable;


            Table1.Columns[0].HeaderText = "Код автора";
            Table1.Columns[1].HeaderText = "ФИО автора";
            Table1.Columns[2].HeaderText = "Об авторе";

            Table1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Font = new Font(Table1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }
        private void LoadData2()
        {
            DB db = new DB();
            DataTable dtable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `list_of_journal` ", db.GetConnection());
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(dtable);
            Table1.DataSource = dtable;

            Table1.Columns[0].HeaderText = "Код журнала";
            Table1.Columns[1].HeaderText = "Название журнала";
            Table1.Columns[2].HeaderText = "Код выпуска журнала";
            Table1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Font = new Font(Table1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }
        private void LoadData3()
        {
            DB db = new DB();
            DataTable dtable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `list_of_theme` ", db.GetConnection());
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(dtable);
            Table1.DataSource = dtable;

            Table1.Columns[0].HeaderText = "Код темы";
            Table1.Columns[1].HeaderText = "Название темы";
            Table1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Table1.ColumnHeadersDefaultCellStyle.Font = new Font(Table1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }



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

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }


        private void Back_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Back_MouseEnter(object sender, EventArgs e)
        {
            Back.ForeColor = Color.Pink;
        }

        private void Back_MouseLeave(object sender, EventArgs e)
        {
            Back.ForeColor = Color.Black;
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
            CloseButton.ForeColor = Color.Pink;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }
        Point lastpoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }


        Point lastpoint1;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            lastpoint1 = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint1.X;
                this.Top += e.Y - lastpoint1.Y;

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

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            LoadData3();
        }
    }
}

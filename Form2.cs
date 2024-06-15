using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Point dragCursorPoint;
        private bool dragging = false;
        private Point dragFormPoint;
        private bool isPlaceholderActive;
        private bool isPlaceholderActive2;
        private bool isPlaceholderActive3;
        private bool isPlaceholderActive4;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ptppr\\Desktop\\BIT UoM\\Semester 01\\ITE1112 - Visual Application Programming\\Week 14\\Learning Activity 16\\WindowsFormsApp1\\Database1.mdf\";Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            textBox1.BackColor = Color.LightYellow;       // Background color
            textBox1.ForeColor = Color.DarkBlue;          // Text color
            textBox1.Font = new Font("Arial", 14, FontStyle.Bold);  // Font style
            textBox1.BorderStyle = BorderStyle.FixedSingle; // Border style
            textBox1.TextAlign = HorizontalAlignment.Center; // Text alignment
            

            textBox2.BackColor = Color.LightYellow;       // Background color
            textBox2.ForeColor = Color.DarkBlue;          // Text color
            textBox2.Font = new Font("Arial", 14, FontStyle.Bold);  // Font style
            textBox2.BorderStyle = BorderStyle.FixedSingle; // Border style
            textBox2.TextAlign = HorizontalAlignment.Center; // Text alignment
            

            textBox3.BackColor = Color.LightYellow;       // Background color
            textBox3.ForeColor = Color.DarkBlue;          // Text color
            textBox3.Font = new Font("Arial", 14, FontStyle.Bold);  // Font style
            textBox3.BorderStyle = BorderStyle.FixedSingle; // Border style
            textBox3.TextAlign = HorizontalAlignment.Center; // Text alignment
            textBox3.SelectionStart = 0;

            textBox4.BackColor = Color.LightYellow;       // Background color
            textBox4.ForeColor = Color.DarkBlue;          // Text color
            textBox4.Font = new Font("Arial", 14, FontStyle.Bold);  // Font style
            textBox4.BorderStyle = BorderStyle.FixedSingle; // Border style
            textBox4.TextAlign = HorizontalAlignment.Center; // Text alignment
            textBox4.SelectionStart = 0;

            InitializePlaceholder();
            InitializePlaceholder2();
            panel2.Hide();
            panel1.Show();
        }

        private void InitializePlaceholder()
        {
            textBox1.Text = "Username";
            textBox1.ForeColor = Color.Gray;
            isPlaceholderActive = true;
            textBox1.MouseClick += new MouseEventHandler(TextBox1_MouseClick);
            textBox1.SelectionStart = 0;
            textBox3.Text = "Username";
            textBox3.ForeColor = Color.Gray;
            isPlaceholderActive3 = true;
            textBox3.MouseClick += new MouseEventHandler(TextBox1_MouseClick);
            textBox3.SelectionStart = 0;

        }

        private void InitializePlaceholder2()
        {
            textBox2.Text = "Password";
            textBox2.ForeColor = Color.Gray;
            isPlaceholderActive2 = true;
            textBox2.MouseClick += new MouseEventHandler(TextBox2_MouseClick);
            textBox2.SelectionStart = 0;
            textBox4.Text = "Password";
            textBox4.ForeColor = Color.Gray;
            isPlaceholderActive4 = true;
            textBox4.MouseClick += new MouseEventHandler(TextBox2_MouseClick);
            textBox4.SelectionStart = 0;

        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isPlaceholderActive)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
                isPlaceholderActive = false;
            }
            else
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
                isPlaceholderActive = true;
            }
        }

        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (isPlaceholderActive2)
            {
                textBox2.PasswordChar = '*';
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                isPlaceholderActive2 = false;
            }
            else
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
                isPlaceholderActive2 = true;
            }
        }
        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (isPlaceholderActive3)
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
                isPlaceholderActive3 = false;
            }
            else
            {
                textBox3.Text = "Username";
                textBox3.ForeColor = Color.Gray;
                isPlaceholderActive3 = true;
            }
        }
        private void TextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (isPlaceholderActive4)
            {
                //textBox4.PasswordChar = '*';
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                isPlaceholderActive4 = false;
            }
            else
            {
                textBox4.Text = "Password";
                textBox4.ForeColor = Color.Gray;
                isPlaceholderActive4 = true;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (ValidateLogin(username, password))
            {
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }
        private bool ValidateLogin(string username, string password)
        {
            bool isValid = false;
            string query = "SELECT COUNT(1) FROM Users WHERE " +
                "Username=@Username AND Password=@Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Location = button2.Location;
            panel2.Hide();
            panel1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Location = button3.Location;
            panel1.Hide();
            panel2.Show();
        }

        private bool RegisterUser(string username, string password)
        {
            bool isRegistered = false;
            string checkUserQuery = "SELECT COUNT(1) FROM Users WHERE Username=@Username";
            string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES " +
                "(@Username, @Password)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
                checkUserCmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int userExists = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                if (userExists == 0)
                {
                    SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, conn);
                    insertUserCmd.Parameters.AddWithValue("@Username", username);
                    insertUserCmd.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = insertUserCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isRegistered = true;
                    }
                }
            }

            return isRegistered;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newUsername = textBox3.Text;
            string newPassword = textBox4.Text;

            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }

            if (RegisterUser(newUsername, newPassword))
            {
                MessageBox.Show("Registration successful.");
            }
            else
            {
                MessageBox.Show("Registration failed. Username might already be taken.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}



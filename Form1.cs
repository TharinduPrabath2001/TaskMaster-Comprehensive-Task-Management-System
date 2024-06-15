using System;
using System.Collections;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

using System.Windows.Forms;

namespace WindowsFormsApp1



{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private int employeeIdInt;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ptppr\\Desktop\\BIT UoM\\Semester 01\\ITE1112 - Visual Application Programming\\Week 14\\Learning Activity 16\\WindowsFormsApp1\\Database1.mdf\";Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 240);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView1.GridColor = Color.FromArgb(255, 255, 255);
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeRows = false;
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 240);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView2.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView2.GridColor = Color.FromArgb(255, 255, 255);
            dataGridView2.RowHeadersVisible = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AllowUserToResizeRows = false;
            DataGridViewCellStyle headerStyle2 = new DataGridViewCellStyle();
            headerStyle2.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            headerStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView2.RowTemplate.Height = 45;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView3.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView3.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView3.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 240);
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView3.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView3.GridColor = Color.FromArgb(255, 255, 255);
            dataGridView3.RowHeadersVisible = true;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AllowUserToResizeRows = false;
            DataGridViewCellStyle headerStyle3 = new DataGridViewCellStyle();
            headerStyle3.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            headerStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView3.RowTemplate.Height = 45;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView4.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView4.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView4.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 240);
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView4.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView4.GridColor = Color.FromArgb(255, 255, 255);
            dataGridView4.RowHeadersVisible = true;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.AllowUserToResizeRows = false;
            DataGridViewCellStyle headerStyle4 = new DataGridViewCellStyle();
            headerStyle4.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            headerStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridView4.RowTemplate.Height = 45;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private DataTable GetData(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Tasks";
            DataTable data = GetData(query);
            dataGridView1.DataSource = data;
            
            string query2 = "SELECT * FROM Tasks WHERE Status = 'In Progress'";
            DataTable data2 = GetData(query2);
            dataGridView2.DataSource = data2;

            string query4 = "SELECT * FROM Tasks WHERE Status = 'Completed'";
            DataTable data4 = GetData(query4);
            dataGridView3.DataSource = data4;

            string query3 = "SELECT * FROM Employees";
            DataTable data3 = GetData(query3);
            dataGridView4.DataSource = data3;

            string query5 = "SELECT EmployeeID,EmployeeName FROM Employees";
            DataTable data5 = GetData1(query5);

            comboBox2.Items.Clear();
            foreach (DataRow row in data5.Rows)
            {
                comboBox2.Items.Add(row["EmployeeID"].ToString()+" " +row["EmployeeName"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            LoadData();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            // Get data from the input controls
            string taskName = txtTaskName.Text; // Assume txtTaskName is a TextBox for TaskName
            string taskDescription = txtTaskDescription.Text;
            string taskPriority = comboBox1.Text;// Assume txtTaskDescription is a TextBox for TaskDescription
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string employeeid = comboBox2.Text;
            char firstChar = employeeid[0];
            
            if (int.TryParse(firstChar.ToString(), out int firstCharAsInt)){
                employeeIdInt = firstCharAsInt;
            }


                // Insert the new entry into the database
                string query = "INSERT INTO Tasks (TaskName, Description, Status, Priority, DueDate, Employee) VALUES (@TaskName, @TaskDescription, 'In Progress', @Priority, @DueDate, @Employee)";
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);
                cmd.Parameters.AddWithValue("@Priority", taskPriority);
                cmd.Parameters.AddWithValue("@DueDate", selectedDate);
                cmd.Parameters.AddWithValue("@Employee", employeeIdInt);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
            txtTaskDescription.Clear();
            txtTaskName.Clear();

            // Refresh the DataGridView to display the new entry
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedTaskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskID"].Value); // Assume TaskID is the primary key
                UpdateTaskStatus(selectedTaskId, "Completed");
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a task to complete.");
            }
        }

        private void UpdateTaskStatus(int taskId, string status)
        {
            string query = "UPDATE Tasks SET Status = @Status WHERE TaskID = @TaskID";
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void DeleteTask(int taskId)
        {
            string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedTaskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskID"].Value); // Assume TaskID is the primary key
                DeleteTask(selectedTaskId);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button8.Height;
            panel3.Top = button8.Top;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            LoadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button7.Height;
            panel3.Top = button7.Top;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            LoadData();
        }
        
        private DataTable GetData1(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 mainForm = new Form2();
            mainForm.Show();
        }
    }
}

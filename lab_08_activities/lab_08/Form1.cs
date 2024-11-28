using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void loadCustomer()
        {

            string strConnection = "Data source=DESKTOP-EOE4UOM\\SQLEXPRESS01;Initial Catalog=CustomerDB; Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "Select* from CustomerTable";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dataGridView1.DataSource = objDataSet.Tables[0];
            objConnection.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadCustomer();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = " ";
            if (radioButton1.Checked) Gender = "Male";
            else Gender = "Female";
            if (checkBox1.Checked) Hobby = "Reading";
            else Hobby = "Gardening";
            if (radioButton3.Checked) Status = "Married";
            else Status = "Unmarried";
            MessageBox.Show("Customer Name: " + textBox1.Text + "\n" + "Country: " + comboBox1.Text + "\n" + "Gender: " + Gender + "\n"
                + "Hobby: " + Hobby + "\n" + "Status: " + Status);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = " ";
            if (radioButton1.Checked) Gender = "Male";
            else Gender = "Female";
            if (checkBox1.Checked) Hobby = "Reading";
            else Hobby = "Gardening";
            if (radioButton3.Checked) Status = "1";
            else Status = "0";

            string strConnection = "Data source=DESKTOP-EOE4UOM\\SQLEXPRESS01;Initial Catalog=CustomerDB; Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "Insert into CustomerTable values('" + textBox1.Text + "','" + comboBox1.Text + "','" + Gender + "','" + Hobby + "'," + Status + ")";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();
            objConnection.Close();
            loadCustomer();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string CustomerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(CustomerName);
        }
        private void clearForm()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void displayCustomer(string strCustomer)
        {
            string strConnection = "Data source=DESKTOP-EOE4UOM\\SQLEXPRESS01;Initial Catalog=CustomerDB; Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "Select * From CustomerTable where CustomerName = '" + strCustomer + "'";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            textBox1.Text = objDataSet.Tables[0].Rows[0][0].ToString();
            comboBox1.Text = objDataSet.Tables[0].Rows[0][1].ToString();
            string Gender = objDataSet.Tables[0].Rows[0][2].ToString();
            if (Gender.Equals("Male")) radioButton1.Checked = true;
            else radioButton2.Checked = true;
            string Hobby = objDataSet.Tables[0].Rows[0][3].ToString();
            if (Hobby.Equals("Reading")) checkBox1.Checked = true;
            else checkBox2.Checked = true;
            string Married = objDataSet.Tables[0].Rows[0][4].ToString();
            if (Married.Equals("True")) radioButton3.Checked = true;
            else radioButton4.Checked = true;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConnection = "Data source=DESKTOP-EOE4UOM\\SQLEXPRESS01;Initial Catalog=CustomerDB; Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "Delete from CustomerTable where CustomerName = '" + textBox1.Text + "'";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();
            objConnection.Close();
            clearForm();
            loadCustomer();

        }
    }
}

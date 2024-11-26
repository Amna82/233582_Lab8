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

namespace Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status;
            if (radioButton1.Checked) Gender = "Male";
            else
                Gender = "Female";
            if (checkBox2.Checked) Hobby = "Book reading";
            else Hobby = "Gardening";
            if (radioButton3.Checked) Status = "Married";
            else Status = "Unmarried";
            MessageBox.Show("Customer Name: " + textBox1.Text + "\n" +
                    "Country: " + comboBox1.Text + "\n" +
                    "Gender: " + Gender + "\n" +
                    "Hobby: " + Hobby + "\n" +
                    "Status: " + Status);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void loadCustomer()
        {
            string strConnection = "Data Source=AUMC-LAB3-30\\SQLEXPRESS;Initial Catalog=Customer DB;"+"Integerated Security=True";
             SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "Select from CustomerTable";
            SqlCommand objCommand = new SqlCommand(strCommand,objConnection);
            DataSet objDataSet=new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dataGridView1.DataSource = objDataSet.Tables[0];
            objConnection.Close();

        }
        private void Form1_Load(object sender,EventArgs e)
        {
            loadCustomer();
        }
    }
}

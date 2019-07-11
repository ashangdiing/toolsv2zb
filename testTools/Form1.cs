using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            UpdateOutCall uo = new UpdateOutCall(textBoxOutCallNumber.Text, dateTimePickerStartTime.Text, dateTimePickerPlanTime.Text, dateTimePickerTimeOut.Text, Convert.ToInt32(numericUpDownTimes.Text), textBoxIVRURL.Text);
        

        }

        private void clear_Click(object sender, EventArgs e)
        {

            string ConnStr = "Provider=MSDAORA;DSN=oracle;User ID=system;Password=manager";
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand Comm = new SqlCommand(display.Text);
            Comm.ExecuteNonQuery();
            display.Text = "已清理";
        }

        private void query_Click(object sender, EventArgs e)
        {

            String result = "";
            string ConnStr = "Provider=MSDAORA;DSN=oracle;User ID=system;Password=manager";
            SqlConnection con = new SqlConnection(ConnStr);
            con.Open();
            SqlCommand Comm = new SqlCommand(display.Text);
            SqlDataReader reader = Comm.ExecuteReader();
            while (reader.HasRows)
            {
                result = result + "{"+reader[1].ToString()+"}";
                result = result + "{" + reader[2].ToString()+"}";
                result = result + "{" + reader[3].ToString() + "}";
                result = result + "{" + reader[4].ToString()+"}";
                result = result + "{" + reader[5].ToString() + "}";
            }

            display.Text = result;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string ConnStr = "Provider=MSDAORA;DSN=oracle;User ID=system;Password=manager";
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand Comm = new SqlCommand(display.Text);
            Comm.ExecuteNonQuery();
            display.Text = "已插入";
        }
    }
}

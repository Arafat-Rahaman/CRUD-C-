﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update Table_1 set ItemName= '" + textBox2.Text + "', Color ='" + comboBox1.Text + "',Design = '" + textBox3.Text + "', UpdateDate = '" + DateTime.Parse(dateTimePicker1.Text) + "' where ProductID = '" + int.Parse(textBox1.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Update.");
            BindData();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-IR9PR6G9;Initial Catalog=Arafat;User ID=sa;Password=Arafat09809;Encrypt=False"); 
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("insert into Table_1 values ('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "', getdate(), getdate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted.");
            con.Close();
            BindData();
        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Table_1", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Delete Table_1 where ProductID= '" + int.Parse(textBox1.Text) + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted.");
                BindData();
            }
            else
            {
                MessageBox.Show("Put Product ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Table_1 where ProductID= '" + int.Parse(textBox1.Text) + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
    }
    
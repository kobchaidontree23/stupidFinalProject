using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable todolist = new DataTable();
        bool isEdit = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            todolist.Columns.Add("Title");
            todolist.Columns.Add("Description");

            toDoListView.DataSource = todolist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            title.Text = "";
            description.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isEdit = true;

            title.Text = todolist.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            description.Text = todolist.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                todolist.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception er) { 
                Console.WriteLine("ERR"+er);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                todolist.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = title.Text;
                todolist.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = description.Text;
            }
            else {
                todolist.Rows.Add(title.Text, description.Text);
            }
            title.Text = "";
            description.Text = "";
            isEdit = false;
        }
    }
}

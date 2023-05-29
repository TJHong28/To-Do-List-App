using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todolist = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            // Create Column 
            todolist.Columns.Add("Title");
            todolist.Columns.Add("Description");

            //Point our datagrid datagridview to our database
            todolistView.DataSource = todolist;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // Clear TextBox
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            
            // Fill text fields with data from table 
            titleTextBox.Text = todolist.Rows[todolistView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todolist.Rows[todolistView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todolist.Rows[todolistView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing) 
            {
                todolist.Rows[todolistView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todolist.Rows[todolistView.CurrentCell.RowIndex]["description"] = descriptionTextBox.Text;
            }

            else
            {
                todolist.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            // Clear Fields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}

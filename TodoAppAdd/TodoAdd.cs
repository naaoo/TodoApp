using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoData;
using TodoLogic;

namespace TodoAppAdd
{
    public partial class TodoAdd : Form
    {
        TodoController controller = TodoController.GetInstance();

        public TodoAdd()
        {
            
            InitializeComponent();
        }

        private void btnBack_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void btnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            var newDateDue = dtPicker.Value;
            var addDeadline = cbAddDate.Checked;
            var newText = rtBox.Text;
            controller.AddNewTodo(newDateDue, addDeadline, newText);
            dtPicker.Value = DateTime.Now;
            cbAddDate.Checked = false;
            rtBox.Text = "";
            controller.todoEnt.SaveChanges();

        }
    }
}

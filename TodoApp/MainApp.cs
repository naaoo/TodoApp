using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoAppAdd;
using TodoData;
using TodoLogic;

namespace TodoApp
{
    public partial class MainApp : Form
    {
        TodoController controller = TodoController.GetInstance();
        
        public MainApp()
        {
            InitializeComponent();
            FillBoxes();
            CheckDueTasks();
            var timer = new Timer();
            timer.Interval = 1000 * 3600;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void FillBoxes()
        {
            LBoxActive.DataSource = controller.GetTodoList(false);
            LBoxDone.DataSource = controller.GetTodoList(true);
        }

        private void CBDone_Click(object sender, EventArgs e)
        {
            Todo todo = LBoxActive.SelectedItem as Todo;
            bool finished = controller.FinishTodo(todo);
            if (finished)
            {
                FillBoxes();
                CBDone.Checked = false;
            }
        }

        private void btnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            TodoAdd formAdd = new TodoAdd(FillBoxes);
            formAdd.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckDueTasks();
        }

        private void CheckDueTasks()
        {
            var due = controller.CheckDueTasks();
            if (due)
            {
                CloseTodos.CloseTodos formCloseTasks = new CloseTodos.CloseTodos();
                formCloseTasks.Show();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillBoxes();
        }
    }
}

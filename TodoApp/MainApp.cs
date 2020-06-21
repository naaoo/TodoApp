using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        /// <summary>
        /// contains all logic as well as data (in CSV-mode)
        /// </summary>
        TodoController controller = TodoController.GetInstance();

        public MainApp()
        {
            if (controller.mode == "CSV")
            {
                controller.GetDataCSV();
            }
            
            InitializeComponent();
            FillBoxes();
            CheckDueTasks();
            var timer = new Timer();
            timer.Interval = 1000 * 3600;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// fills active tasks and finished tasks boxes
        /// </summary>
        private void FillBoxes()
        {
            LBoxActive.DataSource = controller.GetTodoList(false);
            LBoxDone.DataSource = controller.GetTodoList(true);
        }

        /// <summary>
        /// marks a task as done and resets checkbox_checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens the "add" form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            TodoAdd formAdd = new TodoAdd(FillBoxes);
            formAdd.Show();
        }

        /// <summary>
        /// timer task, executes a check if any tasks are close to due or overdue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckDueTasks();
        }

        /// <summary>
        /// executes a check if any tasks are close to due or overdue
        /// </summary>
        private void CheckDueTasks()
        {
            var due = controller.CheckDueTasks();
            if (due)
            {
                CloseTodos.CloseTodos formCloseTasks = new CloseTodos.CloseTodos();
                formCloseTasks.Show();
            }
        }
    }
}

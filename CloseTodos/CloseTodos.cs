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

namespace CloseTodos
{

    public partial class CloseTodos : Form
    {
        /// <summary>
        /// contains all logic as well as data (in CSV-mode)
        /// </summary>
        TodoController controller = TodoController.GetInstance();

        public CloseTodos()
        {
            InitializeComponent();
            LoadLists();
        }

        /// <summary>
        /// loads overdue and close to due tasks and fills boxes
        /// </summary>
        private void LoadLists()
        {
            List<Todo> tasks = new List<Todo>();
            if (controller.mode == "DB")
            {
                tasks = controller.todoEnt.todos.ToList();
            }
            else if (controller.mode == "CSV")
            {
                tasks = controller.myTodos;
            }
            var overdueTasks = tasks.Where(x => x.done == false).Where(x => x.date_due < DateTime.Now).ToList();
            var refTime = DateTime.Now.AddHours(24);
            var closeTasks = tasks.Where(x => x.done == false).Where(x => x.date_due < refTime).Where(x => x.date_due > DateTime.Now).ToList();
            lBoxOverdue.DataSource = overdueTasks;
            lBoxClose.DataSource = closeTasks;
        }
    }
}

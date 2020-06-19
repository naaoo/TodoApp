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
        TodoController controller = TodoController.GetInstance();
        public CloseTodos()
        {
            InitializeComponent();
            LoadLists();
        }

        private void LoadLists()
        {
            var overdueTasks = controller.todoEnt.todos.Where(x => x.done == false).Where(x => x.date_due < DateTime.Now).ToList();
            var refTime = DateTime.Now.AddHours(24);
            var closeTasks = controller.todoEnt.todos.Where(x => x.done == false).Where(x => x.date_due < refTime).Where(x => x.date_due > DateTime.Now).ToList();
            lBoxOverdue.DataSource = overdueTasks;
            lBoxClose.DataSource = closeTasks;

        }
    }
}

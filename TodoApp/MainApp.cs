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

namespace TodoApp
{
    public partial class MainApp : Form
    {
        static TodoController controller = new TodoController();
        public MainApp()
        {
            TodoController controller = new TodoController();
            InitializeComponent();
            FillBoxes();
            
            
            /*
            TodoEntities entities = new TodoEntities();
            Todo myTodo = new Todo() { text = "Fenster putzen", done = false };
            entities.todos.Add(myTodo);
            var todo1 = entities.todos.Where(x => x.id == 6).FirstOrDefault();
            if (todo1 != null)
            {
                entities.todos.Remove(todo1);
                entities.SaveChanges();
            }
            */
            
        }

        private void FillBoxes()
        {

            LBoxActive.DataSource = controller.todoEnt.todos.ToList();
        }
    }
}

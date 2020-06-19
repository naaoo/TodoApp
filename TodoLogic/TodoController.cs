
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoData;

namespace TodoLogic
{
    public class TodoController
    {
        public TodoEntities todoEnt = new TodoEntities();

        private static TodoController instance = null;

        public static TodoController GetInstance()
        {
            if (instance == null)
            {
                instance = new TodoController();
            }
            return instance;
        }

        public List<Todo> GetTodoList(bool done)
        {
            if (!done)
            {
                List<Todo> list = todoEnt.todos.OrderBy(x => x.date_due).Where(x => x.done == false).ToList();
                list = ShiftList(list);
                return list;
            }
            else
            {
                List<Todo> list = todoEnt.todos.OrderBy(x => x.date_done).Where(x => x.done == true).ToList();
                list = ShiftList(list);
                return list;
            }
        }

        public bool FinishTodo(Todo todo)
        {
            todoEnt.todos.Where(x => x.id == todo.id).FirstOrDefault().done = true;
            DateTime currentTime = DateTime.Now;
            todoEnt.todos.Where(x => x.id == todo.id).FirstOrDefault().date_done = currentTime;
            todoEnt.SaveChanges();
            return true;
        }

        private List<Todo> ShiftList(List<Todo> list)
        {
            var tempList = new List<Todo>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].date_due == null)
                {
                    tempList.Add(list[i]);
                    list.RemoveAt(i);
                }
            }
            list.AddRange(tempList);
            return list;
        }

        public void AddNewTodo(DateTime newDateDue, bool addDeadline, string newText)
        {
            var newTodo = new Todo();
            if (addDeadline)
            {
                newTodo = new Todo() { text = newText, done = false, date_due = newDateDue };
            }
            else
            {
                newTodo = new Todo() { text = newText, done = false };
            }
            todoEnt.todos.Add(newTodo);
            todoEnt.SaveChanges();
        }

        public bool CheckDueTasks()
        {
            var overdueTasks = todoEnt.todos.Where(x => x.done == false).Where(x => x.date_due < DateTime.Now).ToList();
            var refTime = DateTime.Now.AddHours(24);
            var closeTasks = todoEnt.todos.Where(x => x.done == false).Where(x => x.date_due < refTime).Where(x => x.date_due > DateTime.Now).ToList();
            if (overdueTasks != null || closeTasks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

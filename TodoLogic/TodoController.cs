
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoData;

namespace TodoLogic
{
    public class TodoController
    {
        public string mode = ConfigurationManager.AppSettings.Get("Mode");
        /// <summary>
        /// entities containing all Todos (if used in DB-Mode)
        /// </summary>
        public TodoEntities todoEnt = new TodoEntities();
        /// <summary>
        /// path to file containing Todos
        /// </summary>
        private static string filePath = ConfigurationManager.AppSettings.Get("FilePath");
        /// <summary>
        /// list containing all Todos (if used in CSV-Mode)
        /// </summary>
        public List<Todo> myTodos = new List<Todo>();

        /// <summary>
        /// singleton
        /// </summary>
        private static TodoController instance = null;

        /// <summary>
        /// returns existing singleton instance or new instance if (instance == null)
        /// </summary>
        /// <returns></returns>
        public static TodoController GetInstance()
        {
            if (instance == null)
            {
                instance = new TodoController();
            }
            return instance;
        }

        /// <summary>
        /// loads data from csv-file, if mode is set to "CSV"
        /// </summary>
        /// <returns></returns>
        public List<Todo> GetDataCSV()
        {
            if (mode == "CSV")
            {
                string[] fileContent = File.ReadAllLines(filePath);
                myTodos = ConvertToList(fileContent);
                return myTodos;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// converts a stringArray to todoList
        /// </summary>
        /// <param name="todoArr"></param>
        /// <returns></returns>
        private static List<Todo> ConvertToList(string[] todoArr)
        {
            List<Todo> todoList = new List<Todo>();
            foreach (var item in todoArr)
            {
                string[] itemContent = item.Split(';');
                var id = int.Parse(itemContent[0]);
                var text = itemContent[1];
                var done = bool.Parse(itemContent[2]);
                DateTime? date_due = null;
                if (itemContent[3].Length > 0)
                {
                    date_due = DateTime.ParseExact(itemContent[3], "dd-MM-yyyy HH:mm", null);
                }
                DateTime? date_done = null;
                if (itemContent[4].Length > 0)
                {
                    date_done = DateTime.ParseExact(itemContent[4], "dd-MM-yyyy HH:mm", null);
                }
                todoList.Add(new Todo(id, text, done, date_due, date_done));
            }
            return todoList;
        }

        /// <summary>
        /// returns ordered TodoList (DB and CSV modes)
        /// </summary>
        /// <param name="done"></param>
        /// <returns></returns>
        public List<Todo> GetTodoList(bool done)
        {
            List<Todo> allTodos = new List<Todo>();
            if (mode == "DB")
            {
                if (!done)
                {
                    allTodos = todoEnt.todos.OrderBy(x => x.date_due).Where(x => x.done == false).ToList();
                }
                else
                {
                    allTodos = todoEnt.todos.OrderBy(x => x.date_done).Where(x => x.done == true).ToList();
                }
            }
            else if (mode == "CSV")
            {
                if (!done)
                {
                    allTodos = myTodos.OrderBy(x => x.date_due).Where(x => x.done == false).ToList();
                }
                else
                {
                    allTodos = myTodos.OrderBy(x => x.date_done).Where(x => x.done == true).ToList();
                }
            }
            allTodos = ShiftList(allTodos);
            return allTodos;
        }

        /// <summary>
        /// sets a certain todo as done
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public bool FinishTodo(Todo todo)
        {
            if (mode == "DB")
            {
                todoEnt.todos.Where(x => x.id == todo.id).FirstOrDefault().done = true;
                todoEnt.todos.Where(x => x.id == todo.id).FirstOrDefault().date_done = DateTime.Now;
                todoEnt.SaveChanges();
                return true;
            }
            else if (mode == "CSV")
            {
                myTodos.Where(x => x.id == todo.id).FirstOrDefault().done = true;
                myTodos.Where(x => x.id == todo.id).FirstOrDefault().date_done = DateTime.Now;
                SaveTodosToCSV(filePath);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// puts todos without deadline (date_due) to the end of the list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
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

        /// <summary>
        /// adds a new todo (DB and CSV mode)
        /// </summary>
        /// <param name="newDateDue"></param>
        /// <param name="addDeadline"></param>
        /// <param name="newText"></param>
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
            if (mode == "DB")
            {
                todoEnt.todos.Add(newTodo);
                todoEnt.SaveChanges();
            }
            else if (mode == "CSV")
            {
                newTodo.id = GetId();
                myTodos.Add(newTodo);
                SaveTodosToCSV(filePath);
            }
        }

        /// <summary>
        /// returns an int which is one higher than the last known id
        /// </summary>
        /// <returns></returns>
        private int GetId()
        {
            return myTodos[myTodos.Count - 1].id + 1;
        }

        /// <summary>
        /// checks if any overdue or close to (24h) due tasks exist
        /// </summary>
        /// <returns></returns>
        public bool CheckDueTasks()
        {
            List<Todo> tasks = new List<Todo>();
            if (mode == "DB")
            {
                tasks = todoEnt.todos.ToList();
                
            }
            else if (mode == "CSV")
            {
                tasks = myTodos;
            }
            var overdueTasks = tasks.Where(x => x.done == false).Where(x => x.date_due < DateTime.Now);
            var refTime = DateTime.Now.AddHours(24);
            var closeTasks = tasks.Where(x => x.done == false).Where(x => x.date_due < refTime).Where(x => x.date_due > DateTime.Now);
            if (overdueTasks != null || closeTasks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// saves full list myTodos to csv (specified in filePath)
        /// </summary>
        public void SaveTodosToCSV(string path)
        {
            var exportStrings = new List<string>();
            foreach (var todo in myTodos)
            {
                var stringDue = "";
                var stringDone = "";
                if (todo.date_due.HasValue)
                {
                    DateTime due = (DateTime)todo.date_due;
                    stringDue = due.ToString("dd-MM-yyyy HH:mm");
                }
                if (todo.date_done.HasValue)
                {
                    DateTime done = (DateTime)todo.date_done;
                    stringDone = done.ToString("dd-MM-yyyy HH:mm");
                }
                exportStrings.Add($"{todo.id};{todo.text};{todo.done.ToString()};" +
                    $"{stringDue};{stringDone};");
            }
            File.WriteAllLines(path, exportStrings);
        }
    }
}

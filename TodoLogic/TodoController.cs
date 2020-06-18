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

        public List<Todo> GetTodoList(bool done)
        {
            if (!done)
            {
                return todoEnt.todos.Where(x => x.done == false).ToList();
            }
            else
            {
                return todoEnt.todos.Where(x => x.done == true).ToList();
            }
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoData
{
    partial class Todo
    {
        public Todo()
        {

        }
        public Todo(int id, string text, bool done, DateTime? date_due, DateTime? date_done)
        {
            this.id = id;
            this.text = text;
            this.done = done;
            this.date_due = date_due;
            this.date_done = date_done;
        }

        public override string ToString()
        {
            string todoString = "";
            if (done && date_done != null)
            {
                todoString = text + " (" + date_done.ToString() + ")";
            }
            else
            {
                if (date_due == null)
                {
                    todoString = text;
                }
                else
                {
                    todoString = text + " (" + date_due.ToString() + ")";
                }
            }
            return todoString;
        }
    }
}

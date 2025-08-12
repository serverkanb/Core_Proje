using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TodoList 
    {
        public int ToDoListId { get; set; }


        public string Content { get; set; }

        public bool Status { get; set; }
    }
}

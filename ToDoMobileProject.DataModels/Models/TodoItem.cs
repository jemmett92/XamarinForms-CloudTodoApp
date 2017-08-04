using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMobileProject.DataModels.Models
{
    public class TodoItem 
    {
        public string Id {get; set;}
        public string Text {get; set;}

        public DateTimeOffset CreatedAt {get; set;}
        public bool Complete {get; set;}

   
       

    }
}

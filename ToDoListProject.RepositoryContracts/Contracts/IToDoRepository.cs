using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobileProject.DataModels.Models;

namespace ToDoListProject.RepositoryContracts.Contracts
{
    public interface IToDoRepository
    {
        
        Task<List<TodoItem>> GetTodos();
        void SaveTodo(TodoItem todo);
        void SaveTodo2(TodoItem todo);
        void DeleteTodos(TodoItem todo);
        void DeleteTodos2(TodoItem todo);
        void FilterByAscendingOrder(TodoItem todo);
        IEnumerable<TodoItem> GetTodos2();
      
    }
}

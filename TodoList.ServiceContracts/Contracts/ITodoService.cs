using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobileProject.DataModels.Models;

namespace TodoList.ServiceContracts.Contracts
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetTodos2();
        Task<List<TodoItem>> GetTodos();
        void SaveTodo(TodoItem todo);
        void DeleteTodos(TodoItem todo);
        void DeleteTodos2(TodoItem todo);
        void FilterByAscendingOrder(TodoItem todo);
        void SaveTodo2(TodoItem todo);
    }
}

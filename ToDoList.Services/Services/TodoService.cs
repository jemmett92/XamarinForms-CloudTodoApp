using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ServiceContracts.Contracts;
using ToDoListProject.Repositories.Repositories;
using ToDoListProject.RepositoryContracts.Contracts;
using ToDoMobileProject.DataModels.Models;

namespace ToDoList.Services.Services
{
    public class TodoService : ITodoService
    {

        private readonly IToDoRepository _todoRepository;
        private readonly MockTodoRepository _todoRepository2;

        public TodoService()
        {
            _todoRepository = new TodoRepository();
            _todoRepository2 = new MockTodoRepository();
        }

       

        public void SaveTodo(TodoItem todo)
        {
            _todoRepository.SaveTodo(todo);
        }

        

        public async Task<List<TodoItem>> GetTodos()
        {
            List<TodoItem> todos = await _todoRepository.GetTodos();
            return todos;
        }

        public void DeleteTodos(TodoItem todo)
        {
            _todoRepository.DeleteTodos(todo);
        }

        public void FilterByAscendingOrder(TodoItem todo)
        {
            _todoRepository.FilterByAscendingOrder(todo);
        }

        public IEnumerable<TodoItem> GetTodos2()
        {
            return _todoRepository2.GetTodos2();
        }

        public void SaveTodo2(TodoItem todo)
        {
            _todoRepository2.SaveTodo2(todo);
        }

        public void DeleteTodos2(TodoItem todo)
        {
            _todoRepository2.DeleteTodos2(todo);
        }
    }
}

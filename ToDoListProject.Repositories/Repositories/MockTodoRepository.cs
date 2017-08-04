using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListProject.RepositoryContracts.Contracts;
using ToDoMobileProject.DataModels.Models;

namespace ToDoListProject.Repositories.Repositories
{
    public class MockTodoRepository : IToDoRepository
    {
        public void DeleteTodos(TodoItem todo)
        {
           
        }

        public void FilterByAscendingOrder(TodoItem todo)
        {
           
        }

        public Task<List<TodoItem>> GetTodos()
        {
            return GetTodos();
        }

        public IEnumerable<TodoItem> GetTodos2()
        {
            IEnumerable<TodoItem> todos = new List<TodoItem>
            {
                new TodoItem
                {
                Id = "1",
                Text = "Task One"
                },
                 new TodoItem
                {
                Id = "2",
                Text = "Task Two"
                },
                 new TodoItem
                {
                Id = "3",
                Text = "Task Three"
                },
            };                               
            return todos;
        }
        public void SaveTodo(TodoItem todo)
        {
            
        }

        public void SaveTodo2(TodoItem todo)
        {
            var Todos = GetTodos2().ToList();
            Todos.Add(todo);
           
        }

        public void DeleteTodos2(TodoItem todo)
        {
            var Todos = GetTodos2().ToList();
            Todos.Remove(todo);
        }
    }
}

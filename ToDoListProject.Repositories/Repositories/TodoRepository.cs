using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListProject.Repositories.Repositories;
using ToDoListProject.RepositoryContracts.Contracts;
using ToDoMobileProject.DataModels.Models;

namespace ToDoListProject.Repositories.Repositories
{
    public class TodoRepository : IToDoRepository
    {
        public static readonly MobileServiceClient MobileService = new MobileServiceClient("http://jetestapi.azurewebsites.net/");
        IMobileServiceTable<TodoItem> todoTable = MobileService.GetTable<TodoItem>();
        public TodoRepository()
        {

        }

        //Save Todos
        public void SaveTodo(TodoItem todo)
        {
            if (!string.IsNullOrEmpty(todo.Id))
            {
                MobileService.GetTable<TodoItem>().UpdateAsync(todo);
            }
            else
            {
                MobileService.GetTable<TodoItem>().InsertAsync(todo);
            }
        }

        //Delete Method
        public void DeleteTodos(TodoItem todo)
        {
            MobileService.GetTable<TodoItem>().DeleteAsync(todo);
        }
        //Filter by completion Method
        public async void FilterByCompletion(TodoItem todo)
        {
            List<TodoItem> items = await MobileService.GetTable<TodoItem>().Where
              (todoItem => todoItem.Complete == false)
             .ToListAsync();
        }
        //Filter Ascending Method
        public async void FilterByAscendingOrder(TodoItem todo)
        {
            //IMobileServiceTableQuery<TodoItem> query = todoTable.OrderBy(todoItem => todoItem.Text).Skip().Take(10);
            IMobileServiceTableQuery<TodoItem> query = todoTable.OrderBy(todoItem => todoItem.Text);
            List<TodoItem> items = await query.ToListAsync();
        }
        //Filter Descending Method
        public async void FilterByDescendingOrder(TodoItem todo)
        {
            IMobileServiceTableQuery<TodoItem> query = todoTable.OrderByDescending(todoItem => todoItem.Text);
            List<TodoItem> items = await query.ToListAsync();
        }
        //Filter by ID Method
        public async void FilterByID(TodoItem todo)
        {
            TodoItem item = await todoTable.LookupAsync(todo.Id);
        }

        public IEnumerable<TodoItem> GetTodos2()
        {
            List<TodoItem> todos = new List<TodoItem>
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
            return todos.AsEnumerable();
        }

        public async Task<List<TodoItem>> GetTodos()
        {
            try
            {
                List<TodoItem> todos = await MobileService.GetTable<TodoItem>().ToListAsync();
                var Todos = todos;
                return Todos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveTodo2(TodoItem todo)
        {
            
        }

        public void DeleteTodos2(TodoItem todo)
        {
            
        }
    }

}

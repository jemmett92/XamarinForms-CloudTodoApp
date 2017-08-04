using Android.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismUnityToDolistMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ServiceContracts.Contracts;
using ToDoList.Services.Services;
using ToDoMobileProject.DataModels.Models;
using Xamarin.Forms;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class ListViewPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        // Services
        private readonly ITodoService _todoService;
        private readonly IPageDialogService _pageDialogService;
        private readonly INavigationService _navigationService;


        private ObservableCollection<TodoItem> todos;


        public ObservableCollection<TodoItem> Todos
        {
            get { return todos; }
            set
            {
                todos = value;
                OnPropertyChanged("Todos");
            }
        }

        //private List<TodoItem> todos;


        //public List<TodoItem> Todos
        //{
        //    get { return todos; }
        //    set
        //    {
        //        todos = value;
        //        OnPropertyChanged("Todos");
        //    }
        //}


        public DelegateCommand<TodoItem> DeleteTodoCommand { get; set; }
        public DelegateCommand<TodoItem> DeleteTodoCommand2 { get; set; }
        public DelegateCommand<TodoItem> SearchCommandExecuteCommand { get; set; }
        public DelegateCommand<TodoItem> NavigateToDetailViewCommand { get; private set; }

        public ListViewPageViewModel(ITodoService todoService, IPageDialogService pageDialogService, INavigationService navigationService)
        {            
            _todoService = todoService;
            // Todos = new ObservableCollection<TodoItem>();
            Todos = new ObservableCollection<TodoItem>();
            DeleteTodoCommand = new DelegateCommand<TodoItem>(DeleteTodos);
            DeleteTodoCommand2 = new DelegateCommand<TodoItem>(DeleteTodos2);
            NavigateToDetailViewCommand = new DelegateCommand<TodoItem>(NavigateToDetailView);
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
             
        }

        private void NavigateToDetailView(TodoItem obj)
        {        
            if (obj != null)
            {
                var param = new NavigationParameters();
                param.Add("Todo", obj);
                _navigationService.NavigateAsync("TodoDetail", param);
            }
        }

        private void DeleteTodos2(TodoItem todo)
        {
            _todoService.DeleteTodos(todo);
        }

        public async Task GetTodos()
        {
            Todos.Clear();
            //get new
            var todos = await _todoService.GetTodos();
            foreach (var todo in todos)
            {
                Todos.Add(todo);
            }
        }

        public void GetTodos2()
        {
        var todos = _todoService.GetTodos2();
            foreach (var todo in todos)
            {
                Todos.Add(todo);
            }
        }

        public void DeleteTodos(TodoItem todo)
        {
         _todoService.DeleteTodos(todo);
         _pageDialogService.DisplayAlertAsync("Todo Deleted", todo.Text + " has been Deleted!", "OK");
        }

      

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}


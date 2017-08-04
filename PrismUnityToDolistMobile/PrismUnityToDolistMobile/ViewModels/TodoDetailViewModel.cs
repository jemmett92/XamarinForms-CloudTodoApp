using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TodoList.ServiceContracts.Contracts;
using ToDoList.Services.Services;
using ToDoMobileProject.DataModels.Models;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class TodoDetailViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly ITodoService _todoService;

        private string _buttonText = "Edit + Save";

        public string ButtonText
        {
            get { return this._buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private TodoItem _todo;

        public TodoItem Todo
        {
            get { return this._todo; }
            set { SetProperty(ref _todo, value); }
        }

        public DelegateCommand SaveTodoCommand { get; set; }
        public TodoDetailViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _todoService = new TodoService();
            SaveTodoCommand = new DelegateCommand(SaveTodo);
        }
        private void SaveTodo()
        {
            _todoService.SaveTodo(Todo);
            _pageDialogService.DisplayAlertAsync("Todo Edited and Saved!", Todo.Text + " has been Saved!", "OK");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Todo"))
            {
                Todo = (TodoItem)parameters["Todo"];
                ButtonText = "Save";
            }
            else
            {
                Todo = new TodoItem();
                ButtonText = "Create";
            }
        }
    }
}

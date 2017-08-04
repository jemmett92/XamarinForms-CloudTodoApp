using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Modularity;
using System.Collections.ObjectModel;
using TodoList.ServiceContracts.Contracts;
using ToDoMobileProject.DataModels.Models;
using System;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class MainPageViewModel :ViewModelBase, INavigationAware 
    {
        // Properties
        private readonly IModuleManager _moduleManager;

        string _title = "Main Page";

        public string Title

        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LoadModuleACommand { get; set; }

        void LoadModuleA()
        {
            _moduleManager.LoadModule("ModuleA");
        }
        private bool _isVisible;
        public bool IsVisible
        {
            get { return this._isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        private bool _isRunning;

        public bool IsRunning
        {
            get { return this._isRunning; }
            set { SetProperty(ref _isRunning, value); }
        }

        private ObservableCollection<TodoItem> _todos;
        public ObservableCollection<TodoItem> Todos
        {
            get { return _todos; }
            set { SetProperty(ref _todos, value); }
        }

        // Services
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly ITodoService _todoService;

        //Fields
        private TodoItem _todo;

        public TodoItem Todo
        {
            get { return this._todo; }
            set { SetProperty(ref _todo, value); }
        }

        private bool _enabled;

        public bool Enabled
        {
            get { return this._enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        // Commands
        public DelegateCommand SaveTodoCommand { get; set; }
        public DelegateCommand<TodoItem> SaveTodoCommand2 { get; set; }
        public DelegateCommand NavigateToListViewCommand { get; private set; }
        public DelegateCommand NavigateToLoginCommand { get; private set; }
        public DelegateCommand NavigateToWebViewCommand { get; private set; }
        public DelegateCommand NavigateToMapViewCommand { get; private set; }

        public DelegateCommand NavigateToDetailViewCommand { get; private set; }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ITodoService todoService, IModuleManager moduleManager)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _todoService = todoService;
            SaveTodoCommand = new DelegateCommand(SaveTodo);
            SaveTodoCommand2 = new DelegateCommand<TodoItem>(SaveTodo2);
            NavigateToListViewCommand = new DelegateCommand(NavigateToListViewPage);
            NavigateToLoginCommand = new DelegateCommand(NavigateToLoginPage);
            NavigateToWebViewCommand = new DelegateCommand(NavigateToWebViewPage);
            NavigateToMapViewCommand = new DelegateCommand(NavigateToMapViewPage);
            NavigateToDetailViewCommand = new DelegateCommand(NavigateToDetailView);

            _moduleManager = moduleManager;
            LoadModuleACommand = new DelegateCommand(LoadModuleA);

            Enabled = true;
        }

        private void SaveTodo2(TodoItem todo)
        {
            _todoService.SaveTodo2(todo);
        }

        private void NavigateToDetailView()
        {
            _navigationService.NavigateAsync("TodoDetail");
        }

        private void NavigateToMapViewPage()
        {
            _navigationService.NavigateAsync("MapViewPage");
        }

        private void NavigateToWebViewPage()
        {
            _navigationService.NavigateAsync("WebViewPage");
        }

        private void NavigateToLoginPage()
        {
            _navigationService.NavigateAsync("LoginPage");
        }

        private void NavigateToListViewPage()
        {
            _navigationService.NavigateAsync("ListViewPage");
        }

        private void TodoDetail()
        {
            _navigationService.NavigateAsync("TodoDetail");
        }

        private void SaveTodo()
        {
            _todoService.SaveTodo(Todo);
            _pageDialogService.DisplayAlertAsync("Todo Saved", Todo.Text + " has been Saved!", "OK");
            Todo.Text = "";
            this.RaisePropertyChanged("Todo");
            
        }

        private void TodoDetail(TodoItem obj)
        {
            if (obj != null)
            {
                var param = new NavigationParameters();
                param.Add("Todo", obj);
                _navigationService.NavigateAsync("TodoDetail", param);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TodoList.ServiceContracts.Contracts;
using ToDoList.Services.Services;
using ToDoMobileProject.DataModels.Models;
namespace PrismUnityToDolistMobile.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        public DelegateCommand NavigateToMainPageCommand { get; private set; }
        public DelegateCommand NavigateToRegisterPageCommand { get; private set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            NavigateToRegisterPageCommand = new DelegateCommand(NavigateToRegisterPage);
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);
        }

        private void NavigateToMainPage()
        {
            _navigationService.NavigateAsync("MainPage", null, true);
        }

        private void NavigateToRegisterPage()
        {
            _navigationService.NavigateAsync("RegisterPage");
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

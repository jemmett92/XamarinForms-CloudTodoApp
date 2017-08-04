using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class RegisterPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        
        public DelegateCommand NavigateToLoginCommand { get; private set; }
        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
             NavigateToLoginCommand = new DelegateCommand(NavigateToLoginPage);
        }

        private void NavigateToLoginPage()
        {
            _navigationService.NavigateAsync("LoginPage");
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

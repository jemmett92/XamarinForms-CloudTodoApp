using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class WebViewPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        public DelegateCommand NavigateToWebViewCommand { get; private set; }
        public WebViewPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            NavigateToWebViewCommand = new DelegateCommand(NavigateToWebViewPage);
        }

        private void NavigateToWebViewPage()
        {
            _navigationService.NavigateAsync("WebViewPage");
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

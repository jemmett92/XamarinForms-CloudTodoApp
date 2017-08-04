using Prism.Commands;
using Prism.Mvvm;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;


namespace PrismUnityToDolistMobile.ViewModels
{
    public class MyMasterDetailViewModel : ViewModelBase
    {
        INavigationService _navigationService;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MyMasterDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string name)
        {
            _navigationService.NavigateAsync(name);
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
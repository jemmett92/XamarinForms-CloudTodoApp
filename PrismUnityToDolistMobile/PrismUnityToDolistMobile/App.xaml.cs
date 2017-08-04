using Prism.Unity;
using Prism.Modularity;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using PrismUnityToDolistMobile.Views;
using PrismUnityToDolistMobile.ViewModels;
using Xamarin.Forms;
using ToDoList.Services.Services;
using TodoList.ServiceContracts.Contracts;
using Microsoft.Practices.Unity;
using System;
using ToDoListProject.Repositories.Repositories;
using ToDoListProject.RepositoryContracts.Contracts;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace PrismUnityToDolistMobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("LoginPage");
            NavigationService.NavigateAsync("MyMasterDetail/MyNavigationPage/MainPage", animated: false);

            MobileCenter.Start("android=f0a40008-d2b6-47cb-806a-e851f233c020;" ,
                  
                   typeof(Analytics), typeof(Crashes));
        }

        protected override void RegisterTypes()
        {
            // Register views for navigation
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<ListViewPage>();
            Container.RegisterTypeForNavigation<LoginPage>();          
            Container.RegisterTypeForNavigation<RegisterPage>();
            Container.RegisterTypeForNavigation<WebViewPage>();
            Container.RegisterTypeForNavigation<TodoDetail>();

            //new Types
           
            Container.RegisterTypeForNavigation<MyNavigationPage>();
            Container.RegisterTypeForNavigation<MyMasterDetail>();

            // Register interface and class in container - inversion of control
            Container.RegisterType<ITodoService,TodoService>();
            Container.RegisterType<IToDoRepository, TodoRepository>();


            Container.RegisterTypeForNavigation<Xamarin.Forms.MasterDetailPage>();
            Container.RegisterTypeForNavigation<MyMasterDetail>();
            Container.RegisterTypeForNavigation<MyNavigationPage>();        
        }

        protected override void ConfigureModuleCatalog()
        {
          //  ModuleCatalog.AddModule(new ModuleInfo(typeof(ModuleA.ModuleAModule)));
            //ModuleCatalog.AddModule(new ModuleInfo("ModuleA", typeof(ModuleA.ModuleAModule), InitializationMode.OnDemand));
        }
    }
}

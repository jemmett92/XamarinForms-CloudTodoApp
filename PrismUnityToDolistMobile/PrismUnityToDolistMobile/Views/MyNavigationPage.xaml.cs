using Xamarin.Forms;
using Prism.Navigation;
using System;

namespace PrismUnityToDolistMobile.Views
{
    public partial class MyNavigationPage : NavigationPage, INavigationPageOptions, IDestructible
    {
       public MyNavigationPage()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }



        public void Destroy()
        {

        }

    }

}
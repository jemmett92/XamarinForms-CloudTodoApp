using Xamarin.Forms;

namespace PrismUnityToDolistMobile.Views
{
    public partial class MyMasterDetail : MasterDetailPage, IMasterDetailPageController
    {
        public MyMasterDetail()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }

        public void OnMenuItemSelected()
        {

        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectDetect.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjectDetect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();
            InitialiseScreen();
        }

        void InitialiseScreen(){
            NavigationPage.SetHasNavigationBar(this, false);
            MasterBehavior = MasterBehavior.Popover;

            Master = new MenuPage();
            
            //Detail = new NavigationPage(new MainTabbedPage());
            Detail = new NavigationPage(new ObjectListScreen());
            //MenuPages.Add((int)MenuItemType.SDGReportList, (NavigationPage)Detail);
            
        }
    }
}

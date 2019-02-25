using System;
using System.Collections.Generic;
using System.Diagnostics;
using ObjectDetect.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjectDetect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            Title = "Menu";
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{Id=MenuItemType.ObjectList, Title="Object Reports"},
                new HomeMenuItem{Id=MenuItemType.Settings, Title="Settings"}
            };
            ListViewMenu.ItemsSource = menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                Debug.WriteLine("MenuPage: Got to page id: " + id);
                //await RootPage.NavigateFromMenu(id);
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ObjectDetect.DataStructures;
using ObjectDetect.ViewModel;
using Xamarin.Forms;

namespace ObjectDetect.Views
{
    public partial class ObjectListScreen : ContentPage
    {
        private ListView detectedObjectsListView;
        private bool isTapped = false;
        private ObservableCollection<DetectedObject> ObjectDetectedList;
        public ObjectListScreen()
        {
            InitializeComponent();
            //test
            TestList();

            InitialiseScreen();
        }


        void InitialiseScreen()
        {
            //create the list view
            //create the customised list view for detected objects and add it to our layout
            DetectedObjectsListViewModel thisListViewModel = new DetectedObjectsListViewModel();
            thisListViewModel.detectedObjectsListView.ItemsSource = ObjectDetectedList;
            detectedObjectsListView = thisListViewModel.detectedObjectsListView;
            RootStackLayoutMap.Children.Add(detectedObjectsListView);
        }

        void TestList()
        {
            ObjectDetectedList = new ObservableCollection<DetectedObject>();
            for (int i = 0; i < 10; i++)
            {
                DetectedObject fillItem = new DetectedObject()
                {
                    ID = i,
                    Name = "Detected object " + i + 1,

                };
                ObjectDetectedList.Add(fillItem);
            }
        }

        async void OnNewReportClick(object sender, EventArgs e)
        {
            //this stops us spamming the new page button
            if (isTapped == true)
            {
                return;
            }

            isTapped = true;
            //Debug.WriteLine("###$@GotoNewItemPAge Page");
            /*NavigationPage newPageItem = new NavigationPage(new ObjectReportScreen()
            {
                //Style = (Style)Application.Current.Resources["navPageStyle"]
            });*/
            //newPageItem.Style = (Style)Application.Current.Resources["navPageStyle"];
            await Navigation.PushAsync(new ObjectReportScreen());
            isTapped = false;
        }
    }
}

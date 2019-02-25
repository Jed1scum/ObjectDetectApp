using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ObjectDetect.DataStructures;
using ObjectDetect.Models;
using ObjectDetect.Views;
using Xamarin.Forms;

namespace ObjectDetect.ViewModel
{
    public class DetectedObjectsListViewModel : BaseViewModel
    {
        private bool isTapped = false;

        public ListView detectedObjectsListView { get; set; }
        public ObservableCollection<DetectedObject> ObjectDetectedList { get; set; }
        public DetectedObjectsListViewModel()
        {
            Title = "Detected Objects List";
            InitialiseViewModel();
        }

        void InitialiseViewModel(){
            //create the list view
            //populate the list view with elements based on its template
            //Get the detected objects
            DetectedObject newDetectedObject = new DetectedObject()
            {
                ID = 1,
                Name = "ListItem",
                DetectedDate = DateTime.Now
            };
            //create the list item 
            ObjectDetectListItem thisListItem = new ObjectDetectListItem(newDetectedObject);
            detectedObjectsListView = new ListView()
            {
                ItemsSource = ObjectDetectedList,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasUnevenRows = false,
                RowHeight = 50,
                IsPullToRefreshEnabled = false,
                SeparatorVisibility = SeparatorVisibility.None,
                ItemTemplate = thisListItem.listItemTemplate
            };
            detectedObjectsListView.ItemTapped += OnClicked;


        }

        void OnDelete(object sender, EventArgs e)
        {
            //some black magic to cast our sender object to a SDGLoadReportObject which is what the list is holding
            var mItem = ((MenuItem)sender);
            DetectedObject thisReportItem = ((DetectedObject)mItem.CommandParameter);

        }

        async void OnClicked(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine("DetectedObjectListViewItem: is clicked");

            //this stops us spamming the new page button
            if (isTapped == true)
            {
                return;
            }

            isTapped = true;
            //Debug.WriteLine("###$@GotoNewItemPAge Page");
            //some black magic to cast our sender object to a SDGLoadReportObject which is what the list is holding
            //var mItem = ((MenuItem)sender);
            DetectedObject thisReportDetectedObject = (DetectedObject)e.Item;

            Debug.WriteLine(thisReportDetectedObject);


            NavigationPage newPageItem = new NavigationPage(new ObjectReviewScreen(thisReportDetectedObject)
            {
                //Style = (Style)Application.Current.Resources["navPageStyle"]
            });
            //newPageItem.Style = (Style)Application.Current.Resources["navPageStyle"];
            await App.Current.MainPage.Navigation.PushAsync(new ObjectReviewScreen(thisReportDetectedObject));

            isTapped = false;

        }
    }
}

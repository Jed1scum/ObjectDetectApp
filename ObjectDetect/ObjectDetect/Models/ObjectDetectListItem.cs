using System;
using ObjectDetect.DataStructures;
using ObjectDetect.ViewModel;
using ObjectDetect.Views;
using Xamarin.Forms;

namespace ObjectDetect.Models
{
    public class ObjectDetectListItem : BaseViewModel
    {
        private bool isTapped = false;
        public DataTemplate listItemTemplate { get; set; }
        private DetectedObject detectedObject;
        public ObjectDetectListItem(DetectedObject thisObject)
        {
            detectedObject = thisObject;
            //create new list item template, have have it referenceable
           listItemTemplate = CreateTemplate();
        }

        public DataTemplate CreateTemplate()
        {
            DataTemplate thisDataTemplate = new DataTemplate(() =>
            {
                StackLayout listViewLayout = new StackLayout()
                {

                };
                Label title = new Label();
                title.SetBinding(Label.TextProperty, "Name");
                

                listViewLayout.Children.Add(title);

                //swipe out delete
                MenuItem deleteMenuItem = new MenuItem()
                {
                    Text = "Delete",
                    IsDestructive = true,
                };
                var deleteAction = deleteMenuItem;//new MenuItem { Text = "Delete", IsDestructive = true }; // red background
                deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                deleteAction.Clicked += OnDelete;

                ViewCell thisCell = new ViewCell();
                thisCell.View = listViewLayout;
                thisCell.ContextActions.Add(deleteAction);


                return thisCell;
            });

            return thisDataTemplate;

        }

        void OnDelete(object sender, EventArgs e)
        {
            //some black magic to cast our sender object to a SDGLoadReportObject which is what the list is holding
            var mItem = ((MenuItem)sender);
            DetectedObject thisReportItem = ((DetectedObject)mItem.CommandParameter);

        }


    }
}

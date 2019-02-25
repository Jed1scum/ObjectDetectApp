using System;
using System.Collections.Generic;
using ObjectDetect.DataStructures;
using Xamarin.Forms;

namespace ObjectDetect.Views
{
    public partial class ObjectReviewScreen : ContentPage
    {
        private DetectedObject detectedObject;
        public ObjectReviewScreen(DetectedObject thisObject)
        {
            InitializeComponent();
            detectedObject = thisObject;
            Initialise();
        }

        void Initialise()
        {
            //read and display the data
            Label objectName = new Label()
            {
                Text = detectedObject.Name
            };

            Label objectDate = new Label()
            {
                Text = detectedObject.DetectedDate.ToShortDateString()
            };

            StackLayout nameLayout = new StackLayout();
            StackLayout dateLayout = new StackLayout();

            nameLayout.Children.Add(objectName);
            dateLayout.Children.Add(objectDate);

            MainLayout.Children.Add(nameLayout);
            MainLayout.Children.Add(dateLayout);

            
        }
    }
}

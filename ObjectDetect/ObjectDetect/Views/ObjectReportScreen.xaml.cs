using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using ObjectDetect.Models;
using Xamarin.Forms;

namespace ObjectDetect.Views
{
    public partial class ObjectReportScreen : ContentPage
    {
        string defaultImageSource = "ObjectDetect.Resources.Images.notfound.jpg";
        private bool isTapped = false;

        private ObjectDetectCamera objectDetectCamera;
        public ObjectReportScreen()
        {
            InitializeComponent();

            InitialisePage();
        }

        void InitialisePage()
        {
            //set our default image source
            SetCapturedImagePathResource(defaultImageSource);
            objectDetectCamera = new ObjectDetectCamera();
        }

        void SetCapturedImagePathResource(string path)
        {
            CapturedImageLayout.Source = ImageSource.FromResource(path, typeof(ObjectReportScreen).GetTypeInfo().Assembly);
        }

        void SetCapturedImagePath(string path)
        {
            CapturedImageLayout.Source = path;
        }

        async void OnTakePhoto(object sender, EventArgs e)
        {
                //this stops us spamming the new page button
                if (isTapped == true)
                {
                    return;
                }

                isTapped = true;

                string capturedPhotoPath = await objectDetectCamera.TakePhoto();

                SetCapturedImagePath(capturedPhotoPath);
                Debug.WriteLine("ObjectReportPage: Saving picker " + " with path " + capturedPhotoPath);

                isTapped = false;
            }

    }
}

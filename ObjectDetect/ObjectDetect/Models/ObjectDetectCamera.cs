using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace ObjectDetect.Models
{
    public class ObjectDetectCamera
    {
        public ObjectDetectCamera()
        {
        }


        //Take a photo, and save a reference for us to use in our report
        public async Task<string> TakePhoto()
        {
            Debug.WriteLine("Camera: TakePhoto");
            string capturedImage = "";
            bool cameraPermissionResult = await CheckCameraPermissions();
            if (cameraPermissionResult == true)
            {
                Debug.WriteLine("Camera: permissions are ok, now lets take a photo");
                capturedImage = await CaptureImage();
            }
            else
            {
                Debug.WriteLine("CameraPreviewPage: Can't Take photo");
            }



            //store the image with the picker that we originally passed in the constructor of this class

            //await CurrentCarouselPickerManager.CarouselPickersList[carouselPickerIndex].SetCapturedImage(photo.Path);//.CapturedImageSource = photo.Path;//PhotoImage.Source);jn
            return capturedImage;
        }


        async Task<string> CaptureImage()
        {
            Debug.WriteLine("Cameara: CaptureImage");
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = "Pictures",
                Name = "sdg_.jpg",
                PhotoSize = PhotoSize.Small //Resize to 90% of original

            });
            Debug.WriteLine("We have a photo");

            if (photo == null)
            {
                Debug.WriteLine("Camera: Photo is null, not progressing");
                return "";
            }
            else
            {
                Debug.WriteLine("Camera: Returning image path: " + photo.Path);
                return photo.Path;
            }


            //DisplayAlert("File Location", photo.Path, "OK");
            /*
            ImageSource capturedPhotoSource = ImageSource.FromStream(() =>
            {
                var stream = photo.GetStream();
                return stream;
            });*/

        }

        //do a bunch of permission checking to see if we have a camera, are allowed to use it, are allowed to store files etc.
        async Task<bool> CheckCameraPermissions()
        {
            Debug.WriteLine("Camera: CheckCameraPermissions");
            await CrossMedia.Current.Initialize();
            bool permissionsResult = false;

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);


            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                Debug.WriteLine("Camera: detected " + CrossMedia.Current.IsCameraAvailable + ", Taking photo's supported: " + CrossMedia.Current.IsTakePhotoSupported);
                return false;
            }

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {

                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
                Debug.WriteLine("CameraPreviewPage: We didn't have permissions, now attempting to request them: CameraStatus" +
                                cameraStatus + " :  storageStatus: " + storageStatus);


            }
            else
            {
                if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
                {
                    //only return true if we get to this spot i.e. all permission checks are good
                    permissionsResult = true;
                }
                else
                {
                    Debug.WriteLine("CameraPReviewPage:n Permission denied, can't take photos: Camera Status " + cameraStatus);
                }
            }

            return permissionsResult;
        }
    }
}

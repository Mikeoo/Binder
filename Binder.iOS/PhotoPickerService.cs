using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Binder.iOS;
using Binder.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoPickerService))]
namespace Binder.Services
{
    public class PhotoPickerService : IPhotoPickerService
    {

        public TaskCompletionSource<Stream> taskCompletionSource;
        public UIImagePickerController imagePicker;

        Task<Stream> IPhotoPickerService.GetImageStreamAsync()
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            //Present UIImagePickerController
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentViewController(imagePicker, true, null);

            //Return Task object
            taskCompletionSource = new TaskCompletionSource<Stream>();
            return taskCompletionSource.Task;

        }

        void OnImagePickerFinishedPickMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {

                NSData data;
                if (args.ReferenceUrl.PathExtension.Equals("PNG") ||
                    args.ReferenceUrl.PathExtension.Equals("png"))
                {
                    data = image.AsPNG();
                }
                else
                {
                    data = image.AsJPEG();
                }

                Stream stream = data.AsStream();

                UnregisterEventHandlers();

                //Set the Stream as the completion of the Task
                taskCompletionSource.SetResult(stream);
            }
            else
            {
                UnregisterEventHandlers();
                taskCompletionSource.SetResult(null);
            }

            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }

        void UnregisterEventHandlers()
        {
            imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickMedia;
            imagePicker.Canceled -= OnImagePickerCancelled;
        }
    }
}

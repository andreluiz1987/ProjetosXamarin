using System;
using System.Threading;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Views;
using System.Drawing;
using Android.Util;
using Android.Widget;
using Java.IO;

using Android.Media;
using Xamarin.Forms;
using SeeLocker.Droid.Lib.DependencyService;

namespace SeeLocker.Droid.Lib
{
    public class CameraProvider : ViewGroup, ISurfaceHolderCallback, Camera.IPictureCallback
    {
        public static Camera objCamera;

        SurfaceView mSurfaceView;

        ISurfaceHolder mHolder;

        Camera.Size mPreviewSize;

        IList<Camera.Size> mSupportedPreviewSizes;

        Camera _camera;

        public static Android.Graphics.Bitmap bitmapPictureBackup;

        public CameraProvider(Context context, Camera camera)
            : base(context)
        {
            mSurfaceView = new SurfaceView(context);
            AddView(mSurfaceView);
            // Install a SurfaceHolder.Callback so we get notified when the
            // underlying surface is created and destroyed.
            mHolder = mSurfaceView.Holder;
            mHolder.AddCallback(this);
            mHolder.SetType(SurfaceType.PushBuffers);
            camera.SetPreviewDisplay(mHolder);
            camera.StartPreview();
            _camera = camera;

            setCamera();
        }
        
        public Camera PreviewCamera
        {
            get { return _camera; }
            set
            {
                _camera = value;

                if (_camera != null)
                {
                    mSupportedPreviewSizes = PreviewCamera.GetParameters().SupportedPreviewSizes;
                    RequestLayout();
                }
            }
        }

        public static void Initialize()
        {
            if (CheckifCameraAvailable())
            {
                objCamera = getCameraInstance;
            }
        }

        public void setCamera()
        {
            mSupportedPreviewSizes = PreviewCamera.GetParameters().SupportedPreviewSizes;
            RequestLayout();
        }

        public void SwitchCamera(Camera camera)
        {
            PreviewCamera = camera;

            try
            {
                camera.SetPreviewDisplay(mHolder);
            }
            catch (Java.IO.IOException)
            {
                //Log.Error(TAG, "IOException caused by setPreviewDisplay()", exception);
            }

            Camera.Parameters parameters = camera.GetParameters();
            parameters.SetPreviewSize(mPreviewSize.Width, mPreviewSize.Height);
            RequestLayout();

            camera.SetParameters(parameters);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            // We purposely disregard child measurements because act as a
            // wrapper to a SurfaceView that centers the camera preview instead
            // of stretching it.
            int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
            int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);

            if (mSupportedPreviewSizes != null)
            {
                mPreviewSize = GetOptimalPreviewSize(mSupportedPreviewSizes, width, height);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (changed && ChildCount > 0)
            {
                Android.Views.View child = GetChildAt(0);

                int width = r - l;
                int height = b - t;

                int previewWidth = width;
                int previewHeight = height;
                if (mPreviewSize != null)
                {
                    previewWidth = mPreviewSize.Width;
                    previewHeight = mPreviewSize.Height;
                }

                // Center the child SurfaceView within the parent.
                if (width * previewHeight > height * previewWidth)
                {
                    int scaledChildWidth = previewWidth * height / previewHeight;
                    child.Layout((width - scaledChildWidth) / 2, 0,
                                 (width + scaledChildWidth) / 2, height);
                }
                else
                {
                    int scaledChildHeight = previewHeight * width / previewWidth;
                    child.Layout(0, (height - scaledChildHeight) / 2,
                                 width, (height + scaledChildHeight) / 2);
                }
            }
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            // The Surface has been created, acquire the camera and tell it where
            // to draw.
            try
            {
                if (PreviewCamera != null)
                {
                    PreviewCamera.SetPreviewDisplay(holder);
                }
            }
            catch (Java.IO.IOException)
            {
                //Log.Error(TAG, "IOException caused by setPreviewDisplay()", exception);
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            // Surface will be destroyed when we return, so stop the preview.
            if (PreviewCamera != null)
            {
                PreviewCamera.StopPreview();
                PreviewCamera.Release();
                PreviewCamera = null;
            }
        }

        public void TakePicture()
        {
            //Retira o som na hora de capturar a imagem
            AudioManager objAudioManager = (AudioManager)Xamarin.Forms.Forms.Context.GetSystemService(Context.AudioService);
            objAudioManager.SetStreamMute(Android.Media.Stream.System, true);

            //Chama o metodo que retira a photo
            objCamera.TakePicture(null, null, this);
        }

        private Camera.Size GetOptimalPreviewSize(IList<Camera.Size> sizes, int w, int h)
        {
            const double ASPECT_TOLERANCE = 0.1;
            double targetRatio = (double)w / h;

            if (sizes == null)
                return null;

            Camera.Size optimalSize = null;
            double minDiff = Double.MaxValue;

            int targetHeight = h;

            // Try to find an size match aspect ratio and size
            foreach (Camera.Size size in sizes)
            {
                double ratio = (double)size.Width / size.Height;

                if (Math.Abs(ratio - targetRatio) > ASPECT_TOLERANCE)
                    continue;

                if (Math.Abs(size.Height - targetHeight) < minDiff)
                {
                    optimalSize = size;
                    minDiff = Math.Abs(size.Height - targetHeight);
                }
            }

            // Cannot find the one match the aspect ratio, ignore the requirement
            if (optimalSize == null)
            {
                minDiff = Double.MaxValue;
                foreach (Camera.Size size in sizes)
                {
                    if (Math.Abs(size.Height - targetHeight) < minDiff)
                    {
                        optimalSize = size;
                        minDiff = Math.Abs(size.Height - targetHeight);
                    }
                }
            }

            return optimalSize;
        }

        public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
        {
            // Now that the size is known, set up the camera parameters and begin
            // the preview.

            Camera.Parameters parameters = PreviewCamera.GetParameters();
            parameters.SetPreviewSize(mPreviewSize.Width, mPreviewSize.Height);
            RequestLayout();
            PreviewCamera.SetParameters(parameters);
            PreviewCamera.StartPreview();
            _camera.StartPreview();
        }

        public static bool CheckifCameraAvailable()
        {
            if (Forms.Context.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureCamera))
                return true;
            else
                return false;
        }

        public static Camera getCameraInstance
        {
            get
            {
                try
                {
                    if (objCamera == null)
                    {
                        objCamera = Camera.Open(0);
                    }
                }
                catch (Exception e)
                {
                }
                return objCamera;
            }
        }

        public void OnPictureTaken(byte[] data, Camera camera)
        {
            Java.IO.File ExternalStorageUserRootFolder;
            Java.IO.File ImageFolderExternalStorage;

            try
            {
                // Obtém o caminho da pasta raiz do aplicativo
                ExternalStorageUserRootFolder = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "SeeLocker");

                // Obtém oc aminho da pasta de imagens do aplicativo
                var strImagePath = ExternalStorageUserRootFolder.ToString() + Java.IO.File.Separator + "Images";

                // Se a pasta de iamgens não existe
                if (!System.IO.Directory.Exists(strImagePath))
                {
                    // Cria a pasta de imagens
                    ImageFolderExternalStorage = new Java.IO.File(strImagePath);
                    ImageFolderExternalStorage.Mkdirs();
                }
  
                Android.Graphics.Bitmap bitmapPicture = Android.Graphics.BitmapFactory.DecodeByteArray(data, 0, data.Length);

                bitmapPictureBackup = Android.Graphics.BitmapFactory.DecodeByteArray(data, 0, data.Length);

                String PhotoName = String.Format("{0}.jpg", Guid.NewGuid());

                System.IO.Stream fos = new System.IO.FileStream(strImagePath + "/" + PhotoName, System.IO.FileMode.Create);
                bitmapPicture.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 50, fos);
                fos.Flush();
                fos.Close();
                bitmapPicture.Dispose();

                //Toast.MakeText(Application.Context, "Success", ToastLength.Long).Show();
            }

            catch (Exception ex)
            {
            }
            finally
            {
                camera.StartPreview();
            }
        }
    }
}

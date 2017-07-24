using System;
using System.IO;
using Xamarin;
using SeeLocker.Droid.Lib;
using SeeLocker.Library.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(DroidFile))]

namespace SeeLocker.Droid.Lib
{
    public class DroidFile : IFile
    {
        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="strImageName">String image name.</param>
        /// <param name="strImageData">String image data.</param>
        public bool SaveImage(string strImageName, string strImageData)
        {
            bool blnResult = false;
            string strImagePath;
            byte[] arrFileBytes;
            Java.IO.File ExternalStorageUserRootFolder;
            Java.IO.File ImageFolderExternalStorage;

            try
            {
                // Obtém o caminho da pasta raiz do aplicativo
                ExternalStorageUserRootFolder = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "SeeLocker");

                // Obtém oc aminho da pasta de imagens do aplicativo
                strImagePath = ExternalStorageUserRootFolder.ToString() + Java.IO.File.Separator + "Images";

                // Se a pasta de iamgens não existe
                if (!Directory.Exists(strImagePath))
                {
                    // Cria a pasta de imagens
                    ImageFolderExternalStorage = new Java.IO.File(strImagePath);
                    ImageFolderExternalStorage.Mkdirs();
                }

                // Obtém os bytes da imagem
                arrFileBytes = Convert.FromBase64String(strImageData);

                // Salva o arquivo na pasta correspondente
                using (var imageFile = new FileStream(strImagePath + Java.IO.File.Separator + strImageName, FileMode.Create))
                {
                    imageFile.Write(arrFileBytes, 0, arrFileBytes.Length);
                    imageFile.Flush();

                    blnResult = true;

                }
            }
            catch (Exception ex)
            {
            }

            return blnResult;
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="strImageName">String image name.</param>
        public string GetFile(string strImageName)
        {
            string strImagePath;
            Java.IO.File ExternalStorageUserRootFolder;

            // Obtém o caminho da pasta raiz do aplicativo
            ExternalStorageUserRootFolder = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "SeeLocker");

            // Obtém oc aminho da pasta de imagens do aplicativo
            strImagePath = ExternalStorageUserRootFolder.ToString() + Java.IO.File.Separator + "Images";

            return strImagePath + Java.IO.File.Separator + strImageName;
        }
    }
}
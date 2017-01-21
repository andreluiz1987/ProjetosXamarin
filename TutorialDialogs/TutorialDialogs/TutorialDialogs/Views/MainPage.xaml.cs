using Acr.UserDialogs;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TutorialDialogs.Views
{
    public partial class MainPage : ContentPage
    {
        List<string> lstImage = new List<string>();

        public MainPage()
        {
            InitializeComponent();

            lstImage.Add("WhatsApp.png");
            lstImage.Add("Facebook.png");
            lstImage.Add("Twitter.png");
            lstImage.Add("LinkedIn.png");


            btnToast.Clicked += ButtonToast_Clicked;
            btnLoading.Clicked += ButtonLoading_Clicked;
            btnLoadingProgress.Clicked += ButtonProgress_Clicked;
            btnActionSheet.Clicked += ButtonActionSheet_Clicked;
        }

        private void ButtonToast_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.Toast("Olá sou o Toast!!", TimeSpan.FromSeconds(5));
        }

        private async void ButtonLoading_Clicked(object sender, EventArgs e)
        {
            using (var objDialog = UserDialogs.Instance.Loading("Carregando..", null, null, true, MaskType.Black))
            {
                await Task.Delay(5000);
            }
        }

        private async void ButtonProgress_Clicked(object sender, EventArgs e)
        {
            using (var objDialog = UserDialogs.Instance.Progress("Loading Progress"))
            {
                while(objDialog.PercentComplete < 100)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                    objDialog.PercentComplete += 2;
                }
            }
        }

        private void ButtonActionSheet_Clicked(object sender, EventArgs e)
        {
            var objActionSheetConfig = new ActionSheetConfig()
                   .SetTitle("Compartilhar")
                   .SetUseBottomSheet(true);

            for (var i = 0; i < lstImage.Count; i++)
            {
                var strOption = lstImage[i].Replace(".png", "");
                var objBitmapLoader = BitmapLoader.Current.LoadFromResource(lstImage[i], null, null).Result;

                objActionSheetConfig.Add(
                   lstImage[i].Replace(".png", ""),
                   () => Result("Você selecionou a opção: " + strOption),
                   objBitmapLoader
                );
            }

            UserDialogs.Instance.ActionSheet(objActionSheetConfig);
        }

        private void Result(string message)
        {
            UserDialogs.Instance.Alert(message, null, "OK");
        }
    }
}

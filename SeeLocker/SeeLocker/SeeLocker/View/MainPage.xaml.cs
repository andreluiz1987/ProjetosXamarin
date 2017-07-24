using SeeLocker.Library.Interface;
using SeeLocker.Library.Repository;
using SeeLocker.View;
using SeeLocker.ViewModel;
using System;
using Xamarin.Forms;

namespace SeeLocker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Quem viu?";
                        
            DependencyService.Get<SeeLocker.Library.Interface.IServices>().StartService();

            etyInitialDate.Focused += (object sender, FocusEventArgs e) => {
                etyInitialDate.Unfocus();
                DependencyService.Get<IDatePicker>().ShowDatePicker(etyInitialDate);
            };

            etyEndDate.Focused += (object sender, FocusEventArgs e) => {
                etyEndDate.Unfocus();
                DependencyService.Get<IDatePicker>().ShowDatePicker(etyEndDate);
            };

            BindingContext = new MainPageViewModel();

            lstData.ItemSelected += LockerItemSelected;
        }

        private void LockerItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lstData.SelectedItem = null;
        }

        async void Configurations_OnClick(object sender, EventArgs e)
        {
            await App.App.Current.MainPage.Navigation.PushAsync(new ConfigurationPage());
        }
    }
}

using ImageCircle.Forms.Plugin.Abstractions;
using System;
using Xamarin;
using Xamarin.Forms;

namespace TutorialMasterDetail.Menu
{
    public class MenuPage : ContentPage
    {
        public ListView lstMenuItem { get; set; }

        public MenuPage()
        {
            Icon = "ic_menu.png";
            Title = "Menu";
            
            CreateMenu();
        }

        private void CreateMenu()
        {
            RelativeLayout rlHeader;
            Image imgBackgournd;
            CircleImage imgUser;
            Label lblUserName;
            Label lblUserIdentification;
            StackLayout stlClientLogo;
            StackLayout stlMenuLayout;
            StackLayout stlUserInfo;

            stlMenuLayout = new StackLayout();

            try
            {
                stlMenuLayout.Spacing = 0;
                stlMenuLayout.BackgroundColor = Color.FromHex("FFFFF");
                stlMenuLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                
                rlHeader = new RelativeLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromHex("FF0000"),
                };

                stlClientLogo = new StackLayout
                {
                    Spacing = 0,
                    Padding = new Thickness(0, 0, 0, 25),
                    BackgroundColor = Color.FromHex("D1D1D1")
                };
                
                stlUserInfo = new StackLayout
                {
                    Spacing = 0,
                    Padding = new Thickness(25, 10),
                    BackgroundColor = Color.FromHex("D1D1D1")
                };

                imgUser = new CircleImage
                {
                    BorderColor = Color.White,
                    BorderThickness = 2,
                    HeightRequest = 60,
                    WidthRequest = 60,
                    Aspect = Aspect.AspectFill,
                    HorizontalOptions = LayoutOptions.Start,
                    Source = UriImageSource.FromFile("icon.png")
                };

                imgBackgournd = new Image
                {
                    Aspect = Aspect.AspectFill,
                    Source = UriImageSource.FromFile("ic_background.png")
                };
                
                lblUserName = new Label
                {
                    TextColor = Color.FromHex("FEFEFE"),
                    FontAttributes = FontAttributes.Bold,
                    Text = "Fulano da Silva"
                };

                lblUserIdentification = new Label
                {
                    TextColor = Color.FromHex("FEFEFE"),
                    Text = "fulandoSilva@gmail.com"
                };
                
                lstMenuItem = new MenuListView();

                stlUserInfo.Children.Add(lblUserName);
                stlUserInfo.Children.Add(lblUserIdentification);

                rlHeader.Children.Add(imgBackgournd,
                    null,
                    null,
                    Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    Constraint.Constant(150));

                rlHeader.Children.Add(imgUser,
                    Constraint.Constant(20),
                    null,
                    Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    Constraint.RelativeToParent((parent) => { return parent.Height; }));

                rlHeader.Children.Add(lblUserName,
                                Constraint.Constant(20),
                                Constraint.RelativeToParent((parent) =>
                                {
                                    return parent.Height - 22;
                                }),
                                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                Constraint.RelativeToParent((parent) => { return parent.Height; })
                            );

                rlHeader.Children.Add(lblUserIdentification,
                    Constraint.Constant(20),
                    Constraint.RelativeToParent((parent) =>
                    {
                        return parent.Height - 5;
                    }),
                    Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    Constraint.RelativeToParent((parent) => { return parent.Height; })
                );

                stlClientLogo.Children.Add(rlHeader);                
                stlMenuLayout.Children.Add(stlClientLogo);
                stlMenuLayout.Children.Add(lstMenuItem);
            }
            catch (Exception ex)
            {
            }
            
            Content = stlMenuLayout;
        }
    }
}



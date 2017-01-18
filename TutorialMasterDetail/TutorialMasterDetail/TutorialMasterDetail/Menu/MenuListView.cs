using System;
using System.Collections.Generic;
using TutorialMasterDetail.Model;
using TutorialMasterDetail.Views;
using Xamarin;
using Xamarin.Forms;

namespace TutorialMasterDetail.Menu
{
	public class MenuListView : ListView
	{
		public MenuListView ()
		{
			try
			{
				DataTemplate objItemMenuTemplate;
                
				VerticalOptions = LayoutOptions.FillAndExpand;
				BackgroundColor = Color.Transparent;
				SeparatorVisibility = SeparatorVisibility.Default;
                
				ItemsSource = GetMenuItemList ();
                
                objItemMenuTemplate = new DataTemplate(typeof(MenuCell));
                objItemMenuTemplate.SetBinding(MenuCell.TitleProperty, "Title");
                objItemMenuTemplate.SetBinding(MenuCell.TitleColorProperty, "TitleColor");
                objItemMenuTemplate.SetBinding(MenuCell.IconSourceProperty, "IconSource");
                
                ItemTemplate = objItemMenuTemplate;
            }
			catch(Exception ex)
			{
			}
		}
        
		private List<ItemMenu> GetMenuItemList()
		{
			List<ItemMenu> lstItemMenu;

			try
			{
				lstItemMenu = new List<ItemMenu> ();
                
				lstItemMenu.Add (new ItemMenu () { 
					Title = "Editar", 
					TitleColor = Color.FromHex("454545"),
					TitleWeight = FontAttributes.Bold,
					IconSource = "ic_edit.png",
                    TargetType = typeof(FirstPage)
                });

                lstItemMenu.Add(new ItemMenu()
                {
                    Title = "Configurações",
                    TitleColor = Color.FromHex("454545"),
                    TitleWeight = FontAttributes.Bold,
                    IconSource = "ic_settings.png",
                    TargetType = typeof(SecondPage)
                });

            }
			catch(Exception ex)
			{
				lstItemMenu = null;
			}

			return lstItemMenu;
		}
	}
}


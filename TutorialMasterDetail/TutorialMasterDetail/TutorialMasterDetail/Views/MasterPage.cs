using System;
using System.Linq;
using TutorialMasterDetail.Menu;
using Xamarin.Forms;

namespace TutorialMasterDetail.Views
{
	public class MasterPage : MasterDetailPage
	{
		MenuPage objMenuPage;

        public MasterPage()
        {
            objMenuPage = new MenuPage();
            
            objMenuPage.lstMenuItem.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                NavigateTo(e.SelectedItem as ItemMenuModel);
            };

            Master = objMenuPage;
            Detail = new NavigationPage(new FirstPage()) {};
        }
        
		private void NavigateTo (ItemMenuModel objItemMenu)
		{
			Page objPageDisplay;

			if (objItemMenu == null) 
			{
				return;
			}
            
			objPageDisplay = (Page)Activator.CreateInstance (objItemMenu.TargetType);
            
			Detail = new NavigationPage(objPageDisplay);
            
			objMenuPage.lstMenuItem.SelectedItem = null;

			IsPresented = false;
		}      
    }
}



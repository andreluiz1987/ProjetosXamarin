using Xamarin.Forms;

namespace TutorialMasterDetail.Menu
{
	public class MenuCell : ViewCell
	{
		public static readonly BindableProperty TitleProperty = BindableProperty.Create ("Title", typeof(string), typeof(MenuCell), "");
		public static readonly BindableProperty TitleColorProperty = BindableProperty.Create ("TitleColor", typeof(Color), typeof(MenuCell), Color.Transparent);
		public static readonly BindableProperty TitleWeightProperty = BindableProperty.Create ("TitleWeight", typeof(FontAttributes), typeof(MenuCell), FontAttributes.None);
		public static readonly BindableProperty IconSourceProperty = BindableProperty.Create ("IconSource", typeof(string), typeof(MenuCell), "");

		public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

		public Color TitleColor
        {
            get { return (Color)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

		public FontAttributes TitleWeight
        {
            get { return (FontAttributes)GetValue(TitleWeightProperty); }
            set { SetValue(TitleWeightProperty, value); }
        }
			
		public string IconSource
        {
            get { return (string)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

		public MenuCell()
		{
			Image imgCell;
			StackLayout stlCell;
			StackLayout stlTitle;
			Label lblTitle;
            
			stlCell = new StackLayout();
			stlCell.Orientation = StackOrientation.Horizontal;
			stlCell.VerticalOptions = LayoutOptions.FillAndExpand;
			stlCell.HorizontalOptions = LayoutOptions.FillAndExpand;
			stlCell.Padding = new Thickness (15, 0);
			stlCell.BackgroundColor = Color.Transparent;

			imgCell = new Image ();
			imgCell.SetBinding (Image.SourceProperty, "IconSource");

			stlTitle = new StackLayout();
			stlTitle.Orientation = StackOrientation.Horizontal;
			stlTitle.VerticalOptions = LayoutOptions.FillAndExpand;
			stlTitle.HorizontalOptions = LayoutOptions.FillAndExpand;
			stlTitle.Padding = new Thickness (10, 0, 0, 0);

			lblTitle = new Label ();
			lblTitle.SetBinding (Label.TextProperty, "Title");
			lblTitle.SetBinding (Label.TextColorProperty, "TitleColor");
			lblTitle.SetBinding (Label.FontAttributesProperty, "TitleWeight");
			lblTitle.VerticalTextAlignment = TextAlignment.Center;
			lblTitle.FontSize = 16;
            
			stlTitle.Children.Add (lblTitle);
			stlCell.Children.Add (imgCell);
			stlCell.Children.Add (stlTitle);
            
			View = stlCell;
		}
	}
}


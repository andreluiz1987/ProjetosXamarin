using System;
using Xamarin.Forms;

namespace TutorialMasterDetail.Model
{
	public class ItemMenu
	{
		public string Title { get; set; }
		public Color TitleColor { get; set; }
		public FontAttributes TitleWeight { get; set; }
		public string IconSource { get; set; }
		public Type TargetType { get; set; }

	}
}


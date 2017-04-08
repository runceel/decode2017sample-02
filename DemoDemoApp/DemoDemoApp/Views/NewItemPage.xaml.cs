using System;

using DemoDemoApp.Models;

using Xamarin.Forms;
using Microsoft.Azure.Mobile.Analytics;
using System.Collections.Generic;

namespace DemoDemoApp.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();

			Item = new Item
			{
				Text = "Item name",
				Description = "This is a nice description"
			};

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopToRootAsync();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Analytics.TrackEvent(
                "NewItemPage appearing.",
                new Dictionary<string, string> { { "Category", "Trace" } });
        }
    }
}
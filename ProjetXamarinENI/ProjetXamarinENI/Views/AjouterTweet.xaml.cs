using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProjetXamarinENI.Models;

namespace ProjetXamarinENI.Views
{

    [DesignTimeVisible(false)]
    public partial class AjouterTweet : ContentPage
    {
        public Tweet Tweet { get; set; }

        public AjouterTweet()
        {
            InitializeComponent();

            /*  Item = new Item
              {
                  Text = "Item name",
                  Description = "This is an item description."
              };*/

       /*     Tweet = new Tweet
            {
                Title = "Ttit",
                Description = "hsfoeslfsd"
            };*/

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Tweet);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
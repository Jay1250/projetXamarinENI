using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ProjetXamarinENI.Models;
using ProjetXamarinENI.Views;
using ProjetXamarinENI.ViewModels;

namespace ProjetXamarinENI.Views
{

    [DesignTimeVisible(false)]
    public partial class TweetPage : ContentPage
    {
        TweetViewModel viewModel;

        public TweetPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TweetViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AjouterTweet()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tweets.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
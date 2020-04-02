using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ProjetXamarinENI.Models;
using ProjetXamarinENI.Views;

namespace ProjetXamarinENI.ViewModels
{
    public class TweetViewModel : TweetBaseViewModel
    {
        public ObservableCollection<Tweet> Tweets { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TweetViewModel()
        {
            Title = "Tweet";
            Tweets = new ObservableCollection<Tweet>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AjouterTweet, Tweet>(this, "Ajouter Tweet", async (obj, tweet) =>
            {
                var newTweet = tweet as Tweet;
                Tweets.Add(newTweet);
                await DataStore.AddItemAsync(newTweet);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Tweets.Clear();
                var tweets = await DataStore.GetItemsAsync(true);
                foreach (var tweet in tweets)
                {
                    Tweets.Add(tweet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
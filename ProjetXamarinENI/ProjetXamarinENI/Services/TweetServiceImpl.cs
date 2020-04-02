using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetXamarinENI.Models;

namespace ProjetXamarinENI.Services
{
    public class TweetServiceImpl : ITweetService<Tweet>
    {
        readonly List<Tweet> tweets;

        public TweetServiceImpl()
        {
            tweets = new List<Tweet>()
            {
                new Tweet { Title = "Ttit", Description = "hsfoeslfsd"},
                new Tweet { Title = "Ttit", Description = "hsfoeslfsd"},
                new Tweet { Title = "Ttit", Description = "hsfoeslfsd"}
        };
        }

        public async Task<bool> AddItemAsync(Tweet tweet)
        {
            tweets.Add(tweet);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Tweet tweet)
        {
            var oldItem = tweets.Where((Tweet arg) => arg.Id == tweet.Id).FirstOrDefault();
            tweets.Remove(oldItem);
            tweets.Add(tweet);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = tweets.Where((Tweet arg) => arg.Id == id).FirstOrDefault();
            tweets.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Tweet> GetItemAsync(string id)
        {
            return await Task.FromResult(tweets.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Tweet>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(tweets);
        }
    }
}
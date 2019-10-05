using Fiap.CloseRain.Domain.Interfaces.Service;
using System;
using System.Net;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Tweet = Fiap.CloseRain.Domain.Entities.Services.Tweet;

namespace Fiap.CloseRain.Service.Twitter.Services
{
    public class TwitterService : ITwitterService
    {

        private readonly string AccessToken = "1126277588668829696-GFGeGza2Gfj2RcLBl1wzhNZfJq3Ddn";
        private readonly string AccessSecret = "ZImtS05huKKnhCaONpIkIj1eLzFHvOOTOw3TQRpCwToP0";
        private readonly string ConsumerSecret = "naP0nMEG51TTyJGdFyVd3tSNaCfJncatJo1s6I6JLIOG4t8oHT";
        private readonly string ConsumerKey = "sN31cBmu0lQbInLiz154UKmAz";
        public void Lembrar()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public async Task<bool> Tweet(Tweet tweet)
        {
            try
            {

                Auth.SetCredentials(new TwitterCredentials(ConsumerKey, ConsumerSecret,AccessToken,AccessSecret));
                var result = await Task.Run(() => 
                    Tweetinvi.Tweet.PublishTweet(Tweetinvi.Tweet.CreatePublishTweetParameters(tweet.Message))
                    ); 
                
                return result.IsTweetPublished;
            }
            catch  (Exception e)
            {
                throw;
            }
            
        }

        public async Task<bool> TweetWithCoordinates(Tweet tweet)
        {
            try
            {

                Auth.SetCredentials(new TwitterCredentials(ConsumerKey, ConsumerSecret, AccessToken, AccessSecret));
                var result = await Task.Run(() =>
                    Tweetinvi.Tweet.PublishTweet(Tweetinvi.Tweet.CreatePublishTweetParameters(tweet.Message,new PublishTweetOptionalParameters()
                    {
                        Coordinates = new Coordinates(tweet.Latitude,tweet.Longitude)
                    }))
                );

                return result.IsTweetPublished;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        
    }
}
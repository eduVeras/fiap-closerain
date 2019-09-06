using Fiap.CloseRain.Domain.Entities.Services;
using Fiap.CloseRain.Domain.Interfaces.Service;
using System;
using System.Net;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Fiap.CloseRain.Service.Twitter.Services
{
    public class TwitterService : ITwitterService
    {   
        public void Lembrar()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public async Task<bool> Tweet(Tweet tweet)
        {
            try
            {
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
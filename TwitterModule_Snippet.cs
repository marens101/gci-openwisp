//Note: This snippet is a single file from one of my other projects, and is in no way the entire module.
    //This code is not stand-alone.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.Rest;
using Discord.Rpc;
using mBot_Admin.Modules.ConfigModule;
using mBot_Admin.Modules.SystemModule;
using mBot_Admin.Objects;
using mBot_Admin.Objects.ConfigObjects;
using mBot_Admin.Services;
using mBot_Admin.Templates;
using Newtonsoft.Json;
using RollbarDotNet;
using SharpRaven;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Models;


using Discord.WebSocket;
using Discord.Audio;
using Discord.Addons.Interactive;
using Discord.Webhook;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.Drawing;
using System.Net.Http;
using System.Collections.Specialized;
using TextmagicRest;
using TextmagicRest.Model;
using System.Web.Script.Serialization;


namespace mBot_Admin.Modules.SocialModule
{
    [Group("twitter")]
    public class NNAGuildModule : ModuleBase
    {
        [Command("info")]
        public async Task Twitter()
        {


            var auth = new TwitterAuth (TwitterAuth.AuthAccount.mBot);

            Tweetinvi.Auth.SetUserCredentials(auth.ConsumerKey, auth.ConsumerSecret, auth.userAccessToken, auth.userAccessSecret);
            //ITwitterCredentials creds = new TwitterCredentials(auth.ConsumerKey, auth.ConsumerSecret, auth.userAccessToken, auth.userAccessSecret);
            //Auth.SetCredentials(creds);
            //ITwitterCredentials creds = new TwitterCredentials("POIoW0PbBz2DjnFhRyV7zeqiK", "aPQn9iCPBlsoIPcNuZgkOxyiOwYCLOcxQmbXJ74Pg2KMVURndv", "941870760045420544-qZnj5QL5R6Hbe2Ffq3VhU4QCpjrKfeg", "x2NH2wsTDpGMDr7DN3Awx3O20fScAC84hEU0uQV5Sccny");

            var user = Tweetinvi.User.GetAuthenticatedUser();
            string reply = "Username: " + user.ScreenName + "\n"
                            + "URL: " + "https://twitter.com/mBotAdmin" + "\n"
                            //+ "Location: " + user.Location + "\n"
                            //+ "ID: " + user.Id + "\n"
                            + "Tweets Count: " + user.StatusesCount + "\n"
                            + "Friends Count: " + user.FriendsCount + "\n"
                            + "Followers Count: " + user.FollowersCount + "\n"
                            + "Favourites Count: " + user.FavouritesCount + "\n"
                            //[Broken!!!] + "Latest Tweet: " + user.Status.Text ?? "No Tweets Yet"
                            ;
            await ReplyAsync(reply);

            
        }

        [Command("tweet")]
        [RequireOwner]
        public async Task Tweet([Remainder] string text)
        {
            var auth = new TwitterAuth(TwitterAuth.AuthAccount.NNA);
            Tweetinvi.Auth.SetUserCredentials(auth.ConsumerKey, auth.ConsumerSecret, auth.userAccessToken, auth.userAccessSecret);
            var user = Tweetinvi.User.GetAuthenticatedUser();
            
            var tweet = user.PublishTweet(text);
            
            await ReplyAsync("Tweeted! URL: " + tweet.Url);
        }
    }
}

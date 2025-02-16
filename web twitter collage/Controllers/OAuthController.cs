﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Configuration;
using LinqToTwitter;
using ImageMagick;

namespace web_twitter_collage.Controllers
{
    public class OAuthController : AsyncController
    {
        // GET: OAuth
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> BeginAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    OAuthToken = ConfigurationManager.AppSettings["oauthToken"],
                    OAuthTokenSecret = ConfigurationManager.AppSettings["oauthTokenSecret"]
                }
            };

            await Task.Delay(0).ConfigureAwait(false);

            return RedirectToAction("Index", "Home");

            // These strings were used with deprecated method below (CompleteAsync)
            //string twitterCallbackUrl = "http://twittercollage.apphb.com/OAuth/Complete";
            //string twitterCallbackUrl = Url.Action("Complete", "OAuth", null, Request.Url.Scheme);
            //return await auth.BeginAuthorizationAsync(new Uri(twitterCallbackUrl));
        }

        // This method is deprecated.
        //public async Task<ActionResult> CompleteAsync()
        //{
        //    var auth = new MvcAuthorizer
        //    {
        //        CredentialStore = new SessionStateCredentialStore()
        //    };

        //    await auth.CompleteAuthorizeAsync(Request.Url);

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
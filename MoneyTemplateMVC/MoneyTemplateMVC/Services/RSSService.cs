using MoneyTemplateMVC.Models;
using MoneyTemplateMVC.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using MoneyTemplateMVC.Helper;
using MoneyTemplateMVC.Enum;
using MoneyTemplateMVC.Services.Interface;

namespace MoneyTemplateMVC.Services
{
    public class RSSService : IRSSService
    {/// <summary>
     /// The account book repository
     /// </summary>
        private IGeneralRepository<AccountBook> _accountBookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountBookRepository">The account book repository.</param>
        public RSSService(IGeneralRepository<AccountBook> accountBookRepository)
        {
            this._accountBookRepository = accountBookRepository;
        }

        /// <summary>
        /// Gets the feed data.
        /// </summary>
        /// <returns></returns>
        public SyndicationFeed GetFeedData()
        {
            UrlHelper url = new UrlHelper();
            var feed = new SyndicationFeed(
                "北風測試資料",
                "訂單RSS！",
                new Uri(url.Action("Rss", "Feed", null, "http")));

            var items = new List<SyndicationItem>();

            var models = _accountBookRepository
                .GetAll()
                .OrderByDescending(x => x.Dateee);

            foreach (var model in models)
            {
                var item = new SyndicationItem(
                    model.Remarkkk,
                    model.Amounttt.ToString(),
                    new Uri(url.Action("Detail", "Order", new { id = model.Id }, "http")),
                    "ID",
                    DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
    }
}
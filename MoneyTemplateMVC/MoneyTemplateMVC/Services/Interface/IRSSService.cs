using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Services.Interface
{
    /// <summary>
    /// IRSSService
    /// </summary>
    public interface IRSSService
    {

        /// <summary>
        /// Gets the feed data.
        /// </summary>
        /// <returns></returns>
        SyndicationFeed GetFeedData();
    }
}

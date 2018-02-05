using System.ServiceModel.Syndication;

namespace MoneyTemplateMVC.Services.Interface
{
    public interface IRSSService
    {
        SyndicationFeed GetFeedData();
    }
}
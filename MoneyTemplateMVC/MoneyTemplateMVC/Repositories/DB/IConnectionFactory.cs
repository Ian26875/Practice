using System.Data;

namespace MoneyTemplateMVC.Repositories.DB
{
    public interface IConnectionFactory
    {
        string ConnectionString { get; }
        string ProviderName { get; }
        IDbConnection Create();
    }
}
using WebApiCore.Services.Strategy.Values;

namespace WebApiCore.Services.Factory
{
    public interface IClientFactory
    {
        IValuesClient GetValuesClient();
    }
}

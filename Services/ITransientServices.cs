namespace Udemy.Dependency.Services
{
    public interface BaseService
    {
        string GuidId { get; }
    }
    public interface ITransientServices : BaseService
    {
    }
    public interface IScopedServices : BaseService
    {
    }
    public interface ISingletonServices:BaseService
    {
    }
}   

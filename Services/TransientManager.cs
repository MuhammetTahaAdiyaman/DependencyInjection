using System;

namespace Udemy.Dependency.Services
{
    public class TransientManager : ITransientServices
    {
        private string _guidId;
        public TransientManager()
        {
            _guidId = Guid.NewGuid().ToString();
        }
        public string GuidId => _guidId;
    }
    public class ScopedManager : IScopedServices
    {
        private string _guidId;
        public ScopedManager()
        {
            _guidId = Guid.NewGuid().ToString();
        }
        public string GuidId => _guidId;
    }
    public class SingletonManager : ISingletonServices
    {
        private string _guidId;
        public SingletonManager()
        {
            _guidId= Guid.NewGuid().ToString();
        }
        public string GuidId => _guidId;
    }
}

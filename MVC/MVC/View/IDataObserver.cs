using System.Collections.Generic;

namespace MVC.View
{
    public interface IDataObserver
    {
        List<string> ObserverKeys { get; set; }

        string SubscriptionKey { get; set; }

        void Update(object data);
    }
}
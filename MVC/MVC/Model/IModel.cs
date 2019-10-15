using System.Collections;
using MVC.DataAccess;
using MVC.View;

namespace MVC.Model
{
    public interface IModel
    {
        ArrayList DataObservers { get; set; }

        void RegisterObserver(IDataObserver concreteObserver, string key);

        void UnregisterObserver(IDataObserver concreteObserver);

        /// <summary>
        /// </summary>
        /// <param name="baseObject">Base class containing an Id field and a Name field</param>
        /// <param name="key"></param>
        void GetData(BaseObject baseObject, string key);
    }
}
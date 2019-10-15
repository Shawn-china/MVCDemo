using System.Collections;
using MVC.DataAccess;
using MVC.View;

namespace MVC.Model
{
    public class ConcreteModel : IModel
    {
        public ArrayList DataObservers { get; set; } = new ArrayList();

        public void RegisterObserver(IDataObserver concreteObserver, string key)
        {
            if (!this.DataObservers.Contains(concreteObserver))
            {
                this.DataObservers.Add(concreteObserver);
            }
        }

        public void UnregisterObserver(IDataObserver concreteObserver)
        {
            if (this.DataObservers.Contains(concreteObserver))
            {
                this.DataObservers.Remove(concreteObserver);
            }
        }

        public void GetData(BaseObject baseObject, string key)
        {
            this.Notity(baseObject, key);
        }

        private void Notity(BaseObject baseObject, string key)
        {
            foreach (object item in this.DataObservers)
            {
                if (((IDataObserver)item).ObserverKeys.Contains(key))
                {
                    ((IDataObserver)item).Update(baseObject);
                }
            }
        }
    }
}
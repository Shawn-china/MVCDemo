using MVC.DataAccess;
using MVC.Model;

namespace MVC.Control
{
    public class ConcreteController : IController
    {
        private readonly IModel _model;

        public ConcreteController(IModel model)
        {
            this._model = model;
        }

        public void GetDatas(BaseObject baseObject, string subscriberKey)
        {
            this._model.GetData(baseObject, subscriberKey);
        }
    }
}
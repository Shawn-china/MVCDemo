using MVC.Control;
using MVC.Model;

namespace MVC.View
{
    public class BaseRequest
    {
        public static IModel ConcreteModel;
        public static IController ConcreteController;

        public BaseRequest()
        {
            ConcreteModel = ConcreteModel ?? new ConcreteModel();
            ConcreteController = ConcreteController ?? new ConcreteController(ConcreteModel);
        }

        public BaseRequest(IModel concreteModel, IController concreteController)
        {
            ConcreteModel = ConcreteModel ?? concreteModel;
            ConcreteController = ConcreteController ?? concreteController;
        }
    }
}
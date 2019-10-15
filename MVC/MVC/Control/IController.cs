using MVC.DataAccess;

namespace MVC.Control
{
    public interface IController
    {
        void GetDatas(BaseObject baseObject, string subscriberKey);
    }
}
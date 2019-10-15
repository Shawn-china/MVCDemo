namespace MVC.DataAccess
{
    public class BaseObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
using System.Collections.Generic;

namespace MVC.DataAccess
{
    public class School : BaseObject
    {
        public List<Grade> Grades { get; set; }

        public List<Student> Students { get; set; }

        public static void Add(School obj)
        {
            DataContainer.Schools.Add(obj);
        }

        public static List<School> GetList()
        {
            return DataContainer.Schools;
        }
    }
}
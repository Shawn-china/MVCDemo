using System.Collections.Generic;
using System.Linq;

namespace MVC.DataAccess
{
    public class Grade : BaseObject
    {
        public School School { get; set; }

        public List<Student> Students { get; set; }

        public static void Add(Grade obj)
        {
            DataContainer.Grades.Add(obj);
        }

        public static List<Grade> GetList(BaseObject baseObject)
        {
            return DataContainer.Grades.Where(m => m.School != null && m.School.Id == baseObject.Id).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace MVC.DataAccess
{
    public class Student : BaseObject
    {
        public School School { get; set; }

        public Grade Grade { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public bool Sex { get; set; }

        public static void Add(Student obj)
        {
            DataContainer.Students.Add(obj);
        }

        public static List<Student> GetList(BaseObject baseObject)
        {
            switch (baseObject)
            {
                case Grade _: return DataContainer.Students.Where(m => m.Grade != null && m.Grade.Id == baseObject.Id).ToList();
                case School _: return DataContainer.Students.Where(m => m.School != null && m.School.Id == baseObject.Id).ToList();
            }

            return null;
        }
    }
}
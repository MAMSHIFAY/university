using System.Collections.Generic;
using System.Data;

namespace university
{
    public class Student
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public string Mobile { get; set; }
        public string Living { get; set; }
    }

    public class ReportDataProvider
    {
        public static List<Student> GetLeavedStudents()
        {
            var students = new List<Student>();
            string query = "SELECT name, room, mobile, living FROM newStudent WHERE living = 'No'";

            function fn = new function();  // This is your existing class
            DataSet ds = fn.GetData(query);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                students.Add(new Student
                {
                    Name = row["name"].ToString(),
                    Room = row["room"].ToString(),
                    Mobile = row["mobile"].ToString(),
                    Living = row["living"].ToString()
                });
            }

            return students;
        }
    }
}

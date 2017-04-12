using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher("Петров","Петрович","Петр", "Программрование");
            teacher.CourseEnrollment();

            (new Student("Иванов", "Иван", "Иванович")).Enroll(teacher.Course);
            (new Student("Зубрицкий", "Влад", "Станиславович")).Enroll(teacher.Course);
            (new Student("Протасевич", "Олег", "Дмитриевич")).Enroll(teacher.Course);
            (new Student("Степа", "Николай", "Иванович")).Enroll(teacher.Course);
            (new Student("Рак", "Дмитрий", "Павлович")).Enroll(teacher.Course);

            teacher.Course.Traininig();
            teacher.Attestation(teacher.Course.Students);

        }
    }
}

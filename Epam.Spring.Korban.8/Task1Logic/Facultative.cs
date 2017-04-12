using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace Task1Logic
{

    public class People
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SureName { get; set; }
        
        public People(string sureName, string name ,string middleName)
        {
            Name = name;
            MiddleName = middleName;
            SureName = sureName;
        }
    }

    public class Student:People, IStudent
    {
        public int? Valuation { get; set; }
        public Student(string sureName, string  name, string middleName) :base( sureName, name , middleName) { }

        public void Enroll(Course course)
        {
            course.Students.Add(this);
        }
    }



    public class Teacher:People,ITeacher
    {
        public Course Course { get; set; }
        public Teacher(string sureName, string name , string middleName, string courseName):base(name, sureName, middleName)
        {
            Course = new Course(courseName);
            Console.WriteLine("На курс {0} записался студент: {1} {2} {3}", courseName, SureName, Name, MiddleName);
        }

        public void CourseEnrollment()
        {
            Console.WriteLine("Идет набор на курс {0},читает курс преподователь: {1} {2} {3}", Course.CourseName, SureName, Name, MiddleName);
        }

        public void Attestation(List<Student> students)
        {
            var pathCourseDirectory = string.Format("D:\\{0}({1} {2} {3})", Course.CourseName, SureName, Name, MiddleName);
            Directory.CreateDirectory(pathCourseDirectory);
   
            foreach (var student in students)
            {
                student.Valuation = new Random().Next(1, 10);
                var pathUserFolder = pathCourseDirectory + string.Format("\\{0} {1} {1}", student.SureName, student.Name, student.MiddleName);

                CreateBinaryFile(student, pathCourseDirectory, pathUserFolder);
                CreateZipArchive(pathCourseDirectory, pathUserFolder);
            }
        }

        private void CreateBinaryFile(Student student,string pathCourseDirectory,string pathUserFolder)
        {
            Directory.CreateDirectory(pathUserFolder);
            var pathFile = pathUserFolder + string.Format("\\({0} {1} {2}).txt", student.SureName, student.Name, student.MiddleName);
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathFile, FileMode.Create)))
            {
                writer.Write(student.SureName);
                writer.Write(student.Name);
                writer.Write(student.MiddleName);
                writer.Write(student.Valuation.Value);
            }
        }

        private void CreateZipArchive(string pathCourseDirectory, string pathUserFolder)
        {
            var zip = new FastZip();
            zip.CreateZip(pathCourseDirectory + string.Format("\\({0} {1} {2}).zip", student.SureName, student.Name, student.MiddleName), pathUserFolder, true, null);
            Directory.Delete(pathUserFolder, true);
        }


    }


    public class Course: ICourse
    {
        public string CourseName { get; set; }
        public List<Student> Students { get; set; }
        public Course(string nameCourse)
        {
            CourseName = nameCourse;
            Students = new List<Student>();
        }

        public void Traininig()
        {
            Console.WriteLine("Идет обучение...");
            Thread.Sleep(2000);
        }
    }
    interface ICourse
    {
        void Traininig();
    }

}

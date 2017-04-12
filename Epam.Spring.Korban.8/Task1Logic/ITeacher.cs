using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    interface ITeacher
    {
        void CourseEnrollment();
        void Attestation(List<Student> students);
    }
}

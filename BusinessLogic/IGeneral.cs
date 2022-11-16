using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Entities;

namespace BusinessLogic
{
    public interface IGeneral
    {
        Task<ServiceResponse<string>> SaveStudent(Student student, int? idValue);
        List<Student> Read(int? idValue);
    }
}

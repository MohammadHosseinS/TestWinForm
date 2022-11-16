using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Entities;

namespace TestWinForm
{
    public class Bridge
    {
        IGeneral general;
        public Bridge(string connectionString)
        {
            general = BusinessFactory.General(connectionString);
        }

        public async Task<string> SaveStudents(Student student, int? idValue)
        {
            var response = await general.SaveStudent(student, idValue);
            if (!response.Success)
            {
                return $"ERROR \n {response.Exception}";
            }
            return response.Data;
        }

        public List<Student> Read(int? idValue)
        {
            return general.Read(idValue);
        }

    }
}

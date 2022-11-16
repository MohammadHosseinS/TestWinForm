using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogic
{
    internal class General : IGeneral
    {
        private readonly IGeneralService _generalService;

        public General(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        public async Task<ServiceResponse<string>> SaveStudent(Student student, int? idValue)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var data = await _generalService.SaveStudent(student, idValue);
                response.SetData(data);
            }
            catch (Exception e)
            {
                response.SetError(e);
            }
            return response;
        }

        public List<Student> Read(int? idValue)
        {
            return _generalService.Read(idValue);
        }

    }
}

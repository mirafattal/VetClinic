using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.Rapping;

namespace Vet_BLL._GenericService
{
    public interface IGenericService<TDto> where TDto : class
    {
        public ApiResponse<IEnumerable<TDto>> GetAll();
        public ApiResponse<TDto> GetById(int id);

        public ApiResponse<TDto> Add(TDto dto);
        public ApiResponse<TDto> Update(TDto dto);
        public ApiResponse<bool> Delete(int id);
        public ApiResponse<bool> Delete(TDto dto);
    }
}

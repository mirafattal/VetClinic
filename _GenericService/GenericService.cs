using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL.Rapping;
using Vet_DAL._GenericRepository;

namespace Vet_BLL._GenericService
{
    public class GenericService<Entity, TDto> : IGenericService<TDto>
        where Entity : class where TDto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;



        private IMapper mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        public ApiResponse<TDto> Add(TDto dto)
        {
            var response = new ApiResponse<TDto>();
            var entity = _mapper.Map<Entity>(dto);
            if (entity == null)
            {
                throw new Exception("Null");
            }
            var result = _repository.Add(entity);
            response.Data = _mapper.Map<TDto>(result);
            return response;
        }
        public virtual ApiResponse<bool> Delete(int id)
        {
            var response = new ApiResponse<bool>();
            response.Data = _repository.Delete(id);
            return response;
        }

        public virtual ApiResponse<bool> Delete(TDto dto)
        {
            var response = new ApiResponse<bool>();
            var entity = _mapper.Map<Entity>(dto);
            response.Data = _repository.Delete(entity);
            return response;

        }

        public ApiResponse<IEnumerable<TDto>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<TDto>>();
            var result = _repository.GetAll();
            response.Data = _mapper.Map<IEnumerable<TDto>>(result);
            return response;

        }

        public ApiResponse<TDto> GetById(int id)
        {
            var response = new ApiResponse<TDto>();
            var result = _repository.GetById(id);
            response.Data = _mapper.Map<TDto>(result);
            return response;
        }

        public ApiResponse<TDto> Update(TDto dto)
        {
            var response = new ApiResponse<TDto>();
            var entity = _mapper.Map<Entity>(dto);
            var result = _repository.Update(entity);
            response.Data = _mapper.Map<TDto>(result);
            return response;
        }
    }
}

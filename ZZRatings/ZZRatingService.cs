using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Owners;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.ZZRatings;

namespace Vet_BLL.Services.ZZRatings
{
    public class ZZRatingService: GenericService<Zzrating, ZZratingDto>, IZZRatingService
    {
        public readonly IZZRatingRepository _zZRatingRepository;
        public readonly IMapper _mapper;

        public ZZRatingService(IZZRatingRepository zZRatingRepository, IMapper mapper) :
            base(zZRatingRepository, mapper)
        {
            _zZRatingRepository = zZRatingRepository;
            _mapper = mapper;
        }

        public async Task<List<ZZratingDto>> GetLastThreeReviewsAsync()
        {
            var reviews = await _zZRatingRepository.GetLastThreeReviewsAsync();
            return _mapper.Map<List<ZZratingDto>>(reviews);
        }
    }
}

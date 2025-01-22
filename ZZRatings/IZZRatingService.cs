using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;

namespace Vet_BLL.Services.ZZRatings
{
    public interface IZZRatingService: IGenericService<ZZratingDto>
    {
        public Task<List<ZZratingDto>> GetLastThreeReviewsAsync();

    }
}

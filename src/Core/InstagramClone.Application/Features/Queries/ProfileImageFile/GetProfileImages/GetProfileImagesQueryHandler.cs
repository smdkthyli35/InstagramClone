using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.ProfileImageFile.GetProfileImages
{
    public class GetProfileImagesQueryHandler : IRequestHandler<GetProfileImagesQueryRequest, List<GetProfileImagesQueryResponse>>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IConfiguration _configuration;

        public GetProfileImagesQueryHandler(IProfileRepository profileRepository, IConfiguration configuration)
        {
            _profileRepository = profileRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProfileImagesQueryResponse>> Handle(GetProfileImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Profile? profile = await _profileRepository.Table.Include(p => p.ProfileImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            return profile?.ProfileImageFiles.Select(p => new GetProfileImagesQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}

using InstagramClone.Application.Abstractions.Storage;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.ProfileImageFile.UploadProfileImage
{
    public class UploadProfileImageCommandHandler : IRequestHandler<UploadProfileImageCommandRequest, UploadProfileImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IProfileRepository _profileRepository;
        private readonly IProfileImageFileRepository _profileImageFileRepository;

        public UploadProfileImageCommandHandler(IStorageService storageService, IProfileRepository profileRepository, IProfileImageFileRepository profileImageFileRepository)
        {
            _storageService = storageService;
            _profileRepository = profileRepository;
            _profileImageFileRepository = profileImageFileRepository;
        }

        public async Task<UploadProfileImageCommandResponse> Handle(UploadProfileImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Domain.Entities.Profile? profile = await _profileRepository.GetByIdAsync(request.Id);

            await _profileImageFileRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProfileImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Profiles = new List<Domain.Entities.Profile>() { profile }
            }).ToList());

            await _profileImageFileRepository.SaveAsync();

            return new();
        }
    }
}

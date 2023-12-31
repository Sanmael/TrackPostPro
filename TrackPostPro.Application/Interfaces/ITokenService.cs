﻿using DomainTrackPostPro.Entities;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Interfaces
{
    public interface ITokenService
    {
        public Task CreateToken(TokenDTO tokenDTO);
        public string CreateHash(string pass, string hash);
        public Task ResetTokenAsync(TokenDTO tokenDTO);
        public Task<TokenDTO> GetToken(Guid userId);
        public Task DeleteToken(Guid userId);

    }
}

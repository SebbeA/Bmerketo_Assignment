﻿using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;

    public UserService(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    //public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    //{
    //    var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
    //    return userProfileEntity!;
    //}
}

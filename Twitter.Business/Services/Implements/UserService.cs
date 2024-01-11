using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitFriday;
using Twitter.Business.Dtos.AuthsDtos;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;
using Twitter.Core.Enums;

namespace Twitter.Business.Services.Implements
{
    public class UserService: IUserService
    {
        UserManager<AppUser> _userManager {  get;}
        RoleManager<IdentityRole>_roleManager { get;}
        IMapper _mapper { get;}
        public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

            public async Task CreateAsync(RegisterDto dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user,dto.Password);
            if(!result.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + "");
                }
                throw new AppUserCreatedFailedException(sb.ToString().TrimEnd());
            }
            var roleResult =await _userManager.AddToRoleAsync(user, nameof(Roles.Admin));
            if(!roleResult.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + "");
                }
                 
                throw new Exception(sb.ToString().TrimEnd());
            }
        }
    }
}

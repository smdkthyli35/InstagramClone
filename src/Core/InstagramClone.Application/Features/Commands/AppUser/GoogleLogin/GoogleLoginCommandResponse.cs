using InstagramClone.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task LoginAsync();
    }
}

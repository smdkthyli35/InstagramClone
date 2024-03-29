﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState.Values.SelectMany(x => x.Errors)
                                                        .Select(x => !string.IsNullOrEmpty(x.ErrorMessage)
                                                            ? x.ErrorMessage
                                                            : x.Exception?.Message).Distinct().ToList();


                return;
            }

            await next();
        }
    }
}

﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LibUniversal.Startup
{
    public static class AutoMapping
    {
        public static void Register(WebApplicationBuilder builder)
        {
            // entity dto mapping
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

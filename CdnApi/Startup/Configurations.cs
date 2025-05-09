﻿using CdnApi.Models.Aws;

namespace CdnApi.Startup
{
    public static class Configurations
    {
        public static void Register(WebApplicationBuilder builder)
        {
            LibUniversal.Startup.Configurations.Register(builder);
            builder.Services
                .Configure<AwsSettings>(builder.Configuration.GetSection("AwsS3Bucket"));
        }
    }
}

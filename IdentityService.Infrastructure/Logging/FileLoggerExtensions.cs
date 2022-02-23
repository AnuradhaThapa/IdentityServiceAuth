using IdentityService.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityService.Infrastructure.Logging
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddTheCodeFileLogger(this ILoggingBuilder builder, Action<FileLogDetailsEntity> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}

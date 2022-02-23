using IdentityService.Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IdentityService.Infrastructure.Logging
{
    [ProviderAlias("FileLogger")]
    public class FileLoggerProvider:ILoggerProvider
    {
        public readonly FileLogDetailsEntity fileLogDetailsEntity;
        public FileLoggerProvider(IOptions<FileLogDetailsEntity> fileLogDetails)
        {
            fileLogDetailsEntity = fileLogDetails.Value;
            if(!Directory.Exists(fileLogDetailsEntity.FolderPath))
            {
                Directory.CreateDirectory(fileLogDetailsEntity.FolderPath);
            }
        }

        public ILogger CreateLogger(string category)
        {
            return new FileLogger(this);
        }
        public void Dispose()
        {

        }
    }
}

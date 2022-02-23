using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace IdentityService.Infrastructure.Logging
{
    public class FileLogger:ILogger
    {
        protected readonly FileLoggerProvider loggerProvider;
        public FileLogger([NotNull] FileLoggerProvider fileLoggerProvider)
        {
            loggerProvider = fileLoggerProvider;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel,EventId eventId,TState state,Exception exception,
            Func<TState,Exception,string> formatter)
        {
            if(!IsEnabled(logLevel))
            {
                return;
            }
            var fullFilePath = loggerProvider.fileLogDetailsEntity.FolderPath + "/" +
                loggerProvider.fileLogDetailsEntity.FilePath.Replace("{date}", DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var logRecord = string.Format("{0} [{1}] {2} {3}", "[" + DateTimeOffset.UtcNow.ToString("yyyyMMdd HH:mm:ss+00:00") + "]", 
                logLevel.ToString(), formatter(state, exception),exception != null ? exception.StackTrace : "");
            using(var streamWriter = new StreamWriter(fullFilePath,true))
            {
                streamWriter.WriteLine(logRecord);
            }
        }
    }
}

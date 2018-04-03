using Microsoft.Extensions.Logging;
using System;

namespace Collections.Model
{
    internal class TraceLoggerProvider : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
            return;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TraceLogger();
        }

        public void Dispose()
        {
            return;
        }

        private class TraceLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                System.Diagnostics.Trace.WriteLine(formatter(state, exception));
            }
        }
    }
}
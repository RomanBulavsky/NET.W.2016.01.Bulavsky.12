using NLog;

namespace Task1.Logger
{
    class NLogger : ILogger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Displayed very detailed logs, which may include high-volume information such as protocol payloads. This log level is typically only enabled during development
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Trace(string loggerMessage)
        {
            logger.Trace(loggerMessage);
        }

        /// <summary>
        /// Displayed debugging information, less detailed than trace, typically not enabled in production environment.
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Debug(string loggerMessage)
        {
            logger.Debug(loggerMessage);
        }

        /// <summary>
        /// Displayed information messages, which are normally enabled in production environment
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Info(string loggerMessage)
        {
            logger.Info(loggerMessage);
        }

        /// <summary>
        /// Displayed warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Warn(string loggerMessage)
        {
            logger.Warn(loggerMessage);
        }

        /// <summary>
        /// Displayed error messages - most of the time these are Exceptions
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Error(string loggerMessage)
        {
            logger.Error(loggerMessage);
        }

        /// <summary>
        /// Displayed very serious errors!
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        public void Fatal(string loggerMessage)
        {
            logger.Fatal(loggerMessage);
        }
    }
}
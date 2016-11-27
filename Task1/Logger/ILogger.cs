namespace Task1.Logger
{
    interface ILogger
    {
        /// <summary>
        /// Displayed very detailed logs, which may include high-volume information such as protocol payloads. This log level is typically only enabled during development
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Trace(string loggerMessage);

        /// <summary>
        /// Displayed debugging information, less detailed than trace, typically not enabled in production environment.
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Debug(string loggerMessage);

        /// <summary>
        /// Displayed information messages, which are normally enabled in production environment
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Info(string loggerMessage);

        /// <summary>
        /// Displayed warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Warn(string loggerMessage);


        /// <summary>
        /// Displayed error messages - most of the time these are Exceptions
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Error(string loggerMessage);

        /// <summary>
        /// Displayed very serious errors!
        /// </summary>
        /// <param name="loggerMessage"> Message that will appear into logfile.</param>
        void Fatal(string loggerMessage);
    }
}
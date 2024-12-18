﻿namespace Practice.BuildComplicatedFlow.Common
{
    public static class LoggerExtension
    {
        public static void LogInformation<T>(this ILogger logger, T data, string message) where T : CustomDataLogging
        {
            Log(logger, LogLevel.Information, data, message);
        }

        public static void LogWarning<T>(this ILogger logger, T data, string message) where T : CustomDataLogging
        {
            Log(logger, LogLevel.Warning, data, "Info:" + message);
        }

        public static void LogError<T>(this ILogger logger, T data, Exception exception, string message) where T : CustomDataLogging
        {
            Log(logger, LogLevel.Error, data, exception, message);
        }

        public static void LogError<T>(this ILogger logger, T data, string message) where T : CustomDataLogging
        {
            Log(logger, LogLevel.Error, data, message);
        }

        public static void LogCritical<T>(this ILogger logger, T data, string message) where T : CustomDataLogging
        {
            Log(logger, LogLevel.Critical, data, message);
        }

        public static void WriteAnException<T>(this ILogger logger, T data, string message) where T : CustomDataLogging
        {
            try {
                throw new Exception(message);
            }
            catch (Exception exception) {
                Log(logger, LogLevel.Error, data, exception, message);
                return;
            }
        }

        private static void Log<T>(ILogger logger, LogLevel logLevel, T data, string message) where T : CustomDataLogging
        {
            logger?.Log(logLevel, null, ForceStringification(message) + GetCustomMessageDimension(data), data);
        }

        private static void Log<T>(ILogger logger, LogLevel logLevel, T data, Exception exception, string message) where T : CustomDataLogging
        {
            logger?.Log(logLevel, exception, ForceStringification(message) + GetCustomMessageDimension(data), data);
        }

        private static string ForceStringification(string message)
        {
            return message?.Replace("{", "{{").Replace("}", "}}") ?? "";
        }

        /// <summary>
        /// Get custom message dimension
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetCustomMessageDimension<T>(T data) where T : CustomDataLogging
        {
            if (data == null)
                return string.Empty;

            return $" {{@{data.GetType().Name}}}";
        }
    }
}

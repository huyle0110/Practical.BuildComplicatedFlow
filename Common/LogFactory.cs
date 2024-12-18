using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Common
{
    public class LogFactory
    {
        /// <summary>
        /// Write inoformation initial log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="name"></param>
        /// <param name="stopWatch"></param>
        public static void LogInitialized(ILogger log, string name, Stopwatch stopWatch)
        {
            stopWatch.Start();
            log.LogInformation($"Initialized: {name}");
        }

        /// <summary>
        /// Write inoformation start log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="stopWatch"></param>
        public static void LogStart(ILogger log, CustomDataLogging customDataLogging, Stopwatch stopWatch)
        {
            stopWatch.Start();
            log.LogInformation(customDataLogging, $"Start: {customDataLogging}");
        }

        /// <summary>
        /// Write inoformation log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        public static void LogStart(ILogger log, CustomDataLogging customDataLogging)
        {
            log.LogInformation(customDataLogging, $"Start Operation: {customDataLogging.SubStepName} ___ {customDataLogging.SubStepNumber}");
        }

        /// <summary>
        /// Start log information
        /// </summary>
        /// <param name="className"></param>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="stopWatch"></param>
        /// <param name="methodName"></param>
        public static void LogStart(string className, ILogger log, CustomDataLogging customDataLogging, Stopwatch stopWatch, [CallerMemberName] string methodName = "")
        {
            stopWatch.Start();
            log.LogInformation(customDataLogging, $"{className}_{methodName} Start: {customDataLogging}");
        }

        /// <summary>
        /// Write inoformation finish log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        public static void LogFinish(ILogger log, CustomDataLogging customDataLogging)
        {
            log.LogInformation(customDataLogging, $"Finish Operation: {customDataLogging.SubStepName} ___ {customDataLogging.SubStepNumber}");
        }

        /// <summary>
        /// Write information start action log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        public static void LogStartAction(ILogger log, CustomDataLogging customDataLogging)
        {
            log.LogInformation(customDataLogging, $"Start Action: {customDataLogging.ActionName} ___ {customDataLogging.ActionNumber}");
        }

        /// <summary>
        /// Write information finish action log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        public static void LogFinishAction(ILogger log, CustomDataLogging customDataLogging)
        {
            log.LogInformation(customDataLogging, $"Finish Action: {customDataLogging.ActionName} ___ {customDataLogging.ActionNumber}");
        }

        /// <summary>
        /// Write inoformation finish log
        /// </summary>
        /// <param name="className"></param>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="stopWatch"></param>
        /// <param name="methodName"></param>
        public static void LogFinish(string className, ILogger log, CustomDataLogging customDataLogging, Stopwatch stopWatch, [CallerMemberName] string methodName = "")
        {
            stopWatch.Stop();
            log.LogInformation(customDataLogging, $"{className}_{methodName} Finish, End Time ellapsed={stopWatch.Elapsed}");
        }

        /// <summary>
        /// Write inoformation finish log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="name"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="stopWatch"></param>

        public static void LogFinish(ILogger log, string name, CustomDataLogging customDataLogging, Stopwatch stopWatch)
        {
            stopWatch.Stop();
            log.LogInformation(customDataLogging, $"Finish: {name}, End Time ellapsed={stopWatch.Elapsed}");
        }

        /// <summary>
        /// Write error log for each step
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="ex"></param>
        /// <param name="stepName"></param>
        public static void LogErrorStep(ILogger log, CustomDataLogging customDataLogging, Exception ex, string stepName)
        {
            log.LogError(customDataLogging, ex, $"Error Step: {stepName}");
        }

        /// <summary>
        /// Write error log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="ex"></param>
        /// <param name="serviceName"></param>
        public static void LogError(ILogger log, CustomDataLogging customDataLogging, Exception ex, string serviceName)
        {
            log.LogError(customDataLogging, ex, $"Error at {serviceName}, exception={ex}");
        }

        /// <summary>
        /// Write information log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="message"></param>
        public static void LogInformation(ILogger log, CustomDataLogging customDataLogging, string message)
        {
            log.LogInformation(customDataLogging, $"Information message={message}");
        }

        /// <summary>
        /// Write warning log
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="message"></param>
        public static void LogWarning(ILogger log, CustomDataLogging customDataLogging, string message)
        {
            log.LogWarning(customDataLogging, $"Information message={message}");
        }

        /// <summary>
        /// Log detail entities add/update/delete record. Example:
        /// Information message=Changes on CoreDbContext:
        /// - Table File: Add: 16 rows, update 0 rows, delete 14 rows
        /// - Table AttachedFile: Add: 16 rows, update 0 rows, delete 14 rows
        /// - Table ContentMetadata: Add: 8 rows, update 0 rows, delete 0 rows
        /// </summary>
        /// <param name="log"></param>
        /// <param name="customDataLogging"></param>
        /// <param name="dbContextName"></param>
        /// <param name="entitiesChanges"></param>
        public static void LogInformationWithDetailEntities(ILogger log, CustomDataLogging customDataLogging, string dbContextName, Dictionary<string, (int, int, int)> entitiesChanges)
        {
            if (entitiesChanges == null || !entitiesChanges.Any()) {
                log.LogInformation(customDataLogging, $"No change/update detect on {dbContextName}");
                return;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Changes on {dbContextName}:");
            foreach (var item in entitiesChanges.OrderBy(x => x.Key)) {
                builder.AppendLine($" - Table {item.Key}: Add: {item.Value.Item1} rows, update {item.Value.Item2} rows, delete {item.Value.Item3} rows");
            }
            log.LogInformation(customDataLogging, $"Information message={builder}");
        }
    }
}

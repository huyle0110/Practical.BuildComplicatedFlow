using Practice.BuildComplicatedFlow.Common;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Interface
{
    public interface ICopyContext
    {
        CustomDataLogging CustomDataLogging { get; set; }
        ILogger Logger { get; set; }
        CopyMainStep Step { get; set; }
        IServiceProvider TempServiceProvider { get; set; }
    }
}

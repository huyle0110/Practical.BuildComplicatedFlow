using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Interface
{
    public interface ICopyContext
    {
        ILogger Logger { get; set; }
        CopyMainStep Step { get; set; }
        IServiceProvider TempServiceProvider { get; set; }
    }
}

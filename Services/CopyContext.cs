using Practice.BuildComplicatedFlow.Interface;
using UsingEnumToBuildFlow.Enums;

namespace Practice.BuildComplicatedFlow.Services
{
    public class CopyContext : ICopyContext
    {
        public ILogger Logger { get; set; }
        public CopyMainStep Step { get; set; }
        public IServiceProvider TempServiceProvider { get; set; }
    }
}

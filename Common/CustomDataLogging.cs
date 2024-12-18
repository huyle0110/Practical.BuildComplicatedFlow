namespace Practice.BuildComplicatedFlow.Common
{
    public class CustomDataLogging
    {
        public object StepNumber { get; set; }
        public object StepName { get; set; }

        public object SubStepNumber { get; set; }
        public object SubStepName { get; set; }

        public object ActionNumber { get; set; }
        public object ActionName { get; set; }

        public void ResetCustomLogSubStep()
        {
            this.SubStepNumber = this.SubStepName;
            this.ResetCustomLogAction();
        }
        public void ResetCustomLogAction()
        {
            this.ActionName = this.ActionNumber = null;
        }
    }
}

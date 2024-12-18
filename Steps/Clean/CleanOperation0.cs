﻿using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;

namespace Practice.BuildComplicatedFlow.Steps.Clean
{
    public class CleanOperation0 : CustomDisposable, ICopyOperation<ICopyContext>
    {
        public async Task<IExecutionOperationResult> ExecuteAsync(ICopyContext context)
        {

            return ExecutionOperationResult.DoneSuccessfully(nameof(CleanOperation0));
        }

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {

            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}

using System;
using NUnit.Framework;
using System.Text;

namespace PetStore6.Constants
{
    public class AssertsAccumulator
    {
        private StringBuilder Errors { get; set; }
        private bool AssertsPassed { get; set; }

        private String AccumulatedErrorMessage
        {
            get
            {
                return Errors.ToString();
            }
        }

        public AssertsAccumulator()
        {
            Errors = new StringBuilder();
            AssertsPassed = true;
        }

        private void RegisterError(string exceptionMessage)
        {
            AssertsPassed = false;
            Errors.AppendLine(exceptionMessage);
        }

        public void Accumulate(Action assert)
        {
            try
            {
                assert.Invoke();
            }
            catch (Exception exception)
            {
                RegisterError(exception.Message);
            }
        }

        public void Release()
        {
            if (!AssertsPassed)
            {
                throw new AssertionException(AccumulatedErrorMessage);
            }
        }
    }
}

using NUnit.Framework;
using System;

namespace TestFramework.Utility
{
    public class ExceptionHandling
    {
        public static void HandleException(Exception ex)
        {
            Assert.Fail($"Error Message :{ex.Message}" + Environment.NewLine + $"Stack Trace:{ex.StackTrace}");
            SeleniumOperations.Quitdriver();
        }

    }
}

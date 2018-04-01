using System;

namespace JasonUnit.Framework
{
    public interface IOutput
    {
        void WriteSummary(int testsPassed, int testsFailed);
        void WriteHeader(string assemblyName);
        void WriteTestPassed(string displayName);
        void WriteTestFailed(Type expectedException, string displayName);
        void WriteTestFailed(object expected, object result, string displayName);
    }
}
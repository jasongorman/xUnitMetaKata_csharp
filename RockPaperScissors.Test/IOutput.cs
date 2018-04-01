using System;

namespace RockPaperScissors.Test
{
    internal interface IOutput
    {
        void WriteSummary(int testsPassed, int testsFailed);
        void WriteHeader(string assemblyName);
        void WriteTestPassed(string displayName);
        void WriteTestFailed(Type expectedException, string displayName);
    }
}
using System;
using ApprovalTests;
using ApprovalTests.Core;

namespace TestHelpers.Basics.ApprovalTestHelpers
{
    public class ApprovalsHelper
    {
        /// <summary>
        /// Special overload that makes it possible to specify a file name (and avoid using the default naming).
        /// </summary>
        /// <param name="text">The text to verify</param>
        /// <param name="fileName">The name you want to give the approvals file</param>
        public static void Verify(string text, string fileName)
        {
            Approvals.Verify(new ApprovalTextWriter(text), new ApprovalFileNamer(fileName), Approvals.GetReporter());
        }

        /// <summary>
        /// Approval namer that makes it possible to override the default file naming that includes the 
        /// entire folder structure and most often creates very long file names.
        /// </summary>
        private class ApprovalFileNamer : IApprovalNamer
        {
            public string SourcePath { get; }
            public string Name { get; }

            public ApprovalFileNamer(string name)
            {
                if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("A file name for the approvals file must be provided");

                Name = name;
                SourcePath = Approvals.GetDefaultNamer().SourcePath;
            }
        }
    }
}
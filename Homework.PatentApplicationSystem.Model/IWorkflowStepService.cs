using System.Collections.Generic;

namespace Homework.PatentApplicationSystem.Model
{
    public interface IWorkflowStepService : IUserSpecificService
    {
        IEnumerable<Case> PendingCases { get; }
        bool ContinueCase(Case @case, object value);
    }

    // TODO
    public class Case
    {
    }
}
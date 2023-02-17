using Complaint.Models;

namespace Complaint.Data
{
    public interface IDecisionRepository
    {
        List<DecisionDto> GetDecisions();

        DecisionDto CreateDecision(DecisionDto decision);

        DecisionDto? GetDecisionById(Guid decisionId);

        void DeleteDecision(Guid decisionId);

        DecisionDto UpdateComplaint(DecisionDto decision, DecisionDto newDecision);
    }
}
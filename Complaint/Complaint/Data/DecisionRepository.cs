using Complaint.Entities;
using Complaint.Models;

namespace Complaint.Data
{
    public class DecisionRepository : IDecisionRepository
    {
        private readonly DecisionContext context;

        public DecisionRepository(DecisionContext context)
        {
            this.context = context;
        }

        public List<DecisionDto> GetDecisions()
        {
            Console.WriteLine(context.Decision.ToList());
            return context.Decision.ToList();
        }

        public DecisionDto CreateDecision(DecisionDto decision)
        {
            var createdEntity = context.Add(decision);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public DecisionDto? GetDecisionById(Guid decisionId)
        {
            return context.Decision.FirstOrDefault(e => e.IdDecision == decisionId);
        }

        public void DeleteDecision(Guid decisionId)
        {
            var decision = GetDecisionById(decisionId);

            if (decision != null)
            {
                context.Remove(decision);
                context.SaveChanges();
            }
        }

        public DecisionDto UpdateComplaint(DecisionDto decision, DecisionDto newDecision)
        {
            decision.DecisionDate = newDecision.DecisionDate;
            decision.MinistryOpinion = newDecision.MinistryOpinion;
            context.SaveChanges();
            return decision;
        }
    }
}

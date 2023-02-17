using Complaint.Entities;
using Complaint.Models;

namespace Complaint.Data
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ComplaintContext context;

        public ComplaintRepository(ComplaintContext context)
        {
            this.context = context;
        }

        public List<ComplaintDto> GetComplaints()
        {
            Console.WriteLine(context.Complaint.ToList());
            return context.Complaint.ToList();
        }

        public ComplaintDto CreateComplaint(ComplaintDto complaint)
        {
            var createdEntity = context.Add(complaint);
            context.SaveChanges();
            return createdEntity.Entity;
        }

        public ComplaintDto? GetComplaintById(Guid complaintId)
        {
            return context.Complaint.FirstOrDefault(e => e.IdComplaint == complaintId);
        }

        public void DeleteComplaint(Guid complaintId)
        {
            var complaint = GetComplaintById(complaintId);

            if (complaint != null)
            {
                context.Remove(complaint);
                context.SaveChanges();
            }
        }

        public ComplaintDto UpdateComplaint(ComplaintDto complaint, ComplaintDto newComplaint)
        {
            complaint.SubmissionDate = newComplaint.SubmissionDate;
            complaint.TypeOfComplaint = newComplaint.TypeOfComplaint;
            complaint.StatusOfComplaint = newComplaint.StatusOfComplaint;
            context.SaveChanges();
            return complaint;
        }
    }
}

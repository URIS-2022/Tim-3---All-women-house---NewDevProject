using Complaint.Models;

namespace Complaint.Data
{
    public interface IComplaintRepository
    {
        List<ComplaintDto> GetComplaints();

        ComplaintDto CreateComplaint(ComplaintDto complaint);

        ComplaintDto? GetComplaintById(Guid complaintId);

        void DeleteComplaint(Guid complaintId);

        ComplaintDto UpdateComplaint(ComplaintDto complaint, ComplaintDto newComplaint);
    }
}

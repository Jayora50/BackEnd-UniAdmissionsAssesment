using System;

namespace UniAdmissionsAssesment.Entities.TransferDTOs
{
    public class BookTransferDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}

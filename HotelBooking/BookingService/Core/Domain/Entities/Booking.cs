using Domain.Enums;

namespace Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
            Status = EnStatus.Created;
        }

        public int Id { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private EnStatus Status { get; set; }
        public EnStatus CurrentStatus { get { return Status; } }
    
        public void ChangeState(EnAction action)
        {
            Status = (Status, action) switch
            {
                (EnStatus.Created, EnAction.Pay) => EnStatus.Paid,
                (EnStatus.Created, EnAction.Cancel) => EnStatus.Canceled,
                (EnStatus.Paid, EnAction.Finish) => EnStatus.Finished,
                (EnStatus.Paid, EnAction.Refound) => EnStatus.Refounded,
                (EnStatus.Canceled, EnAction.Reopen) => EnStatus.Created,
                _ => Status
            };
        }
    }
}

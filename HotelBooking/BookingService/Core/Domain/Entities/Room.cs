namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public bool IsAvailable
        {
            get
            {
                if(InMaintenance || HasGuest)
                    return false;

                return true;
            }
        }

        public bool HasGuest
        {
            // Verificar se existem Bookings abertos para esta Room
            get { return true; }
        }
    }
}

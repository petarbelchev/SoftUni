namespace BookingApp.Repositories
{
    using BookingApp.Models.Rooms.Contracts;
    using Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class RoomRepository : IRepository<IRoom>
    {
        private ICollection<IRoom> rooms;

        public RoomRepository() 
            => this.rooms = new List<IRoom>();

        public void AddNew(IRoom model) 
            => this.rooms.Add(model);

        public IReadOnlyCollection<IRoom> All() 
            => (IReadOnlyCollection<IRoom>)this.rooms;

        public IRoom Select(string roomTypeName) 
            => this.rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName);
    }
}

namespace BirthdayCelebrations
{
    public class Robot : IName, IHaveId
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.Id = id;
        }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}

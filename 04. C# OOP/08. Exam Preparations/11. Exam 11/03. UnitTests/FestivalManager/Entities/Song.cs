namespace FestivalManager.Entities
{
	using System;

	public class Song
    {
		public Song(string name, TimeSpan duration)
		{
			this.Name = name;
			this.Duration = duration;
		}

        public Song(string v1, double v2)
        {
        }

        public string Name { get; }

	    public TimeSpan Duration { get; }

	    public override string ToString()
	    {
		    return $"{this.Name} ({this.Duration:mm\\:ss})";
	    }
    }
}

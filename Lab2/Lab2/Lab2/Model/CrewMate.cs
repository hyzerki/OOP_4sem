namespace Lab1.Model
{
    public enum CrewMatePost
    {
        Pilot, CoPilot, Stewart
    }
    internal class CrewMate
    {
        public string FullName { get; set; }
        public CrewMatePost Post { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime FirstFlight { get; set; }

        public CrewMate(string fullName, CrewMatePost post, DateTime birthDay, DateTime firstFlight)
        {
            FullName = fullName;
            Post = post;
            BirthDay = birthDay;
            FirstFlight = firstFlight;
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}

namespace SimpliPassMobile.Models
{
    public class CourseModel
    {
        public string Id { get; set; }

        public string Department { get; set; }

        public double Difficulty { get; set; }

        public int DifficultyCount { get; set; }

        public string Name { get; set; }

        public Dictionary<string, double> SectionRatings { get; set; }
    }
}
namespace NativeStats.DTO
{
    public class ResultsDTO
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public ScoreDTO FullTime { get; set; }
        public ScoreDTO HalfTime { get; set; }

    }
}

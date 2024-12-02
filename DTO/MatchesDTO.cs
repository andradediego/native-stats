namespace NativeStats.DTO
{
    public class MatchesDTO
    {
        public AreaDTO Area { get; set; }
        public CompetitionDTO Competition { get; set; }
        public SeasonDTO Season { get; set; }
        public int? Id { get; set; }
        public string UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public string LastUpdated { get; set; }
        public TeamDTO HomeTeam { get; set; }
        public TeamDTO AwayTeam { get; set; }
        public ResultsDTO Score { get; set; }

    }
}

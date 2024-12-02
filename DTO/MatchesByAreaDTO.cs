namespace NativeStats.DTO
{
    public class MatchesByAreaDTO
    {
        public CompetitionDTO Competition { get; set; }
        public List<MatchesDTO> Matches { get; set; }
    }
}

namespace NativeStats.DTO
{
    public class FootbalDataDTO
    {
        public FiltersDTO Filters { get; set; }
        public ResultSetDTO ResultSet { get; set; }
        public List<MatchesDTO> Matches { get; set; }
    }
}

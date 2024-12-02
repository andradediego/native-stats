namespace NativeStats.DTO
{
    public class SeasonDTO
    {
        public int? Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public string Winner { get; set; }
    }
}

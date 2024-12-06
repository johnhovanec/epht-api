using Newtonsoft.Json;

namespace epht_api.DTO
{
    public class BirthDefectsDTO
    {
        public string Id { get; set; }
        public decimal Rate { get; set; }
        public decimal IndividualRate { get; set; }
        public string Period { get; set; }
        public string ChartLabel { get; set; }
    }
}

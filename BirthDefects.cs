using System;

namespace epht_api
{
    public class BirthDefects
    {
        public Guid Id { get; set; }

        public decimal Rate { get; set; }

        public decimal IndividualRate { get; set; }

        public string Period { get; set; }

        public string ChartLabel { get; set; }
    }
}

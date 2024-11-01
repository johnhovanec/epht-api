using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class MapSet_ColumnHeader
    {
        [Key]
        public int ColumnHeader_ID { get; set; }
        [ForeignKey("MapSet_ID")]
        public int MapSet_ID { get; set; }
        public string Field { get; set; }
        public string HeaderName { get; set; }
        public short Width { get; set; }
        public string Align { get; set; }
        public string HeaderAlign { get; set; }
        public byte Flex { get; set; }
        public string ExportHeaderName { get; set; }
        public byte CustomFormat { get; set; }
        public string Fn { get; set; }
    }
}
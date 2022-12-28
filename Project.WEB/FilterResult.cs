using System.ComponentModel.DataAnnotations;

namespace Project.WEB
{
    public class FilterResult
    {
        public long SiraNo { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public string Tarih { get; set; }
        public int GirisMiktar { get; set; }
        public int CikisMiktar { get; set; }
        public int Stok { get; set; }
    }
}

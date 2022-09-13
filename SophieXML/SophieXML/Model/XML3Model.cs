using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SophieXML.Model
{
    [XmlRoot("DSACH_CHI_TIET_DVKT", Namespace = "")]
    public class XML3Model
    {
        // Add root <DSACH>...</DSACH>
        //[XmlArray("DSACH_CHI_TIET_DVKT"), XmlArrayItem(typeof(CHI_TIET_DVKT), ElementName = "CHI_TIET_DVKT")]
        //public List<CHI_TIET_DVKT>? DSACH_CHI_TIET_DVKT { get; set; }

        [XmlElement("CHI_TIET_DVKT")]
        public List<CHI_TIET_DVKT>? CHI_TIET_DVKT { get; set; }
    }

    public class CHI_TIET_DVKT
    {
        public long? MA_LK { get; set; }
        public int? STT { get; set; }
        public double? MA_DICH_VU { get; set; }
        public string? MA_VAT_TU { get; set; }
        public int? MA_NHOM { get; set; }
        public string? GOI_VTYT { get; set; }
        public TEN_VAT_TU? TEN_VAT_TU { get; set; }
        public TEN_DICH_VU? TEN_DICH_VU { get; set; }
        public string? DON_VI_TINH { get; set; }
        public int? PHAM_VI { get; set; }
        public double? SO_LUONG { get; set; }
        public double? DON_GIA { get; set; }
        public string? TT_THAU { get; set; }
        public int? TYLE_TT { get; set; }
        public double? THANH_TIEN { get; set; }
        public string? T_TRANTT { get; set; }
        public int? MUC_HUONG { get; set; }
        public double T_NGUONKHAC { get; set; }
        public double? T_BNTT { get; set; }
        public double? T_BHTT { get; set; }
        public double? T_BNCCT { get; set; }
        public double? T_NGOAIDS { get; set; }
        public string? MA_KHOA { get; set; }
        public string? MA_GIUONG { get; set; }
        public string? MA_BAC_SI { get; set; }
        public string? MA_BENH { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public long? NGAY_YL
        {
            get
            {
                string str = $"{this.NGAY_YL_VALUE?.Year}{this.NGAY_YL_VALUE?.Month}{this.NGAY_YL_VALUE?.Day}{this.NGAY_YL_VALUE?.Hour}{this.NGAY_YL_VALUE?.Minute}";//202208310825
                return long.Parse(str);
            }
            set
            {
                string str = $"{value}";//202208310825
                this.NGAY_YL_VALUE = new DateTime(int.Parse(str.Substring(0, 4)), int.Parse(str.Substring(4, 2)), int.Parse(str.Substring(6, 2)),
                                                int.Parse(str.Substring(8, 2)), int.Parse(str.Substring(10, 2)), 0, 0, DateTimeKind.Unspecified);
            }
        }
        [XmlIgnore]
        public DateTime? NGAY_YL_VALUE { get; set; }

        public string? NGAY_KQ { get; set; }
        public int? MA_PTTT { get; set; }
    }

    public class TEN_VAT_TU
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class TEN_DICH_VU
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}


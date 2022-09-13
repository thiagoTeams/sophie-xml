using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SophieXML.Model
{
    [XmlRoot("TONG_HOP", Namespace = "")]
    public class XML1Model
    {
        public long? MA_LK { get; set; }
        public int? STT { get; set; }
        public string? MA_BN { get; set; }
        public HO_TEN? HO_TEN { get; set; }
        public long? NGAY_SINH { get; set; }
        public int? GIOI_TINH { get; set; }
        public DIA_CHI? DIA_CHI { get; set; }
        public string? MA_THE { get; set; }
        public long? MA_DKBD { get; set; }
        public long? GT_THE_TU { get; set; }
        public long? GT_THE_DEN { get; set; }
        public string? MIEN_CUNG_CT { get; set; }
        public TEN_BENH? TEN_BENH { get; set; }
        public string? MA_BENH { get; set; }
        public string? MA_BENHKHAC { get; set; }
        public int? MA_LYDO_VVIEN { get; set; }
        public string? MA_NOI_CHUYEN { get; set; }
        public int? MA_TAI_NAN { get; set; }
        public long? NGAY_VAO { get; set; }
        public long? NGAY_RA { get; set; }
        public int? SO_NGAY_DTRI { get; set; }
        public int? KET_QUA_DTRI { get; set; }
        public int? TINH_TRANG_RV { get; set; }
        public long? NGAY_TTOAN { get; set; }
        public long? T_THUOC { get; set; }
        public string? CHUKYDONVI { get; set; }
        public int? T_VTYT { get; set; }
        public long? T_TONGCHI { get; set; }
        public long? T_BNTT { get; set; }
        public long? T_BNCCT { get; set; }
        public long? T_BHTT { get; set; }
        public int? T_NGUONKHAC { get; set; }
        public int? T_NGOAIDS { get; set; }
        public int? NAM_QT { get; set; }
        public int? THANG_QT { get; set; }
        public int? MA_LOAI_KCB { get; set; }
        public string? MA_KHOA { get; set; }
        public long? MA_CSKCB { get; set; }
        public string? MA_KHUVUC { get; set; }
        public string? MA_PTTT_QT { get; set; }
        public string? CAN_NANG { get; set; }
    }

    public class HO_TEN
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class DIA_CHI
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class TEN_BENH
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


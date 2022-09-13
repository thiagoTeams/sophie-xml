using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace SophieXML.Model
{
    [XmlRoot("DSACH_CHI_TIET_DIEN_BIEN_BENH", Namespace = "")]
    public class XML5Model
    {
        // Add root <DSACH>...</DSACH>
        //[XmlArray("DSACH_CHI_TIET_DIEN_BIEN_BENH"), XmlArrayItem(typeof(CHI_TIET_DIEN_BIEN_BENH), ElementName = "CHI_TIET_DIEN_BIEN_BENH")]
        //public List<CHI_TIET_DIEN_BIEN_BENH>? DSACH_CHI_TIET_DIEN_BIEN_BENH { get; set; }

        [XmlElement("CHI_TIET_DIEN_BIEN_BENH")]
        public List<CHI_TIET_DIEN_BIEN_BENH>? CHI_TIET_DIEN_BIEN_BENH { get; set; }
    }

    public class CHI_TIET_DIEN_BIEN_BENH
    {
        public long? MA_LK { get; set; }
        public int? STT { get; set; }
        public DIEN_BIEN? DIEN_BIEN { get; set; }
        public HOI_CHAN? HOI_CHAN { get; set; }
        public PHAU_THUAT? PHAU_THUAT { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public long? NGAY_YL
        {
            get {
                string str = $"{this.NGAY_YL_VALUE?.Year}{this.NGAY_YL_VALUE?.Month}{this.NGAY_YL_VALUE?.Day}{this.NGAY_YL_VALUE?.Hour}{this.NGAY_YL_VALUE?.Minute}";//202208310825
                return long.Parse(str);
            }
            set {
                string str = $"{value}";//202208310825
                this.NGAY_YL_VALUE = new DateTime(int.Parse(str.Substring(0, 4)), int.Parse(str.Substring(4, 2)), int.Parse(str.Substring(6, 2)),
                                                int.Parse(str.Substring(8, 2)), int.Parse(str.Substring(10, 2)), 0, 0, DateTimeKind.Unspecified);
            }
        }
        [XmlIgnore]
        public DateTime? NGAY_YL_VALUE { get; set; }
    }

    public class DIEN_BIEN
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class HOI_CHAN
    {
        private string? _data;

        [XmlText]
        public string? Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class PHAU_THUAT
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


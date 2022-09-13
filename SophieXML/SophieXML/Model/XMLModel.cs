using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SophieXML.Model
{
    [XmlRoot("GIAMDINHHS", Namespace = "")]
    public class XMLModel
    {
        [XmlElement("THONGTINDONVI")]
        public THONGTINDONVI? THONGTINDONVI { get; set; }

        [XmlElement("THONGTINHOSO")]
        public THONGTINHOSO? THONGTINHOSO { get; set; }

        [XmlElement("CHUKYDONVI")]
        public string? CHUKYDONVI { get; set; }
    }

    public class THONGTINDONVI
    {
        [XmlElement("MACSKCB")]
        public string? MACSKCB { get; set; }
    }

    public class THONGTINHOSO
    {
        [XmlElement("NGAYLAP")]
        public string? NGAYLAP { get; set; }

        [XmlElement("SOLUONGHOSO")]
        public string? SOLUONGHOSO { get; set; }

        [XmlElement("DANHSACHHOSO")]
        public DANHSACHHOSO? DANHSACHHOSO { get; set; }
    }

    public class DANHSACHHOSO
    {
        [XmlArray("HOSO"), XmlArrayItem(typeof(FILEHOSO), ElementName = "FILEHOSO")]
        public List<FILEHOSO>? HOSO { get; set; }
    }

    public class FILEHOSO
    {
        [XmlElement("LOAIHOSO")]
        public string? LOAIHOSO { get; set; } //["XML1", "XML2", "XML3", "XML5"]

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [XmlElement("NOIDUNGFILE")]
        public string? NOIDUNGFILE { get; set; }
        
        [XmlIgnore]
        [XmlElement("NOIDUNG")]
        public object? NOIDUNG { get; set; }
    }
}


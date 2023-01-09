﻿namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExpBmwCarDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

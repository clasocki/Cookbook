using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Cookbook.Models
{
    public class Recipe
    {
        [XmlElement("title")]
        public string Title { get; set; }

        public PreparationTime PreparationTime { get; set; }
    }

    public class PreparationTime
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("time")]
        public int Time { get; set; }

        [XmlAttribute("units")]
        public TimeUnit Units { get; set; }
    }

    public enum TimeUnit
    {
        [XmlEnum("h")]
        Hours,
        [XmlEnum("min")]
        Minutes,
        [XmlEnum("s")]
        Seconds
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace json_webapi.Models
{
    public class RequestModel
    {

        [DataContract]
        public class Request
        {
            [DataMember(Name = "payload")]
            public PayLoad[] Payload { get; set; }
        }

        [DataContract]
        public class PayLoad
        {
            [DataMember(Name = "country")]
            public string Country { get; set; }
            [DataMember(Name = "description")]
            public string Description { get; set; }
            [DataMember(Name = "drm")]
            public bool Drm { get; set; }
            [DataMember(Name = "episodeCount")]
            public int EpisodeCount { get; set; }
            [DataMember(Name = "genre")]
            public string Genre { get; set; }
            [DataMember(Name = "image")]
            public Image Image { get; set; }
            [DataMember(Name = "language")]
            public string Language { get; set; }
            [DataMember(Name = "nextEpisode")]
            public string NextEpisode { get; set; }
            [DataMember(Name = "primaryColour")]
            public string PrimaryColour { get; set; }
            [DataMember(Name = "seasons")]
            public List<Seasons> Seasons { get; set; }
            [DataMember(Name = "slug")]
            public string Slug { get; set; }
            [DataMember(Name = "title")]
            public string Title { get; set; }
            [DataMember(Name = "tvChannel")]
            public string TvChannel { get; set; }
        }

        public class Seasons
        {
            [DataMember(Name = "slug")]
            public string Slug { get; set; }
        }

        public class Image
        {
            [DataMember(Name = "showImage")]
            public string ShowImage { get; set; }
        }
    }
}
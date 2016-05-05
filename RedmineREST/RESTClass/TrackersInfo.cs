using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{
    [DataContract]
    public class TrackersInfo
    {
        [DataMember]
        public List<tracker> trackers { get; set; }
    }

    [DataContract]
    public class tracker
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public tracker_default_status_id default_status_id { get; set; }
    }

    [DataContract]
    public class tracker_default_status_id
    {
        [DataMember]
        public string default_status_id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}

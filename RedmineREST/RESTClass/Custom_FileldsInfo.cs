using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{
    [DataContract]
    public class Custom_FileldsInfo
    {
        [DataMember]
        public List<custom_fields_custom_field> custom_fields { get; set; }

    }

    [DataContract]
    public class custom_fields_custom_field
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string is_filter { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{

        [DataContract]
        public class ProjectsInfo
        {

            [DataMember]
            public List<project> projects { get; set; }

        }

        [DataContract]
        public class project
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string identifier { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public  string created_on { get; set; }
            [DataMember]
            public  string updated_on { get; set; }
            [DataMember]
            public string is_public { get; set; }

        }

}

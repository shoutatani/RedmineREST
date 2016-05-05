using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{
    [DataContract]
    public class UsersInfo
    {
        [DataMember]
        public List<user> users { get; set; }
    }

    [DataContract]
    public class user
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public string mail { get; set; }
        [DataMember]
        public string created_on { get; set; }
        [DataMember]
        public string last_login_on { get; set; }

        public string date_created_on { get; set; }
        public string date_last_login_on { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{

    [DataContract]
    public class MembershipsInfo
    {

        [DataMember]
        public List<membership> memberships { get; set; }

    }

    [DataContract]
    public class membership
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Membership_project project { get; set; }
        [DataMember]
        public Membership_group group { get; set; }
        [DataMember]
        public Membership_user user { get; set; }
        [DataMember]
        public List<Membership_role> roles { get; set; }
        
    }


     [DataContract]
     public class Membership_project
     {
         [DataMember]
         public int id { get; set; }
         [DataMember]
         public string name { get; set; }
     }

     [DataContract]
     public class Membership_user
     {
         [DataMember]
         public int id { get; set; }
         [DataMember]
         public string name { get; set; }
     }


     [DataContract]
     public class Membership_group
     {
         [DataMember]
         public int id { get; set; }
         [DataMember]
         public string name { get; set; }
     }

     [DataContract]
     public class Membership_role
     {
         [DataMember]
         public int id { get; set; }
         [DataMember]
         public string name { get; set; }
     }


}

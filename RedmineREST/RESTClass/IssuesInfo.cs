using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RedmineGET
{

    [DataContract]
    public class IssuesInfo
    {
        public static int C_MAX_LIMIT = 100;

        [DataMember]
        public List<issue> issues { get; set; }
        [DataMember]
        public int total_count { get; set; }
        [DataMember]
        public int offset { get; set; }
        [DataMember]
        public int limit { get; set; }

    }

    [DataContract]
    public class issue
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public issue_project project { get; set; }
        [DataMember]
        public issue_tracker tracker { get; set; }
        [DataMember]
        public issue_priority priority { get; set; }
        [DataMember]
        public issue_author author { get; set; }
        [DataMember]
        public issue_category category { get; set; }

        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string start_date { get; set; }
        [DataMember]
        public string due_date { get; set; }
        [DataMember]
        public int done_ratio { get; set; }
        [DataMember]
        public int estimated_hours { get; set; }
        [DataMember]
        public List<custom_field> custom_fields { get; set; }

        [DataMember]
        public string created_on { get; set; }
        [DataMember]
        public string updated_on { get; set; }
    }

    [DataContract]
    public class issue_project
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class issue_tracker
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    
    [DataContract]
    public class issue_status
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class issue_priority
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class issue_author
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class issue_category
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class custom_field
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string value { get; set; }
    }


}
namespace RedminePOST
{
    [DataContract]
    public class IssueInfo
    {
        [DataMember]
        public issue issue { get; set; }
    }

    [DataContract]
    public class issue
    {
        [DataMember]
        public int project_id { get; set; }
        [DataMember]
        public int tracker_id { get; set; }
        [DataMember]
        public int status_id { get; set; }
        [DataMember]
        public int priority_id { get; set; }
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string due_date { get; set; }
        [DataMember]
        public int category_id { get; set; }
        [DataMember]
        public int fixed_version_id { get; set; }
        [DataMember]
        public int assigned_to_id { get; set; }
        [DataMember]
        public int parent_issue_id { get; set; }
        [DataMember]
        public List<custom_field> custom_fields { get; set; }

    }

    [DataContract]
    public class custom_field
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string value { get; set; }
    }

}
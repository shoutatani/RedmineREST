using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedmineREST
{
    public static class Consts
    {
        // チケット登録用のテーブル列定義名称(APIを使用してPOSTで投げる際の要素名と等しい列名称のDataTable等を作成する際に必要)
        public static string C_Issues_project_id = "project_id";
        public static string C_Issues_tracker_id = "tracker_id";
        public static string C_Issues_status_id = "status_id";
        public static string C_Issues_priority_id = "priority_id";
        public static string C_Issues_subject = "subject";
        public static string C_Issues_description = "description";
        public static string C_Issues_due_date = "due_date";
        public static string C_Issues_fixed_version_id = "fixed_version_id";

        public static class Extensions
        {
            public static string C_Extension_xml = ".xml";
            public static string C_Extension_json = ".json";
        }

        public static class Errors
        {

            public static string C_Error_NullResponse = "failed to load response data.(null)";
            public static string C_Error_NotSetIdentifierOfTheProject = "For getting memberships information, please set identifier if the project(project_id)";
            public static string C_Error_WrongIdentifier = "identifier isn't contained in all project's.";

        }

    }
}

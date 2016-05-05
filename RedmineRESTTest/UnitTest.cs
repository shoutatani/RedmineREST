using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedmineGET;
using RedminePOST;
using RedmineREST;
using System.Configuration;
using System.Collections.Generic;

namespace RedmineRESTTest
{
    [TestClass]
    public class RedmineUnitTest
    {
        public static RedmineREST.RedmineREST redmine_ { get; set; }
          
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            redmine_ = new RedmineREST.RedmineREST();
            redmine_._Redmine_Access_URL = ConfigurationManager.AppSettings["Redmine_Access_URL"].ToString();
            redmine_._Redmine_API_Key = ConfigurationManager.AppSettings["Redmine_API_Key"].ToString();
        }


        [TestMethod]
        public void TestGetProjects()
        {
            List<RedmineGET.project> projects_ = redmine_.GetProjects();

            Assert.IsNotNull(projects_);

        }

        [TestMethod]
        public void TestGetTrackers()
        {
            List<RedmineGET.tracker> trackers_ = redmine_.GetTrackers();

            Assert.IsNotNull(trackers_);

        }

        [TestMethod]
        public void TestGetCustomFields()
        {
            List<RedmineGET.custom_fields_custom_field> custom_fields = redmine_.GetCustomFields();

            Assert.IsNotNull(custom_fields);

        }

        [TestMethod]
        public void TestGetUsers()
        {
            List<RedmineGET.user> users_ = redmine_.GetUsers();

            Assert.IsNotNull(users_);

        }

        [TestMethod]
        public void TestGetMemberShips()
        {
            List<RedmineGET.membership> memberships_ = redmine_.GetMemberships(ConfigurationManager.AppSettings["Test_identifier"].ToString() , redmine_.GetProjects());

            Assert.IsNotNull(memberships_);

        }

        [TestMethod]
        public void TestGetIssuesInfo()
        {
            IssuesInfo _issues_info = redmine_.GetIssuesInfo(false, "0",
                                        true, IssuesInfo.C_MAX_LIMIT.ToString(),
                                        false, "0",
                                        false, "0",
                                        false, "0",
                                        false, "*",
                                        false, "0",
                                        false, null);

            Assert.IsNotNull(_issues_info);

        }

        [TestMethod]
        public void TestGetIssues()
        {
            List<RedmineGET.issue> _issues = redmine_.GetIssues();

            Assert.IsNotNull(_issues);

        }

        [TestMethod]
        public void TestCreateIssue()
        {
            RedminePOST.issue issue_ = new RedminePOST.issue();
            issue_.project_id = 2;
            issue_.tracker_id = 3;
            issue_.status_id = 1;
            issue_.priority_id = 2;
            issue_.description = "test";
            issue_.subject = "subjecttest";
            issue_.due_date = DateTime.Now.ToString();
            issue_.category_id = 1;
            issue_.fixed_version_id = 1;
            issue_.assigned_to_id = 1;
            issue_.parent_issue_id = 0;
            List<RedminePOST.custom_field> cfs = new List<RedminePOST.custom_field>();
            RedminePOST.custom_field cf = new RedminePOST.custom_field();
            cf.id = 1;
            cf.value = "";
            cfs.Add(cf);
            cf = new RedminePOST.custom_field();
            cf.id = 2;
            cf.value = "";
            cfs.Add(cf);
            issue_.custom_fields = cfs;

            bool ret = redmine_.CreateIssue(issue_);

            Assert.IsTrue(ret);

        }

    }
}

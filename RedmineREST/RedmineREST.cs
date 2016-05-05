using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Web;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using RedmineGET;

namespace RedmineREST
{
    public class RedmineREST
    {

        // Redmine's Site Address(set Redmine's Site Address, such as "http://<IP address, or FQDN>:portNumber/")(Redmineのサイト(http://～:ポート番号/))
        public string _Redmine_Access_URL { get; set; }
        // Redmine's Access API Key(set Redmine's Access API Key, just forty characters.)(RedmineのRestAPIアクセスキー)
        public string _Redmine_API_Key { get; set; }
        
        /// <summary>
        /// constructor(コンストラクタ)
        /// </summary>
        public RedmineREST()
        {

        }

        /// <summary>
        /// constructor(コンストラクタ)
        /// </summary>
        /// <param name="Redmine_Access_URL">AccessURL</param>
        /// <param name="Redmine_API_Key">API_Key</param>
        public RedmineREST(string Redmine_Access_URL, string Redmine_API_Key)
        {
            this._Redmine_Access_URL = Redmine_Access_URL;
            this._Redmine_API_Key = Redmine_API_Key;
        }


        #region GET

            /// <summary>
            /// Get all project's information(全てのプロジェクト情報を取得)
            /// </summary>
            /// <returns>all project's information(全てのプロジェクト情報)</returns>
            public List<project> GetProjects()
            {
                try
                {

                    // Using site URL, make base URL for getting project's information with json format.(RedmineのサイトURLをベースに、プロジェクトの取得に使用するprojects.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "projects.json?";


                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _projects_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _projects_json = _sr.ReadToEnd();

                    }
                    if (_projects_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(ProjectsInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_projects_json);

                    ProjectsInfo _projects_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _projects_info = (ProjectsInfo)_serializer.ReadObject(_ms);
                    };

                    return _projects_info.projects;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
            /// <summary>
            /// Get all tracker's information(全てのトラッカー情報を取得)
            /// </summary>
            /// <returns>all tracker's information(全てのトラッカー情報)</returns>
            public List<tracker> GetTrackers()
            {
                try
                {

                    // Using site URL, make base URL for getting tracker's information with json format.(RedmineのサイトURLをベースに、トラッカーの取得に使用するtrackers.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "trackers.json?";


                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _trackers_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _trackers_json = _sr.ReadToEnd();

                    }
                    if (_trackers_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(TrackersInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_trackers_json);

                    TrackersInfo _trackers_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _trackers_info = (TrackersInfo)_serializer.ReadObject(_ms);
                    };

                    return _trackers_info.trackers;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Get all custom field's information(全てのカスタムフィールドの情報を取得)
            /// </summary>
            /// <returns>all custom field's information(全てのカスタムフィールド情報)</returns>
            public List<custom_fields_custom_field> GetCustomFields()
            {
                try
                {

                    // Using site URL, make base URL for getting custom field's information with json format.(RedmineのサイトURLをベースに、カスタムフィールドの取得に使用するcustom_fields.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "custom_fields.json?";


                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _custom_fields_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _custom_fields_json = _sr.ReadToEnd();

                    }
                    if (_custom_fields_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(Custom_FileldsInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_custom_fields_json);

                    Custom_FileldsInfo _custom_fields_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _custom_fields_info = (Custom_FileldsInfo)_serializer.ReadObject(_ms);
                    };

                    return _custom_fields_info.custom_fields;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
            /// <summary>
            /// Get all user's information(全てのユーザーの情報を取得)
            /// </summary>
            /// <returns>all user's information(全てのユーザー情報)</returns>
            public List<user> GetUsers()
            {
                try
                {

                    // Using site URL, make base URL for getting user's information with json format.(RedmineのサイトURLをベースに、ユーザー情報の取得に使用するusers.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "users.json?";


                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _users_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _users_json = _sr.ReadToEnd();

                    }
                    if (_users_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(UsersInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_users_json);

                    UsersInfo _users_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _users_info = (UsersInfo)_serializer.ReadObject(_ms);
                    };

                    return _users_info.users;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            /// <summary>
            /// Get project's membership information(プロジェクトのメンバー情報取得)
            /// </summary>
            /// <param name="identifier">porject's indetifier(プロジェクト識別子)</param>
            /// <param name="projects">all project's information(By calling GetProjects())(全てのプロジェクト情報)</param>
            /// <returns></returns>
            public List<membership> GetMemberships(string identifier, List<project> projects)
            {
                try
                {

                    // if identifier isn't set, raise exception.(identifier(プロジェクト識別名)がセットされていないときエラーとする)
                    if (identifier == null || identifier.Trim() == "")
                    {
                        throw new Exception(Consts.Errors.C_Error_NotSetIdentifierOfTheProject);
                    }
                    var _IsFound = false;
                    foreach (var _project in projects)
                    {
                        if (_project.identifier == identifier)
                        {
                            // when found the project, set to true.
                            // (引数のプロジェクト識別子に合致するものが、引数の全てのプロジェクト情報に含まれている場合は正しい)
                            _IsFound = true;
                        }
                    }
                    if (_IsFound == false)
                    {
                        // if all project's information don't contain the identifier, raise exception.
                        // (全てのプロジェクト情報を走査してもプロジェクト識別名が見つからない場合はエラーとする。)
                        throw new Exception(Consts.Errors.C_Error_WrongIdentifier);
                    }

                    // Using site URL, make base URL for getting membership's information with json format.(RedmineのサイトURLをベースに、メンバーシップ情報の取得に使用するmemberships.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "projects/" + identifier + "/memberships.json";


                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _memberships_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _memberships_json = _sr.ReadToEnd();

                    }
                    if (_memberships_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(MembershipsInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_memberships_json);

                    MembershipsInfo _memberships_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _memberships_info = (MembershipsInfo)_serializer.ReadObject(_ms);
                    };

                    return _memberships_info.memberships;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        
            /// <summary>
            /// Get issues(tickets)(チケット情報を指定した条件で取得)
            /// for further information(ex.offset,limit...), please check Redmine's HP before.
            /// http://www.redmine.org/projects/redmine/wiki/Rest_Issues
            /// </summary>
            /// <param name="IsEnable_offset">Enable offset parameter or not(offsetの指定の有効無効)</param>
            /// <param name="offset">offset value(オフセット値)</param>
            /// <param name="IsEnable_limit">Enable limit parameter or not(limitの指定の有効無効)</param>
            /// <param name="limit">limit value(チケット取得上限数)</param>
            /// <param name="IsEnable_project_id">Enable project_id parameter or not(project_idの指定の有効無効)</param>
            /// <param name="project_id">project_id value(プロジェクトID)</param>
            /// <param name="IsEnable_subproject_id">Enable subproject_id parameter or not(subproject_idの指定の有効無効)</param>
            /// <param name="subproject_id">subproject_id value(サブプロジェクトID)</param>
            /// <param name="IsEnable_tracker_id">Enable tracker_id parameter or not(tracker_idの指定の有効無効)</param>
            /// <param name="tracker_id">tracker_id value(トラッカーID)</param>
            /// <param name="IsEnable_status_id">Enable status_id parameter or not(status_idの指定の有効無効)</param>
            /// <param name="status_id">status_id value(ステータスID)</param>
            /// <param name="IsEnable_assigned_id">Enable assigned_id parameter or not(assigned_idの指定の有効無効)</param>
            /// <param name="assigned_to_id">assigned_to_id value(アサインID)</param>
            /// <param name="IsEnable_CustomFields">Enable custom field's parameter(カスタムフィールドの指定の有効無効)</param>
            /// <param name="custom_fields">custom field's value(id,value)(カスタムフィールド情報)</param>
            /// <returns>Issue's Information(チケット情報)</returns>
            public IssuesInfo GetIssuesInfo(bool IsEnable_offset, string offset,
                                            bool IsEnable_limit, string limit,
                                            bool IsEnable_project_id, string project_id,
                                            bool IsEnable_subproject_id, string subproject_id,
                                            bool IsEnable_tracker_id, string tracker_id,
                                            bool IsEnable_status_id, string status_id,
                                            bool IsEnable_assigned_id, string assigned_to_id,
                                            bool IsEnable_CustomFields, Dictionary<int, string> custom_fields)
            {
                try
                {

                    // Using site URL, make base URL for getting issue's information with json format.(RedmineのサイトURLをベースに、チケット情報の取得に使用するissues.jsonを構成)
                    string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "issues.json?";

                    if (IsEnable_offset == true)
                    {
                        _request_Uri += "offset=" + offset;
                    }

                    if (IsEnable_limit == true)
                    {
                        _request_Uri += "&limit=" + limit;
                    }

                    if (IsEnable_project_id == true)
                    {
                        _request_Uri += "&project_id=" + project_id;
                    }

                    if (IsEnable_subproject_id == true)
                    {
                        _request_Uri += "&subproject_id=" + subproject_id;
                    }

                    if (IsEnable_tracker_id == true)
                    {
                        _request_Uri += "&tracker_id=" + tracker_id;
                    }

                    if (IsEnable_status_id == true)
                    {
                        _request_Uri += "&status_id=" + status_id;
                    }

                    if (IsEnable_assigned_id == true)
                    {
                        _request_Uri += "&assigned_to_id=" + assigned_to_id;
                    }

                    if (IsEnable_CustomFields == true)
                    {
                        foreach (var custom_field in custom_fields)
                        {
                            _request_Uri += "&cf_" + custom_field.Key.ToString() + "=" + custom_field.Value.ToString();
                        }
                    }

                    WebRequest _req = WebRequest.Create(_request_Uri);
                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));

                    // By Sending HTTP_GetRequest, get HTTP_Get response. (Getリクエストを送信してレスポンスを取得)
                    WebResponse _response = _req.GetResponse();

                    // Load json data.(jsonデータをロード)
                    string _issues_json = "";
                    using (StreamReader _sr = new StreamReader(_response.GetResponseStream()))
                    {
                        _issues_json = _sr.ReadToEnd();

                    }
                    if (_issues_json.Trim() == String.Empty)
                    {
                        // if couldn't get, raise exception. (何らかの原因でjsonが取得できなかった時は失敗とする)
                        throw new Exception(Consts.Errors.C_Error_NullResponse);
                    }

                    // set Initializer(json取得用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(IssuesInfo));
                    // encode json data to Bytes data.(バイト型に変換)
                    var _jsonBytes = Encoding.Unicode.GetBytes(_issues_json);

                    IssuesInfo _issues_info = null;
                    using (MemoryStream _ms = new MemoryStream(_jsonBytes))
                    {
                        // deserialize to own information.
                        _issues_info = (IssuesInfo)_serializer.ReadObject(_ms);
                    };

                    return _issues_info;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            /// <summary>
            /// Get all Issues(tickets)(全てのチケット情報を取得)
            /// </summary>
            /// <returns>all issues(全てのチケット情報)</returns>
            public List<issue> GetIssues()
            {
                try
                {
                    // set max issue's count(in once time), and get issues.(チケット取得可能上限(limit)を上限にセットし、チケットを取得)
                    IssuesInfo _issues_info = GetIssuesInfo(false, "0",
                                                            true, IssuesInfo.C_MAX_LIMIT.ToString(),
                                                            false, "0",
                                                            false, "0",
                                                            false, "0",
                                                            false, "*",
                                                            false, "0",
                                                            false,null);
                
                    if (_issues_info.total_count <= _issues_info.limit)
                    {
                        // if the limit is less than the total_count, it means finished getting issues.
                        // (総チケット数がチケット上限/回より少なければ、初回取得ですべてのチケットを取得できたということなので、
                        //  取得したチケットを返却)
                        return _issues_info.issues;
                    }
                    else
                    {
                        // if the total_count is more than the limit, it means you don't finished getting issue.
                        // so continues to get issues.
                        // (総チケット数がチケット上限/回より多ければ、初回取得ですべてのチケットを取得できなかったので、
                        // 取得できるまでリクエストを投げて取得する。)

                        // By the information of total_count of issues, calculate next trial counts.
                        // (total_count(総チケット数)の情報を元に、
                        //  全てのチケットを取得するには何回GET要求を投げれば良いか算出)
                        int trial_max_counts = (int)Math.Ceiling(
                                                                ((decimal)_issues_info.total_count / (decimal)IssuesInfo.C_MAX_LIMIT)
                                                                );

                        // save the issues you got before.(先ほど取得した初回100枚のチケットを退避)
                        List<issue> _got_issues = _issues_info.issues;

                        // get rest of the issues.
                        // (チケットをすべて取得できるまでオフセット値を移動しつつ、チケットを取得する(初回取得分のGET要求を除く))
                        int offset = 0; //オフセット値
                        for (int getCount = 0;
                                getCount < (trial_max_counts - 1);
                                getCount++)
                        {

                            if (getCount == 0)
                            {
                                // at first, move to the last place.
                                // (まず最初に取得するときは、先ほど取得した初回リクエスト分を除くため、
                                //  オフセットを先ほど取得した取得上限数まで移動する)
                                offset = IssuesInfo.C_MAX_LIMIT;
                            }
                            else
                            {
                                // plus the offset.
                                // (二回目以降は、オフセット値を取得上限数ずつずらしていく)
                                offset += IssuesInfo.C_MAX_LIMIT;
                            }

                            // Get issues(チケット情報を取得)
                            _issues_info = GetIssuesInfo(true, offset.ToString(),
                                                         true, IssuesInfo.C_MAX_LIMIT.ToString(),
                                                         false, "0",
                                                         false, "0",
                                                         false, "0",
                                                         false, "*",
                                                         false, "0",
                                                         false,null);

                            // save the issues.(取得したチケットを退避)
                            _got_issues.AddRange(_issues_info.issues);
                        }

                        // finished getting issues(全てのチケットを取得したら、それらを返却)
                        return _got_issues;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
                    
        #endregion

        #region POST

            /// <summary>
            /// Create issue(チケット発行)
            /// </summary>
            /// <param name="_issue">issue information(発行するチケットの情報)</param>
            /// <returns>Success or fail(成功可否)</returns>
            public bool CreateIssue(RedminePOST.issue _issue)
            {
                try
                {
                    var _ret = false;

                    // Using site URL, make base URL for updating issue's information with json format.(RedmineのサイトURLをベースに、チケット情報の更新に使用するissues.jsonを構成)
                     string _request_Uri = "";
                    _request_Uri = _Redmine_Access_URL + "issues.json";

                    WebRequest _req = WebRequest.Create(_request_Uri);

                    _req.Method = "POST";

                    // Set API Access Key to HTTP header. (ヘッダーにAPIアクセスキーをセット)
                    _req.Headers.Add("X-Redmine-API-Key", Uri.EscapeUriString(_Redmine_API_Key));
                    _req.ContentType = "application/json";

                    // set the issue's contents(チケットの内容を構成)
                    var _issueInfo = new RedminePOST.IssueInfo();
                    _issueInfo.issue = _issue;

                    // set Initializer(json更新用のシリアライザを準備)
                    var _serializer = new DataContractJsonSerializer(typeof(RedminePOST.IssueInfo));

                    MemoryStream _memoryStream = new MemoryStream();
                    _serializer.WriteObject(_memoryStream, _issueInfo);

                    var _string = Encoding.UTF8.GetString(_memoryStream.ToArray());
                    
                    // getRequestStream(データをPOST送信するためのStreamを取得)
                    _req.ContentLength = Encoding.UTF8.GetBytes(_string).Length;
                    using (System.IO.Stream _reqStream = _req.GetRequestStream()) { 
                        // write the data(送信するデータを書き込む)
                        _reqStream.Write(Encoding.UTF8.GetBytes(_string), 0, Encoding.UTF8.GetBytes(_string).Length);

                        _reqStream.Close();
                    };
                    
                    // send post request(postリクエストを送信してレスポンスを取得)
                    using (WebResponse _response = _req.GetResponse()) { 
                        switch (((HttpWebResponse)_response).StatusCode)
                        {
                            case HttpStatusCode.Created:
                                _ret = true;
                                break;
                        };                 
                    };

                    return _ret;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        #endregion

    }
}

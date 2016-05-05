# RedmineREST

## This is the Redmine's API Access DLL modules by using from Csharp(C#).
* このモジュールは、RedmineのAPIをC#(.net Framework)から気軽にアクセスできるように手助けするDLLです。
* Built by Visual Studio 2015, .net Framework3.5

### How to use
1. Build the project, "RedmineREST"(この名前のプロジェクトをビルドしてください。)
1. From your program, create new instance of "RedmineREST".(この名前のクラスのインスタンスを作ってください。)
1. Set your Redmine Site's Address and API key to the instance.(if you've already known your Redmine Site's Address and API Key, you can set with constructor.)
(RedmineのサイトアドレスとAPIキーをセットしてください。インスタンス生成時でも構いません。)  
    `RedmineREST.RedmineREST redmine_ = new RedmineREST.RedmineREST();`  
    OR  
    `RedmineREST.RedmineREST redmine_ = new RedmineREST.RedmineREST("http://172.17.1.30:3000", "175b7a1905e471a42d72e99cfebe1d085de60f9c");`
    
1. if you'd like to get all issues, call GetIssues().(全てのチケット情報を取得したければ、GetIssuesを呼んでください。)
1. if you'd like to create new issue, call CreateIssue().for further information, please view the source.(新しくチケットを作成したければ、CreateIssueを呼んでください。)
1. there are several different methods in this project, like get projects information,trackers,users, and so on.(他にも、プロジェクトやトラッカーの情報を得るメソッドも用意してあります。)

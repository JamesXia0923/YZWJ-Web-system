<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs"
    Inherits="YouZhiWenJiao.Web.profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>上海优智文教</title>
    <link href="css/master.css" type="text/css" rel="stylesheet" />
    <link href="css/base.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.SuperSlide.2.1.1.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <!--头部-->
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" height="405px" src="header.aspx"></iframe>
    </div>
    <!--文字列表页主体-->
    <div class="newsbox yh">
        <div class="block">
            <div class="navmenu" id= "navMenu">
                <span>您现在的位置: <a href="index.aspx">首页</a> > 公司简介</span>公司简介</div>
            <div class="newsnr">
                <div class="fleft leftmenu yh" id = "leftMenu">
                    <ul>
                        <% foreach(var CompanyProfileType in CompanyProfileTypeList) %>
                        <%{ %>
                        <li><a href="Javascript:onclick('<%=CompanyProfileType.id %>');" id="a<%=CompanyProfileType.id %>">
                            <%=CompanyProfileType.description%></a></li>
                        <%} %>
                    </ul>
                </div>
                <% foreach(var CompanyProfile in CompanyProfileList) %>
                <%{ %>
                <div id="<%=CompanyProfile.typeid %>" class="content yh fright" style="width: 850px;">
                    <h2 style="text-align:center;">
                        <%=CompanyProfile.title%></h2>
                    <p>
                        <%=CompanyProfile.content%></p>
                </div>
                <%} %>

                <script type="text/javascript" id="bdshare_js" data="type=tools&amp;uid=375347"></script>

                <script type="text/javascript" id="bdshell_js"></script>

                <script type="text/javascript">
                    document.getElementById("bdshell_js").src = "http://bdimg.share.baidu.com/static/js/shell_v2.js?cdnversion=" + Math.ceil(new Date() / 3600000)
                    $(function() {
                        $(".content").hide();
                        $("#<%=CompanyProfileList[0].typeid %>").show();
                        $(".leftmenu>ul>li>:first").addClass("select");

                        var h3_height = 405;
                        $(window).scroll(function() {
                            var this_scrollTop = $(this).scrollTop();
                            if (this_scrollTop > h3_height) {
                                $("#leftMenu").attr("style", "z-index: -1; transform: translateZ(0px); position: fixed; transition: margin-top 0.3s ease; will-change: margin-top, top; top: 46px;");
                                $("#navMenu").attr("style", "background-color:#fff;z-index: 10;position: fixed; top: 0px;width:1135px;");
                            }
                            else {
                                $("#leftMenu").attr("style", "");
                                $("#navMenu").attr("style", "");
                            }
                        });
                    });
                    function onclick(obj) {
                        $(".content").hide();
                        $("#" + obj).show();
                        $(".leftmenu>ul>li>a").removeClass();
                        $("#a" + obj).addClass("select");
                    }
                </script>

                <!-- Baidu Button END -->
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
    <div>
        <iframe frameborder="0" scrolling="no" width="100%" class="h390" src="footer.aspx"></iframe>
    </div>

    <script src="js/all.js" type="text/javascript"></script>
</form>
</body>
</html>

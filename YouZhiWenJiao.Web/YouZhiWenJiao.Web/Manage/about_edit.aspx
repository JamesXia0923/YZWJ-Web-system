﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about_edit.aspx.cs" Inherits="YouZhiWenJiao.Web.Manage.about_edit" ValidateRequest="false"%>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<link href="css/admin.css" type="text/css" rel="stylesheet" />
		<%--<script type="text/javascript">
			function ddlList_change() {
				if (document.getElementById("ddlList").value == "公司概述") {
					videoTr.style.display = "block";
				}
				else {
					videoTr.style.display = "none";
				}
			}
		</script>--%>
	</head>
	<body  style=" background-color:#fff">
		<form id="form1" runat="server">
			<table cellspacing=0 cellpadding=0 width="100%" align=center border=0>
				<tr height=28>
					<td align="left" background="images/title_bg1.jpg">&nbsp;</td>
				</tr>
				<tr>
					<td bgcolor=#b1ceef height=1></td>
				</tr>
				<tr height=20>
					<td background="images/shadow_bg.jpg"></td>
				</tr>
			</table>

			<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="tab3">
				<tr>
					<td align="center" colspan="2" style="font-size:15px;font-weight: bold;height:35px;width:100%; background:#edf4fc; color:black; border-right:1px solid #edf4fc; border-bottom:1px solid #edf4fc;" >
					公&nbsp;&nbsp;司&nbsp;&nbsp;简&nbsp;&nbsp;介</td>
				</tr>
				<tr>
					<td width="80" align="center" >标题：</td>
					<td height="45" style=" padding:10px;" align="left"><asp:TextBox id="txtTitle" runat="server" Width="332px"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center">日期：</td>
					<td style=" padding:10px;">
					<asp:Calendar id="datetime" runat="server" Width="100px"></asp:Calendar></td>
				</tr>
				
				<tr>
					<td  width="80" align="center"  height="45">类型：</td>
					<td width='45' style=" padding:10px;" align="left">
					<asp:DropDownList Width="124px" ID="ddlListType" runat="server" ></asp:DropDownList></td>
				</tr>
				
				<%--<tr>
					<td height="45" align="center">上传图片</td>
					<td height="45" style=" padding:10px;" align="left">
						<input id="InputFile" style="width: 399px" type="file" runat="server" />
						<asp:Label ID="Lb_Info" runat="server" ForeColor="Red"></asp:Label>
						<asp:Image ID="image" width="130" height="90" runat="server" AlternateText="Image text" ImageAlign="left" />
					</td>
				</tr>--%>
				
				<tr>
					<td align="center">内容</td><td valign="top" style=" padding:10px;">
						<FTB:FreeTextBox ID="ftbContent" HelperFilesPath="CQEdit"  BackColor="224,224,224" ToolbarType="office2003" GutterBackColor="224,224,224" ImageGalleryPath="/CQEdit/privateimage" HelperFilesParameters='PublicImageGalleryPath=/CQEdit/publicImage'  runat="server" width="650" height="400" ToolbarLayout="FontFacesMenu,save,FontSizesMenu, FontForeColorsMenu, FontBackColorsMenu,justifyleft,JustifyCenter,justifyfull,justifyright,InsertImageFromGallery,inserttable,Bold, Italic, Underline, Strikethrough, Center,Superscript, Subscript, CreateLink, Unlink, Remove" ></FTB:FreeTextBox>
					</td>
				</tr>
				
				<tr>
					<td height="60" colspan="2" align="left" valign="middle" style="border-bottom:none; padding-left:80px;">
						<asp:Button id="btnOK" OnClick="btnOK_Click" runat="server" text="确 定" class="coolbg"></asp:Button>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="btnBack" OnClick="btnBack_Click" runat="server" text="返回列表" class="coolbg"></asp:Button>
					</td>
				</tr>

			</table>

			<input id="txtcontent" type="hidden" name="txtcontent" runat="server">
		</form>
	</body>
</html>

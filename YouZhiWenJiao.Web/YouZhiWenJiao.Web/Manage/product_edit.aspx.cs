﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace YouZhiWenJiao.Web.Manage
{
	public partial class product_edit : CommonPage
	{
		protected string productId = "";

		string user = @"";
		string imgUrl1 = @"";
		string imgUrl2 = @"";
		string imgUrl3 = @"";
		string href_string = @"../product.aspx?";
		protected string href_value = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			#region Session User
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
			user = Session["user"].ToString();
			#endregion

			productId = Request["id"] != null ? Request["id"].ToString() : "";
			href_value = href_string + "id=" + productId;

			#region Page refresh
			if (!IsPostBack)
			{
				sqlCmd.CommandText = @"
select type.id, type.description 
from type 
inner join category on category.id = type.categoryid
where categoryid = @categotyid";

                sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categotyid", "'" + ((int)category.学前装备).ToString() + "'");
				var rd = sqlCmd.ExecuteReader();
				while (rd.Read())
				{
					ddlListType.Items.Add(new ListItem(rd[1].ToString(), rd[0].ToString()));
				}
				rd.Close();

				if (productId != "")
				{
					sqlCmd.CommandText = "select title,content,datetime,contentpicture1,contentpicture2,contentpicture3,typeid from product where id='" + productId + "'";
					var dr = sqlCmd.ExecuteReader();
					if (dr.Read())
					{
						txtTitle.Text = dr[0].ToString();
						ftbContent.Text = dr[1].ToString();
						datetime.SelectedDate = DateTime.Parse(dr[2].ToString());

						ViewState["imgPath1"] = dr[3].ToString();
						//ViewState["imgPath2"] = dr[4].ToString();
						//ViewState["imgPath3"] = dr[5].ToString();

						image1.ImageUrl = ViewState["imgPath1"].ToString();
						//image2.ImageUrl = ViewState["imgPath2"].ToString();
						//image3.ImageUrl = ViewState["imgPath3"].ToString();

						ddlListType.SelectedValue = dr[6].ToString();
					}
					dr.Close();
				}
				else
				{
					datetime.SelectedDate = DateTime.Now;
				}
			}
			#endregion
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			string uploadName = InputFile1.Value;//获取待上传图片的完整路径，包括文件名  
			string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
			imgUrl1 = "";
			if (InputFile1.Value != "")
			{
				int idx = uploadName.LastIndexOf(".");
				string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名         

				pictureName = DateTime.Now.Ticks.ToString() + suffix;
				try
				{
					if (uploadName != "")
					{
						string AppUrl = "";
						if (Request.ApplicationPath == "/")
							AppUrl = Request.ApplicationPath;
						else
							AppUrl = Request.ApplicationPath + "/";
						string path = Server.MapPath(AppUrl + "img/" + pictureName);
						InputFile1.PostedFile.SaveAs(path);
						imgUrl1 = AppUrl + "img/" + pictureName;
					}
				}
				catch (Exception ex)
				{
					Response.Write(ex);
				}
			}
			else
			{
				imgUrl1 = ViewState["imgPath1"] == null ? "" : ViewState["imgPath1"].ToString();
			}

			//uploadName = InputFile2.Value;//获取待上传图片的完整路径，包括文件名  
			//pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
			//imgUrl2 = "";
			//if (InputFile2.Value != "")
			//{
			//    int idx = uploadName.LastIndexOf(".");
			//    string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名         

			//    pictureName = DateTime.Now.Ticks.ToString() + suffix;
			//    try
			//    {
			//        if (uploadName != "")
			//        {
			//            string AppUrl = "";
			//            if (Request.ApplicationPath == "/")
			//                AppUrl = Request.ApplicationPath;
			//            else
			//                AppUrl = Request.ApplicationPath + "/";
			//            string path = Server.MapPath(AppUrl + "img/" + pictureName);
			//            InputFile2.PostedFile.SaveAs(path);
			//            imgUrl2 = AppUrl + "img/" + pictureName;
			//        }
			//    }
			//    catch (Exception ex)
			//    {
			//        Response.Write(ex);
			//    }
			//}
			//else
			//{
			//    imgUrl2 = ViewState["imgPath2"] == null ? "" : ViewState["imgPath2"].ToString();
			//}

			//uploadName = InputFile3.Value;//获取待上传图片的完整路径，包括文件名  
			//pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复 
			//imgUrl3 = "";
			//if (InputFile3.Value != "")
			//{
			//    int idx = uploadName.LastIndexOf(".");
			//    string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名         

			//    pictureName = DateTime.Now.Ticks.ToString() + suffix;
			//    try
			//    {
			//        if (uploadName != "")
			//        {
			//            string AppUrl = "";
			//            if (Request.ApplicationPath == "/")
			//                AppUrl = Request.ApplicationPath;
			//            else
			//                AppUrl = Request.ApplicationPath + "/";
			//            string path = Server.MapPath(AppUrl + "img/" + pictureName);
			//            InputFile3.PostedFile.SaveAs(path);
			//            imgUrl3 = AppUrl + "img/" + pictureName;
			//        }
			//    }
			//    catch (Exception ex)
			//    {
			//        Response.Write(ex);
			//    }
			//}
			//else
			//{
			//    imgUrl3 = ViewState["imgPath3"] == null ? "" : ViewState["imgPath3"].ToString();
			//}
			if (productId != "")
			{
				sqlCmd.CommandText = @"
update product 
set 
typeid=@typeid,
title=@title,
content=@content,
datetime=@datetime,
picture=@picture,
contentpicture1=@contentpicture1,
contentpicture2=@contentpicture2,
contentpicture3=@contentpicture3,
updatedatetime=@updatedatetime,
updateuser=@updateuser
where id=@id;";
			}
			else
			{
				sqlCmd.CommandText = @"
insert into product (
id,
typeid,
categoryid,
title,
datetime,
content,
picture,
contentpicture1,
contentpicture2,
contentpicture3,
createdatetime,
createuser,
updatedatetime,
updateuser,
showinhomepage
)
values(
@id,
@typeid,
@categoryid,
@title,
@datetime,
@content,
@picture,
@contentpicture1,
@contentpicture2,
@contentpicture3,
@createdatetime,
@createuser,
@updatedatetime,
@updateuser,
1);";
			}
			productId = productId == "" ? Guid.NewGuid().ToString() : productId;
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@id", "'" + productId + "'");

			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@typeid", "'" + ddlListType.SelectedValue.ToString() + "'");
            sqlCmd.CommandText = sqlCmd.CommandText.Replace("@categoryid", "'" + ((int)category.学前装备).ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@title", "'" + txtTitle.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@datetime", "'" + datetime.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@contentpicture1", "'" + imgUrl1.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@contentpicture2", "'" + imgUrl2.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@contentpicture3", "'" + imgUrl3.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@picture", "'" + imgUrl1.ToString() + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@content", "'" + ftbContent.Text + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createdatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@createuser", "'" + user + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updatedatetime", "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "'");
			sqlCmd.CommandText = sqlCmd.CommandText.Replace("@updateuser", "'" + user + "'");
			sqlCmd.ExecuteNonQuery();

			Alert("保存成功!");
			Response.Redirect("product.aspx", false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("product.aspx", false);
		}
	}
}

﻿using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using YouZhiWenJiao.Web.Manage.Entity;


namespace YouZhiWenJiao.Web.Manage
{
	public partial class principalBS : CommonPage
	{
		public int UniqueId = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("login.aspx");
			}
		}

		protected void PageChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			rptDate.DataSource = GetNewList();
			rptDate.DataBind();
		}

		protected void DataBindings(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			UniqueId++;
		}
		public IList GetNewList()
		{
			IList li = new ArrayList();

			var sql = @"select id,title,datetime from product where title like '@search' and categoryid = " + ((int)category.园长书库).ToString() + " and (deleted <> 1 or deleted is null) order by updatedatetime desc";

			sqlCmd.CommandText = sql.Replace("@search", "%" + txtserarch.Value + "%");

			DataTable dt = new DataTable();
			SQLiteDataAdapter da = new SQLiteDataAdapter(sqlCmd);
			da.Fill(dt);
			Information info = null;

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				info = new Information();
				info.Number = (i + 1).ToString();
				info.ID = dt.Rows[i]["id"].ToString();
				info.Title = dt.Rows[i]["title"].ToString();
				info.DateTime = DateTime.Parse(dt.Rows[i]["datetime"].ToString()).ToShortDateString();

				li.Add(info);
			}

			return li;
		}

		protected void SubDelClick(object sender, System.EventArgs e)
		{
			string strDocumentSortIds = null;
			strDocumentSortIds = Request.Form["chkEleId"];
			strDocumentSortIds = strDocumentSortIds.Replace(",", "','");
			if (strDocumentSortIds != "" && strDocumentSortIds != null)
			{
				sqlCmd.CommandText = "update product set delect = 1 where id in(" + strDocumentSortIds + ")";
				sqlCmd.ExecuteNonQuery();
				Alert("删除成功!");
				PageChanged(null, null);
			}
		}

		protected void SubCreClick(object sender, System.EventArgs e)
		{
			Response.Redirect("principalBS_edit.aspx", false);
		}
	}
}
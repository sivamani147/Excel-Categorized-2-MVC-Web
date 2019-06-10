using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_EXCEL.DataAccess
{
    public static class ExcelDataAccess
    {
        public static DataTable GetAllRecords()
        {
            DataTable dt = new DataTable();
            string strConString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Pagedata", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable GetPageRecord(int PageId)
        {
            DataTable dt = new DataTable();
            string strConString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Pagedata where PageID= '" + PageId + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static string GetNewPageData(string PageName)
        {
            if (PageName == "NotFound" || PageName == "" || PageName == null)
                PageName = "NoPageFound";
            DataTable dt = new DataTable();
            string strConString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select PageContent from Pagedata where PageName= '" + PageName + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            var something = (dt.Rows[0]["PageContent"]).ToString();
            return something;
        }


        public static DataTable GetSearchContent(string searchname)
        {
            DataTable dt = new DataTable();
            string strConString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Pagedata where PageContent like '%"+ searchname +"%' and pageid = 5", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}



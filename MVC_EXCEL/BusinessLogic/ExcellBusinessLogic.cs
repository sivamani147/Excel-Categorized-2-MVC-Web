using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Model = MVC_EXCEL.Models;

namespace MVC_EXCEL.BusinessLogic
{
    public class ExcellBusinessLogic
    {
        public static List<Model.TableModel> GetAllRecords()
        {

            List<Model.TableModel> lstmodel = new List<Models.TableModel>();
            try
            {
                DataTable dt = DataAccess.ExcelDataAccess.GetPageRecord(1);

                foreach (DataRow item in dt.Rows)
                {
                    lstmodel.Add(
                        new Model.TableModel()
                        {
                            PageContent = Convert.ToString(item["PageContent"]),
                            PageId = Convert.ToInt32(item["PageID"]),
                            PageName = Convert.ToString(item["PageName"])
                        });
                }
            }
            catch (Exception ex)
            {
                //TODO: Logging
            }
            return lstmodel;
        }

        public static Model.TableModel GatPageContent(int PageID)
        {
            Model.TableModel model = new Model.TableModel();

            DataTable dt = DataAccess.ExcelDataAccess.GetPageRecord(PageID);
            if (dt.Rows.Count > 0)
            {
                model.PageId = Convert.ToInt32(dt.Rows[0]["PageID"]);
                model.PageName = Convert.ToString(dt.Rows[0]["PageName"]);
                model.PageContent = Convert.ToString(dt.Rows[0]["PageContent"]);
            }
            return model;

        }
        
        public static string GetNewPage(string PageName)
        {
            return DataAccess.ExcelDataAccess.GetNewPageData(PageName);

        }

        public static List<Model.TableModel> GetSearched(string searchname)
        {
            List<Model.TableModel> lstmodel = new List<Models.TableModel>();
            try
            {
                DataTable dt = DataAccess.ExcelDataAccess.GetSearchContent(searchname);

                foreach (DataRow item in dt.Rows)
                {
                    lstmodel.Add(
                        new Model.TableModel()
                        {
                            PageContent = Convert.ToString(item["PageContent"]),
                            PageId = Convert.ToInt32(item["PageID"]),
                            PageName = Convert.ToString(item["PageName"])
                        });
                }
            }
            catch (Exception ex)
            {
                //TODO: Logging
            }
            return lstmodel;

        }

    }
}
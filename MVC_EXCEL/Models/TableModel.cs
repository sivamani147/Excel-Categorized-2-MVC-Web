using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_EXCEL.Models
{
    public class TableModel
    {
        public int PageId { get; set; }
        public string PageName{ get; set; }
        public string PageContent { get; set; }
    }
}
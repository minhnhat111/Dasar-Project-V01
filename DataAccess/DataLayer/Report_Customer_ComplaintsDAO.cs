using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Report_Customer_ComplaintsDAO
    {
        #region Fields
        public static readonly string Key = "__Report_Customer_ComplaintsData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Report_Customer_ComplaintsDAO()
        {
            try
            {
                //<add key="Cache_Report_Customer_Complaints" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Report_Customer_Complaints"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Report_Customer_ComplaintInfo> GetAll()
        {
            if (Cache)
            {
                List<Report_Customer_ComplaintInfo> list = DataCache.GetCache(Key) as List<Report_Customer_ComplaintInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Report_Customer_ComplaintInfo>(DataProvider.Instance().GetAll(
                    	Table.Report_Customer_Complaints,
                    	PagingHelper.CreateOrder(new OrderObject(TableReport_Customer_Complaints.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Report_Customer_ComplaintInfo>(DataProvider.Instance().GetAll(
            	Table.Report_Customer_Complaints,
            	PagingHelper.CreateOrder(new OrderObject(TableReport_Customer_Complaints.ID, SortOrder.Desc))));
        }
        public static List<Report_Customer_ComplaintInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Report_Customer_ComplaintInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Report_Customer_ComplaintInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Report_Customer_ComplaintInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Report_Customer_ComplaintInfo>(DataProvider.Instance().Find(Table.Report_Customer_Complaints, columnName, value));
        }
        public static Report_Customer_ComplaintInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Report_Customer_ComplaintInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableReport_Customer_Complaints.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Report_Customer_ComplaintInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Report_Customer_ComplaintInfo x, Report_Customer_ComplaintInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "id":
                        	rs = PagingHelper.Compare<int>(x.ID, y.ID, obj.Order);
                        	break;
                        case "technical_staff":
                        	rs = PagingHelper.Compare<string>(x.Technical_staff, y.Technical_staff, obj.Order);
                        	break;
                        case "customer_a_quantity":
                        	rs = PagingHelper.Compare<string>(x.Customer_A_Quantity, y.Customer_A_Quantity, obj.Order);
                        	break;
                        case "customer_a_times":
                        	rs = PagingHelper.Compare<string>(x.Customer_A_Times, y.Customer_A_Times, obj.Order);
                        	break;
                        case "customer_b_quantity":
                        	rs = PagingHelper.Compare<string>(x.Customer_B_Quantity, y.Customer_B_Quantity, obj.Order);
                        	break;
                        case "customer_b_times":
                        	rs = PagingHelper.Compare<string>(x.Customer_B_Times, y.Customer_B_Times, obj.Order);
                        	break;
                        case "customer_c_quantity":
                        	rs = PagingHelper.Compare<string>(x.Customer_C_Quantity, y.Customer_C_Quantity, obj.Order);
                        	break;
                        case "customer_c_times":
                        	rs = PagingHelper.Compare<string>(x.Customer_C_Times, y.Customer_C_Times, obj.Order);
                        	break;
                        case "customer_d_quantity":
                        	rs = PagingHelper.Compare<string>(x.Customer_D_Quantity, y.Customer_D_Quantity, obj.Order);
                        	break;
                        case "customer_d_times":
                        	rs = PagingHelper.Compare<string>(x.Customer_D_Times, y.Customer_D_Times, obj.Order);
                        	break;
                        case "result":
                        	rs = PagingHelper.Compare<string>(x.Result, y.Result, obj.Order);
                        	break;
                        case "informationid":
                        	rs = PagingHelper.Compare<int>(x.InformationID, y.InformationID, obj.Order);
                        	break;
                        case "orderid":
                        	rs = PagingHelper.Compare<int>(x.OrderID, y.OrderID, obj.Order);
                        	break;
                    }
                    if (rs != 0) return rs;
                }
                return 0;
            };
        }
        public static OrderObject[] DefaultOrder()
        {
            if (orderObjects == null)
            	orderObjects = new OrderObject[] { new OrderObject(TableReport_Customer_Complaints.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Report_Customer_ComplaintInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Report_Customer_ComplaintInfo>(DataProvider.Instance().GetByPage(
            	Table.Report_Customer_Complaints, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Report_Customer_ComplaintInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Report_Customer_ComplaintInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Report_Customer_ComplaintInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_Customer_ComplaintInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_Customer_ComplaintInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_Customer_ComplaintInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Report_Customer_ComplaintInfo report_Customer_ComplaintInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Report_Customer_Complaints,
            	"@" + TableReport_Customer_Complaints.ID,
            	report_Customer_ComplaintInfo.ID, report_Customer_ComplaintInfo.Technical_staff, report_Customer_ComplaintInfo.Customer_A_Quantity, report_Customer_ComplaintInfo.Customer_A_Times, report_Customer_ComplaintInfo.Customer_B_Quantity, report_Customer_ComplaintInfo.Customer_B_Times, report_Customer_ComplaintInfo.Customer_C_Quantity, report_Customer_ComplaintInfo.Customer_C_Times, report_Customer_ComplaintInfo.Customer_D_Quantity, report_Customer_ComplaintInfo.Customer_D_Times, report_Customer_ComplaintInfo.Result, report_Customer_ComplaintInfo.InformationID, report_Customer_ComplaintInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Report_Customer_ComplaintInfo report_Customer_ComplaintInfo)
        {
            return InsertUpdateDelete(report_Customer_ComplaintInfo, DataProviderAction.Insert);
        }
        public static int Update(Report_Customer_ComplaintInfo report_Customer_ComplaintInfo)
        {
            return InsertUpdateDelete(report_Customer_ComplaintInfo, DataProviderAction.Update);
        }
        public static int Delete(Report_Customer_ComplaintInfo report_Customer_ComplaintInfo)
        {
            return InsertUpdateDelete(report_Customer_ComplaintInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

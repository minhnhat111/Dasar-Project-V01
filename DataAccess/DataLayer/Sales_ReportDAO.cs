using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Sales_ReportDAO
    {
        #region Fields
        public static readonly string Key = "__Sales_ReportData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Sales_ReportDAO()
        {
            try
            {
                //<add key="Cache_Sales_Report" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Sales_Report"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Sales_ReportInfo> GetAll()
        {
            if (Cache)
            {
                List<Sales_ReportInfo> list = DataCache.GetCache(Key) as List<Sales_ReportInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Sales_ReportInfo>(DataProvider.Instance().GetAll(
                    	Table.Sales_Report,
                    	PagingHelper.CreateOrder(new OrderObject(TableSales_Report.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Sales_ReportInfo>(DataProvider.Instance().GetAll(
            	Table.Sales_Report,
            	PagingHelper.CreateOrder(new OrderObject(TableSales_Report.ID, SortOrder.Desc))));
        }
        public static List<Sales_ReportInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Sales_ReportInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Sales_ReportInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Sales_ReportInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Sales_ReportInfo>(DataProvider.Instance().Find(Table.Sales_Report, columnName, value));
        }
        public static Sales_ReportInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Sales_ReportInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableSales_Report.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Sales_ReportInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Sales_ReportInfo x, Sales_ReportInfo y)
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
                        case "year":
                        	rs = PagingHelper.Compare<int>(x.Year, y.Year, obj.Order);
                        	break;
                        case "month":
                        	rs = PagingHelper.Compare<DateTime>(x.Month, y.Month, obj.Order);
                        	break;
                        case "export_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Export_Date, y.Export_Date, obj.Order);
                        	break;
                        case "date_arrived":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_Arrived, y.Date_Arrived, obj.Order);
                        	break;
                        case "check_date":
                        	rs = PagingHelper.Compare<string>(x.Check_Date, y.Check_Date, obj.Order);
                        	break;
                        case "export_number":
                        	rs = PagingHelper.Compare<string>(x.Export_Number, y.Export_Number, obj.Order);
                        	break;
                        case "bill_number":
                        	rs = PagingHelper.Compare<string>(x.Bill_Number, y.Bill_Number, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "supplierid":
                        	rs = PagingHelper.Compare<int>(x.SupplierID, y.SupplierID, obj.Order);
                        	break;
                        case "certificate":
                        	rs = PagingHelper.Compare<string>(x.Certificate, y.Certificate, obj.Order);
                        	break;
                        case "tuber_number":
                        	rs = PagingHelper.Compare<int>(x.Tuber_Number, y.Tuber_Number, obj.Order);
                        	break;
                        case "tray_number":
                        	rs = PagingHelper.Compare<int>(x.Tray_Number, y.Tray_Number, obj.Order);
                        	break;
                        case "price_vnd":
                        	rs = PagingHelper.Compare<double>(x.Price_VND, y.Price_VND, obj.Order);
                        	break;
                        case "status":
                        	rs = PagingHelper.Compare<string>(x.Status, y.Status, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableSales_Report.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Sales_ReportInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Sales_ReportInfo>(DataProvider.Instance().GetByPage(
            	Table.Sales_Report, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Sales_ReportInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Sales_ReportInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Sales_ReportInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Sales_ReportInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Sales_ReportInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Sales_ReportInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Sales_ReportInfo sales_ReportInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Sales_Report,
            	"@" + TableSales_Report.ID,
            	sales_ReportInfo.ID, sales_ReportInfo.Year, sales_ReportInfo.Month, sales_ReportInfo.Export_Date, sales_ReportInfo.Date_Arrived, sales_ReportInfo.Check_Date, sales_ReportInfo.Export_Number, sales_ReportInfo.Bill_Number, sales_ReportInfo.CustomerID, sales_ReportInfo.ItemID, sales_ReportInfo.SupplierID, sales_ReportInfo.Certificate, sales_ReportInfo.Tuber_Number, sales_ReportInfo.Tray_Number, sales_ReportInfo.Price_VND, sales_ReportInfo.Status, sales_ReportInfo.Note, sales_ReportInfo.InformationID, sales_ReportInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Sales_ReportInfo sales_ReportInfo)
        {
            return InsertUpdateDelete(sales_ReportInfo, DataProviderAction.Insert);
        }
        public static int Update(Sales_ReportInfo sales_ReportInfo)
        {
            return InsertUpdateDelete(sales_ReportInfo, DataProviderAction.Update);
        }
        public static int Delete(Sales_ReportInfo sales_ReportInfo)
        {
            return InsertUpdateDelete(sales_ReportInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

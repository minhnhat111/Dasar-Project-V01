using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Report_On_BoardDAO
    {
        #region Fields
        public static readonly string Key = "__Report_On_BoardData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Report_On_BoardDAO()
        {
            try
            {
                //<add key="Cache_Report_On_Board" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Report_On_Board"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Report_On_BoardInfo> GetAll()
        {
            if (Cache)
            {
                List<Report_On_BoardInfo> list = DataCache.GetCache(Key) as List<Report_On_BoardInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Report_On_BoardInfo>(DataProvider.Instance().GetAll(
                    	Table.Report_On_Board,
                    	PagingHelper.CreateOrder(new OrderObject(TableReport_On_Board.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Report_On_BoardInfo>(DataProvider.Instance().GetAll(
            	Table.Report_On_Board,
            	PagingHelper.CreateOrder(new OrderObject(TableReport_On_Board.ID, SortOrder.Desc))));
        }
        public static List<Report_On_BoardInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Report_On_BoardInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Report_On_BoardInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Report_On_BoardInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Report_On_BoardInfo>(DataProvider.Instance().Find(Table.Report_On_Board, columnName, value));
        }
        public static Report_On_BoardInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Report_On_BoardInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableReport_On_Board.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Report_On_BoardInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Report_On_BoardInfo x, Report_On_BoardInfo y)
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
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "supplierid":
                        	rs = PagingHelper.Compare<int>(x.SupplierID, y.SupplierID, obj.Order);
                        	break;
                        case "price_eur":
                        	rs = PagingHelper.Compare<double>(x.Price_EUR, y.Price_EUR, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "order_quantity":
                        	rs = PagingHelper.Compare<int>(x.Order_Quantity, y.Order_Quantity, obj.Order);
                        	break;
                        case "unit_price":
                        	rs = PagingHelper.Compare<double>(x.Unit_Price, y.Unit_Price, obj.Order);
                        	break;
                        case "delivery_time":
                        	rs = PagingHelper.Compare<string>(x.Delivery_Time, y.Delivery_Time, obj.Order);
                        	break;
                        case "pay":
                        	rs = PagingHelper.Compare<string>(x.Pay, y.Pay, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableReport_On_Board.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Report_On_BoardInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Report_On_BoardInfo>(DataProvider.Instance().GetByPage(
            	Table.Report_On_Board, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Report_On_BoardInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Report_On_BoardInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Report_On_BoardInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_On_BoardInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_On_BoardInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Report_On_BoardInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Report_On_BoardInfo report_On_BoardInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Report_On_Board,
            	"@" + TableReport_On_Board.ID,
            	report_On_BoardInfo.ID, report_On_BoardInfo.ItemID, report_On_BoardInfo.SupplierID, report_On_BoardInfo.Price_EUR, report_On_BoardInfo.CustomerID, report_On_BoardInfo.Order_Quantity, report_On_BoardInfo.Unit_Price, report_On_BoardInfo.Delivery_Time, report_On_BoardInfo.Pay, report_On_BoardInfo.InformationID, report_On_BoardInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Report_On_BoardInfo report_On_BoardInfo)
        {
            return InsertUpdateDelete(report_On_BoardInfo, DataProviderAction.Insert);
        }
        public static int Update(Report_On_BoardInfo report_On_BoardInfo)
        {
            return InsertUpdateDelete(report_On_BoardInfo, DataProviderAction.Update);
        }
        public static int Delete(Report_On_BoardInfo report_On_BoardInfo)
        {
            return InsertUpdateDelete(report_On_BoardInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

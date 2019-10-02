using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Cooling_RequestDAO
    {
        #region Fields
        public static readonly string Key = "__Cooling_RequestData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Cooling_RequestDAO()
        {
            try
            {
                //<add key="Cache_Cooling_Request" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Cooling_Request"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Cooling_RequestInfo> GetAll()
        {
            if (Cache)
            {
                List<Cooling_RequestInfo> list = DataCache.GetCache(Key) as List<Cooling_RequestInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Cooling_RequestInfo>(DataProvider.Instance().GetAll(
                    	Table.Cooling_Request,
                    	PagingHelper.CreateOrder(new OrderObject(TableCooling_Request.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Cooling_RequestInfo>(DataProvider.Instance().GetAll(
            	Table.Cooling_Request,
            	PagingHelper.CreateOrder(new OrderObject(TableCooling_Request.ID, SortOrder.Desc))));
        }
        public static List<Cooling_RequestInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Cooling_RequestInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Cooling_RequestInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Cooling_RequestInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Cooling_RequestInfo>(DataProvider.Instance().Find(Table.Cooling_Request, columnName, value));
        }
        public static Cooling_RequestInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Cooling_RequestInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableCooling_Request.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Cooling_RequestInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Cooling_RequestInfo x, Cooling_RequestInfo y)
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
                        case "request_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Request_Date, y.Request_Date, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "requester":
                        	rs = PagingHelper.Compare<string>(x.Requester, y.Requester, obj.Order);
                        	break;
                        case "delivery_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Delivery_Date, y.Delivery_Date, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableCooling_Request.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Cooling_RequestInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Cooling_RequestInfo>(DataProvider.Instance().GetByPage(
            	Table.Cooling_Request, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Cooling_RequestInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Cooling_RequestInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Cooling_RequestInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Cooling_RequestInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Cooling_RequestInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Cooling_RequestInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Cooling_RequestInfo cooling_RequestInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Cooling_Request,
            	"@" + TableCooling_Request.ID,
            	cooling_RequestInfo.ID, cooling_RequestInfo.Request_Date, cooling_RequestInfo.ItemID, cooling_RequestInfo.CustomerID, cooling_RequestInfo.Requester, cooling_RequestInfo.Delivery_Date, cooling_RequestInfo.InformationID, cooling_RequestInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Cooling_RequestInfo cooling_RequestInfo)
        {
            return InsertUpdateDelete(cooling_RequestInfo, DataProviderAction.Insert);
        }
        public static int Update(Cooling_RequestInfo cooling_RequestInfo)
        {
            return InsertUpdateDelete(cooling_RequestInfo, DataProviderAction.Update);
        }
        public static int Delete(Cooling_RequestInfo cooling_RequestInfo)
        {
            return InsertUpdateDelete(cooling_RequestInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

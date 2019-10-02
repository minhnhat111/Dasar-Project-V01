using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Shipment_RequestDAO
    {
        #region Fields
        public static readonly string Key = "__Shipment_RequestData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Shipment_RequestDAO()
        {
            try
            {
                //<add key="Cache_Shipment_Request" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Shipment_Request"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Shipment_RequestInfo> GetAll()
        {
            if (Cache)
            {
                List<Shipment_RequestInfo> list = DataCache.GetCache(Key) as List<Shipment_RequestInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Shipment_RequestInfo>(DataProvider.Instance().GetAll(
                    	Table.Shipment_Request,
                    	PagingHelper.CreateOrder(new OrderObject(TableShipment_Request.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Shipment_RequestInfo>(DataProvider.Instance().GetAll(
            	Table.Shipment_Request,
            	PagingHelper.CreateOrder(new OrderObject(TableShipment_Request.ID, SortOrder.Desc))));
        }
        public static List<Shipment_RequestInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Shipment_RequestInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Shipment_RequestInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Shipment_RequestInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Shipment_RequestInfo>(DataProvider.Instance().Find(Table.Shipment_Request, columnName, value));
        }
        public static Shipment_RequestInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Shipment_RequestInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableShipment_Request.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Shipment_RequestInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Shipment_RequestInfo x, Shipment_RequestInfo y)
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
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "reason":
                        	rs = PagingHelper.Compare<string>(x.Reason, y.Reason, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableShipment_Request.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Shipment_RequestInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Shipment_RequestInfo>(DataProvider.Instance().GetByPage(
            	Table.Shipment_Request, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Shipment_RequestInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Shipment_RequestInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Shipment_RequestInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Shipment_RequestInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Shipment_RequestInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Shipment_RequestInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Shipment_RequestInfo shipment_RequestInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Shipment_Request,
            	"@" + TableShipment_Request.ID,
            	shipment_RequestInfo.ID, shipment_RequestInfo.CustomerID, shipment_RequestInfo.ItemID, shipment_RequestInfo.Reason, shipment_RequestInfo.InformationID, shipment_RequestInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Shipment_RequestInfo shipment_RequestInfo)
        {
            return InsertUpdateDelete(shipment_RequestInfo, DataProviderAction.Insert);
        }
        public static int Update(Shipment_RequestInfo shipment_RequestInfo)
        {
            return InsertUpdateDelete(shipment_RequestInfo, DataProviderAction.Update);
        }
        public static int Delete(Shipment_RequestInfo shipment_RequestInfo)
        {
            return InsertUpdateDelete(shipment_RequestInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

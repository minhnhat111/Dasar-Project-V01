using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Monitoring_Seed_QuantityDAO
    {
        #region Fields
        public static readonly string Key = "__Monitoring_Seed_QuantityData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Monitoring_Seed_QuantityDAO()
        {
            try
            {
                //<add key="Cache_Monitoring_Seed_Quantity" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Monitoring_Seed_Quantity"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Monitoring_Seed_QuantityInfo> GetAll()
        {
            if (Cache)
            {
                List<Monitoring_Seed_QuantityInfo> list = DataCache.GetCache(Key) as List<Monitoring_Seed_QuantityInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Monitoring_Seed_QuantityInfo>(DataProvider.Instance().GetAll(
                    	Table.Monitoring_Seed_Quantity,
                    	PagingHelper.CreateOrder(new OrderObject(TableMonitoring_Seed_Quantity.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Monitoring_Seed_QuantityInfo>(DataProvider.Instance().GetAll(
            	Table.Monitoring_Seed_Quantity,
            	PagingHelper.CreateOrder(new OrderObject(TableMonitoring_Seed_Quantity.ID, SortOrder.Desc))));
        }
        public static List<Monitoring_Seed_QuantityInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Monitoring_Seed_QuantityInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Monitoring_Seed_QuantityInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Monitoring_Seed_QuantityInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Monitoring_Seed_QuantityInfo>(DataProvider.Instance().Find(Table.Monitoring_Seed_Quantity, columnName, value));
        }
        public static Monitoring_Seed_QuantityInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Monitoring_Seed_QuantityInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableMonitoring_Seed_Quantity.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Monitoring_Seed_QuantityInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Monitoring_Seed_QuantityInfo x, Monitoring_Seed_QuantityInfo y)
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
                        case "date_added":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_Added, y.Date_Added, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "supplierid":
                        	rs = PagingHelper.Compare<int>(x.SupplierID, y.SupplierID, obj.Order);
                        	break;
                        case "lot":
                        	rs = PagingHelper.Compare<string>(x.Lot, y.Lot, obj.Order);
                        	break;
                        case "certificate":
                        	rs = PagingHelper.Compare<int>(x.Certificate, y.Certificate, obj.Order);
                        	break;
                        case "status":
                        	rs = PagingHelper.Compare<string>(x.Status, y.Status, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "export_quantity":
                        	rs = PagingHelper.Compare<int>(x.Export_Quantity, y.Export_Quantity, obj.Order);
                        	break;
                        case "export_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Export_Date, y.Export_Date, obj.Order);
                        	break;
                        case "damaged_quantity":
                        	rs = PagingHelper.Compare<int>(x.Damaged_Quantity, y.Damaged_Quantity, obj.Order);
                        	break;
                        case "customer_feedback":
                        	rs = PagingHelper.Compare<string>(x.Customer_Feedback, y.Customer_Feedback, obj.Order);
                        	break;
                        case "damaged_status":
                        	rs = PagingHelper.Compare<string>(x.Damaged_Status, y.Damaged_Status, obj.Order);
                        	break;
                        case "checked_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Checked_Date, y.Checked_Date, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
                        	break;
                        case "process_status_customer":
                        	rs = PagingHelper.Compare<string>(x.Process_Status_Customer, y.Process_Status_Customer, obj.Order);
                        	break;
                        case "process_status_supplier":
                        	rs = PagingHelper.Compare<string>(x.Process_Status_Supplier, y.Process_Status_Supplier, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableMonitoring_Seed_Quantity.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Monitoring_Seed_QuantityInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Monitoring_Seed_QuantityInfo>(DataProvider.Instance().GetByPage(
            	Table.Monitoring_Seed_Quantity, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Monitoring_Seed_QuantityInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Monitoring_Seed_QuantityInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Monitoring_Seed_QuantityInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Monitoring_Seed_QuantityInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Monitoring_Seed_QuantityInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Monitoring_Seed_QuantityInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Monitoring_Seed_QuantityInfo monitoring_Seed_QuantityInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Monitoring_Seed_Quantity,
            	"@" + TableMonitoring_Seed_Quantity.ID,
            	monitoring_Seed_QuantityInfo.ID, monitoring_Seed_QuantityInfo.Date_Added, monitoring_Seed_QuantityInfo.ContID, monitoring_Seed_QuantityInfo.ItemID, monitoring_Seed_QuantityInfo.SupplierID, monitoring_Seed_QuantityInfo.Lot, monitoring_Seed_QuantityInfo.Certificate, monitoring_Seed_QuantityInfo.Status, monitoring_Seed_QuantityInfo.CustomerID, monitoring_Seed_QuantityInfo.Export_Quantity, monitoring_Seed_QuantityInfo.Export_Date, monitoring_Seed_QuantityInfo.Damaged_Quantity, monitoring_Seed_QuantityInfo.Customer_Feedback, monitoring_Seed_QuantityInfo.Damaged_Status, monitoring_Seed_QuantityInfo.Checked_Date, monitoring_Seed_QuantityInfo.Note, monitoring_Seed_QuantityInfo.Process_Status_Customer, monitoring_Seed_QuantityInfo.Process_Status_Supplier, monitoring_Seed_QuantityInfo.InformationID, monitoring_Seed_QuantityInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Monitoring_Seed_QuantityInfo monitoring_Seed_QuantityInfo)
        {
            return InsertUpdateDelete(monitoring_Seed_QuantityInfo, DataProviderAction.Insert);
        }
        public static int Update(Monitoring_Seed_QuantityInfo monitoring_Seed_QuantityInfo)
        {
            return InsertUpdateDelete(monitoring_Seed_QuantityInfo, DataProviderAction.Update);
        }
        public static int Delete(Monitoring_Seed_QuantityInfo monitoring_Seed_QuantityInfo)
        {
            return InsertUpdateDelete(monitoring_Seed_QuantityInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

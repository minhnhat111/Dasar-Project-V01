using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class SupplierDAO
    {
        #region Fields
        public static readonly string Key = "__SupplierData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static SupplierDAO()
        {
            try
            {
                //<add key="Cache_Supplier" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Supplier"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<SupplierInfo> GetAll()
        {
            if (Cache)
            {
                List<SupplierInfo> list = DataCache.GetCache(Key) as List<SupplierInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<SupplierInfo>(DataProvider.Instance().GetAll(
                    	Table.Supplier,
                    	PagingHelper.CreateOrder(new OrderObject(TableSupplier.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<SupplierInfo>(DataProvider.Instance().GetAll(
            	Table.Supplier,
            	PagingHelper.CreateOrder(new OrderObject(TableSupplier.ID, SortOrder.Desc))));
        }
        public static List<SupplierInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<SupplierInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<SupplierInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static SupplierInfo Find(object columnName, object value)
        {
            return CBO.FillObject<SupplierInfo>(DataProvider.Instance().Find(Table.Supplier, columnName, value));
        }
        public static SupplierInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(SupplierInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableSupplier.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<SupplierInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(SupplierInfo x, SupplierInfo y)
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
                        case "suppliercode":
                        	rs = PagingHelper.Compare<string>(x.SupplierCode, y.SupplierCode, obj.Order);
                        	break;
                        case "suppliername":
                        	rs = PagingHelper.Compare<string>(x.SupplierName, y.SupplierName, obj.Order);
                        	break;
                        case "nation":
                        	rs = PagingHelper.Compare<string>(x.Nation, y.Nation, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableSupplier.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<SupplierInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<SupplierInfo>(DataProvider.Instance().GetByPage(
            	Table.Supplier, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<SupplierInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<SupplierInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<SupplierInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<SupplierInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<SupplierInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<SupplierInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(SupplierInfo supplierInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Supplier,
            	"@" + TableSupplier.ID,
            	supplierInfo.ID, supplierInfo.SupplierCode, supplierInfo.SupplierName, supplierInfo.Nation, supplierInfo.InformationID, supplierInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(SupplierInfo supplierInfo)
        {
            return InsertUpdateDelete(supplierInfo, DataProviderAction.Insert);
        }
        public static int Update(SupplierInfo supplierInfo)
        {
            return InsertUpdateDelete(supplierInfo, DataProviderAction.Update);
        }
        public static int Delete(SupplierInfo supplierInfo)
        {
            return InsertUpdateDelete(supplierInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

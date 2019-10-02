using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Supplier_ContractDAO
    {
        #region Fields
        public static readonly string Key = "__Supplier_ContractData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Supplier_ContractDAO()
        {
            try
            {
                //<add key="Cache_Supplier_Contract" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Supplier_Contract"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Supplier_ContractInfo> GetAll()
        {
            if (Cache)
            {
                List<Supplier_ContractInfo> list = DataCache.GetCache(Key) as List<Supplier_ContractInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Supplier_ContractInfo>(DataProvider.Instance().GetAll(
                    	Table.Supplier_Contract,
                    	PagingHelper.CreateOrder(new OrderObject(TableSupplier_Contract.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Supplier_ContractInfo>(DataProvider.Instance().GetAll(
            	Table.Supplier_Contract,
            	PagingHelper.CreateOrder(new OrderObject(TableSupplier_Contract.ID, SortOrder.Desc))));
        }
        public static List<Supplier_ContractInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Supplier_ContractInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Supplier_ContractInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Supplier_ContractInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Supplier_ContractInfo>(DataProvider.Instance().Find(Table.Supplier_Contract, columnName, value));
        }
        public static Supplier_ContractInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Supplier_ContractInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableSupplier_Contract.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Supplier_ContractInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Supplier_ContractInfo x, Supplier_ContractInfo y)
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
                        case "supplier_contract_name":
                        	rs = PagingHelper.Compare<string>(x.Supplier_Contract_Name, y.Supplier_Contract_Name, obj.Order);
                        	break;
                        case "ordered_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Ordered_Date, y.Ordered_Date, obj.Order);
                        	break;
                        case "supplierid":
                        	rs = PagingHelper.Compare<int>(x.SupplierID, y.SupplierID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "purchase_quantity_bulbs":
                        	rs = PagingHelper.Compare<int>(x.Purchase_Quantity_Bulbs, y.Purchase_Quantity_Bulbs, obj.Order);
                        	break;
                        case "price_eur":
                        	rs = PagingHelper.Compare<double>(x.Price_EUR, y.Price_EUR, obj.Order);
                        	break;
                        case "shipped_quantity_bulbs":
                        	rs = PagingHelper.Compare<int>(x.Shipped_Quantity_Bulbs, y.Shipped_Quantity_Bulbs, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
                        	break;
                        case "comment":
                        	rs = PagingHelper.Compare<string>(x.Comment, y.Comment, obj.Order);
                        	break;
                        case "schedule":
                        	rs = PagingHelper.Compare<string>(x.Schedule, y.Schedule, obj.Order);
                        	break;
                        case "etd":
                        	rs = PagingHelper.Compare<DateTime>(x.ETD, y.ETD, obj.Order);
                        	break;
                        case "eta":
                        	rs = PagingHelper.Compare<DateTime>(x.ETA, y.ETA, obj.Order);
                        	break;
                        case "loading_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Loading_Date, y.Loading_Date, obj.Order);
                        	break;
                        case "etd_cma_schedule":
                        	rs = PagingHelper.Compare<DateTime>(x.ETD_CMA_SCHEDULE, y.ETD_CMA_SCHEDULE, obj.Order);
                        	break;
                        case "eta_cma_schedule":
                        	rs = PagingHelper.Compare<DateTime>(x.ETA_CMA_SCHEDULE, y.ETA_CMA_SCHEDULE, obj.Order);
                        	break;
                        case "etd_one_schedule":
                        	rs = PagingHelper.Compare<DateTime>(x.ETD_ONE_SCHEDULE, y.ETD_ONE_SCHEDULE, obj.Order);
                        	break;
                        case "eta_one_schedule":
                        	rs = PagingHelper.Compare<DateTime>(x.ETA_ONE_SCHEDULE, y.ETA_ONE_SCHEDULE, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableSupplier_Contract.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Supplier_ContractInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Supplier_ContractInfo>(DataProvider.Instance().GetByPage(
            	Table.Supplier_Contract, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Supplier_ContractInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Supplier_ContractInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Supplier_ContractInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Supplier_ContractInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Supplier_ContractInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Supplier_ContractInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Supplier_ContractInfo supplier_ContractInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Supplier_Contract,
            	"@" + TableSupplier_Contract.ID,
            	supplier_ContractInfo.ID, supplier_ContractInfo.Supplier_Contract_Name, supplier_ContractInfo.Ordered_Date, supplier_ContractInfo.SupplierID, supplier_ContractInfo.ItemID, supplier_ContractInfo.Purchase_Quantity_Bulbs, supplier_ContractInfo.Price_EUR, supplier_ContractInfo.Shipped_Quantity_Bulbs, supplier_ContractInfo.Note, supplier_ContractInfo.Comment, supplier_ContractInfo.Schedule, supplier_ContractInfo.ETD, supplier_ContractInfo.ETA, supplier_ContractInfo.Loading_Date, supplier_ContractInfo.ETD_CMA_SCHEDULE, supplier_ContractInfo.ETA_CMA_SCHEDULE, supplier_ContractInfo.ETD_ONE_SCHEDULE, supplier_ContractInfo.ETA_ONE_SCHEDULE, supplier_ContractInfo.InformationID, supplier_ContractInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Supplier_ContractInfo supplier_ContractInfo)
        {
            return InsertUpdateDelete(supplier_ContractInfo, DataProviderAction.Insert);
        }
        public static int Update(Supplier_ContractInfo supplier_ContractInfo)
        {
            return InsertUpdateDelete(supplier_ContractInfo, DataProviderAction.Update);
        }
        public static int Delete(Supplier_ContractInfo supplier_ContractInfo)
        {
            return InsertUpdateDelete(supplier_ContractInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Customer_ContractDAO
    {
        #region Fields
        public static readonly string Key = "__Customer_ContractData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Customer_ContractDAO()
        {
            try
            {
                //<add key="Cache_Customer_Contract" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Customer_Contract"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Customer_ContractInfo> GetAll()
        {
            if (Cache)
            {
                List<Customer_ContractInfo> list = DataCache.GetCache(Key) as List<Customer_ContractInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Customer_ContractInfo>(DataProvider.Instance().GetAll(
                    	Table.Customer_Contract,
                    	PagingHelper.CreateOrder(new OrderObject(TableCustomer_Contract.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Customer_ContractInfo>(DataProvider.Instance().GetAll(
            	Table.Customer_Contract,
            	PagingHelper.CreateOrder(new OrderObject(TableCustomer_Contract.ID, SortOrder.Desc))));
        }
        public static List<Customer_ContractInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Customer_ContractInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ContractInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Customer_ContractInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Customer_ContractInfo>(DataProvider.Instance().Find(Table.Customer_Contract, columnName, value));
        }
        public static Customer_ContractInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Customer_ContractInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableCustomer_Contract.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Customer_ContractInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Customer_ContractInfo x, Customer_ContractInfo y)
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
                        case "customer_contract":
                        	rs = PagingHelper.Compare<string>(x.Customer_Contract, y.Customer_Contract, obj.Order);
                        	break;
                        case "effective_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Effective_Date, y.Effective_Date, obj.Order);
                        	break;
                        case "in_charge":
                        	rs = PagingHelper.Compare<string>(x.In_Charge, y.In_Charge, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "required_supplier":
                        	rs = PagingHelper.Compare<string>(x.Required_Supplier, y.Required_Supplier, obj.Order);
                        	break;
                        case "order_qty_bulbs":
                        	rs = PagingHelper.Compare<int>(x.Order_QTY_Bulbs, y.Order_QTY_Bulbs, obj.Order);
                        	break;
                        case "price_vnd":
                        	rs = PagingHelper.Compare<double>(x.Price_VND, y.Price_VND, obj.Order);
                        	break;
                        case "seeding_date_lunar":
                        	rs = PagingHelper.Compare<DateTime>(x.Seeding_Date_Lunar, y.Seeding_Date_Lunar, obj.Order);
                        	break;
                        case "seeding_date_gregorian":
                        	rs = PagingHelper.Compare<DateTime>(x.Seeding_Date_Gregorian, y.Seeding_Date_Gregorian, obj.Order);
                        	break;
                        case "estimated_arrival_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Estimated_Arrival_Date, y.Estimated_Arrival_Date, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
                        	break;
                        case "date_arrived":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_Arrived, y.Date_Arrived, obj.Order);
                        	break;
                        case "deposit":
                        	rs = PagingHelper.Compare<double>(x.Deposit, y.Deposit, obj.Order);
                        	break;
                        case "date_1":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_1, y.Date_1, obj.Order);
                        	break;
                        case "delivery_1":
                        	rs = PagingHelper.Compare<int>(x.Delivery_1, y.Delivery_1, obj.Order);
                        	break;
                        case "date_2":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_2, y.Date_2, obj.Order);
                        	break;
                        case "delivery_2":
                        	rs = PagingHelper.Compare<int>(x.Delivery_2, y.Delivery_2, obj.Order);
                        	break;
                        case "date_3":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_3, y.Date_3, obj.Order);
                        	break;
                        case "delivery_3":
                        	rs = PagingHelper.Compare<int>(x.Delivery_3, y.Delivery_3, obj.Order);
                        	break;
                        case "date_4":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_4, y.Date_4, obj.Order);
                        	break;
                        case "delivery_4":
                        	rs = PagingHelper.Compare<int>(x.Delivery_4, y.Delivery_4, obj.Order);
                        	break;
                        case "date_5":
                        	rs = PagingHelper.Compare<DateTime>(x.Date_5, y.Date_5, obj.Order);
                        	break;
                        case "delivery_5":
                        	rs = PagingHelper.Compare<int>(x.Delivery_5, y.Delivery_5, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableCustomer_Contract.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Customer_ContractInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Customer_ContractInfo>(DataProvider.Instance().GetByPage(
            	Table.Customer_Contract, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Customer_ContractInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Customer_ContractInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Customer_ContractInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ContractInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ContractInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ContractInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Customer_ContractInfo customer_ContractInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Customer_Contract,
            	"@" + TableCustomer_Contract.ID,
            	customer_ContractInfo.ID, customer_ContractInfo.Customer_Contract, customer_ContractInfo.Effective_Date, customer_ContractInfo.In_Charge, customer_ContractInfo.CustomerID, customer_ContractInfo.ItemID, customer_ContractInfo.Required_Supplier, customer_ContractInfo.Order_QTY_Bulbs, customer_ContractInfo.Price_VND, customer_ContractInfo.Seeding_Date_Lunar, customer_ContractInfo.Seeding_Date_Gregorian, customer_ContractInfo.Estimated_Arrival_Date, customer_ContractInfo.Note, customer_ContractInfo.ContID, customer_ContractInfo.Date_Arrived, customer_ContractInfo.Deposit, customer_ContractInfo.Date_1, customer_ContractInfo.Delivery_1, customer_ContractInfo.Date_2, customer_ContractInfo.Delivery_2, customer_ContractInfo.Date_3, customer_ContractInfo.Delivery_3, customer_ContractInfo.Date_4, customer_ContractInfo.Delivery_4, customer_ContractInfo.Date_5, customer_ContractInfo.Delivery_5, customer_ContractInfo.InformationID, customer_ContractInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Customer_ContractInfo customer_ContractInfo)
        {
            return InsertUpdateDelete(customer_ContractInfo, DataProviderAction.Insert);
        }
        public static int Update(Customer_ContractInfo customer_ContractInfo)
        {
            return InsertUpdateDelete(customer_ContractInfo, DataProviderAction.Update);
        }
        public static int Delete(Customer_ContractInfo customer_ContractInfo)
        {
            return InsertUpdateDelete(customer_ContractInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

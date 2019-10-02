using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class CustomerDAO
    {
        #region Fields
        public static readonly string Key = "__CustomerData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static CustomerDAO()
        {
            try
            {
                //<add key="Cache_Customer" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Customer"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<CustomerInfo> GetAll()
        {
            if (Cache)
            {
                List<CustomerInfo> list = DataCache.GetCache(Key) as List<CustomerInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<CustomerInfo>(DataProvider.Instance().GetAll(
                    	Table.Customer,
                    	PagingHelper.CreateOrder(new OrderObject(TableCustomer.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<CustomerInfo>(DataProvider.Instance().GetAll(
            	Table.Customer,
            	PagingHelper.CreateOrder(new OrderObject(TableCustomer.ID, SortOrder.Desc))));
        }
        public static List<CustomerInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<CustomerInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<CustomerInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static CustomerInfo Find(object columnName, object value)
        {
            return CBO.FillObject<CustomerInfo>(DataProvider.Instance().Find(Table.Customer, columnName, value));
        }
        public static CustomerInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(CustomerInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableCustomer.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<CustomerInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(CustomerInfo x, CustomerInfo y)
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
                        case "customercode":
                        	rs = PagingHelper.Compare<string>(x.CustomerCode, y.CustomerCode, obj.Order);
                        	break;
                        case "customername":
                        	rs = PagingHelper.Compare<string>(x.CustomerName, y.CustomerName, obj.Order);
                        	break;
                        case "email":
                        	rs = PagingHelper.Compare<string>(x.Email, y.Email, obj.Order);
                        	break;
                        case "phone":
                        	rs = PagingHelper.Compare<string>(x.Phone, y.Phone, obj.Order);
                        	break;
                        case "mobile":
                        	rs = PagingHelper.Compare<string>(x.Mobile, y.Mobile, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableCustomer.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<CustomerInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<CustomerInfo>(DataProvider.Instance().GetByPage(
            	Table.Customer, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<CustomerInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<CustomerInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<CustomerInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<CustomerInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<CustomerInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<CustomerInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(CustomerInfo customerInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Customer,
            	"@" + TableCustomer.ID,
            	customerInfo.ID, customerInfo.CustomerCode, customerInfo.CustomerName, customerInfo.Email, customerInfo.Phone, customerInfo.Mobile, customerInfo.InformationID, customerInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(CustomerInfo customerInfo)
        {
            return InsertUpdateDelete(customerInfo, DataProviderAction.Insert);
        }
        public static int Update(CustomerInfo customerInfo)
        {
            return InsertUpdateDelete(customerInfo, DataProviderAction.Update);
        }
        public static int Delete(CustomerInfo customerInfo)
        {
            return InsertUpdateDelete(customerInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

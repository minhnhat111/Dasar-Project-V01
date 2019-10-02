using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class AccountDAO
    {
        #region Fields
        public static readonly string Key = "__AccountData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static AccountDAO()
        {
            try
            {
                //<add key="Cache_Account" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Account"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<AccountInfo> GetAll()
        {
            if (Cache)
            {
                List<AccountInfo> list = DataCache.GetCache(Key) as List<AccountInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<AccountInfo>(DataProvider.Instance().GetAll(
                    	Table.Account,
                    	PagingHelper.CreateOrder(new OrderObject(TableAccount.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<AccountInfo>(DataProvider.Instance().GetAll(
            	Table.Account,
            	PagingHelper.CreateOrder(new OrderObject(TableAccount.ID, SortOrder.Desc))));
        }
        public static List<AccountInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<AccountInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<AccountInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static AccountInfo Find(object columnName, object value)
        {
            return CBO.FillObject<AccountInfo>(DataProvider.Instance().Find(Table.Account, columnName, value));
        }
        public static AccountInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(AccountInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableAccount.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<AccountInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(AccountInfo x, AccountInfo y)
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
                        case "accountname":
                        	rs = PagingHelper.Compare<string>(x.AccountName, y.AccountName, obj.Order);
                        	break;
                        case "password":
                        	rs = PagingHelper.Compare<string>(x.Password, y.Password, obj.Order);
                        	break;
                        case "firstname":
                        	rs = PagingHelper.Compare<string>(x.FirstName, y.FirstName, obj.Order);
                        	break;
                        case "lastname":
                        	rs = PagingHelper.Compare<string>(x.LastName, y.LastName, obj.Order);
                        	break;
                        case "identifyid":
                        	rs = PagingHelper.Compare<string>(x.IdentifyID, y.IdentifyID, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableAccount.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<AccountInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<AccountInfo>(DataProvider.Instance().GetByPage(
            	Table.Account, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<AccountInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<AccountInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<AccountInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<AccountInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<AccountInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<AccountInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(AccountInfo accountInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Account,
            	"@" + TableAccount.ID,
            	accountInfo.ID, accountInfo.AccountName, accountInfo.Password, accountInfo.FirstName, accountInfo.LastName, accountInfo.IdentifyID, accountInfo.Email, accountInfo.Phone, accountInfo.Mobile, accountInfo.InformationID, accountInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(AccountInfo accountInfo)
        {
            return InsertUpdateDelete(accountInfo, DataProviderAction.Insert);
        }
        public static int Update(AccountInfo accountInfo)
        {
            return InsertUpdateDelete(accountInfo, DataProviderAction.Update);
        }
        public static int Delete(AccountInfo accountInfo)
        {
            return InsertUpdateDelete(accountInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

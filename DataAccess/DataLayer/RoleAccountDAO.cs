using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RoleAccountDAO
    {
        #region Fields
        public static readonly string Key = "__RoleAccountData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static RoleAccountDAO()
        {
            try
            {
                //<add key="Cache_RoleAccount" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_RoleAccount"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<RoleAccountInfo> GetAll()
        {
            if (Cache)
            {
                List<RoleAccountInfo> list = DataCache.GetCache(Key) as List<RoleAccountInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<RoleAccountInfo>(DataProvider.Instance().GetAll(
                    	Table.RoleAccount,
                    	PagingHelper.CreateOrder(new OrderObject(TableRoleAccount.RoleID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<RoleAccountInfo>(DataProvider.Instance().GetAll(
            	Table.RoleAccount,
            	PagingHelper.CreateOrder(new OrderObject(TableRoleAccount.RoleID, SortOrder.Desc))));
        }
        public static List<RoleAccountInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<RoleAccountInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<RoleAccountInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static RoleAccountInfo Find(object columnName, object value)
        {
            return CBO.FillObject<RoleAccountInfo>(DataProvider.Instance().Find(Table.RoleAccount, columnName, value));
        }
        #endregion

        #region Common
        public static Comparison<RoleAccountInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(RoleAccountInfo x, RoleAccountInfo y)
            {
                int rs = 0;
                string name;
                foreach (OrderObject obj in orderObjects)
                {
                    name = obj.ColumnName.ToLower();
                    switch (name)
                    {
                        case "roleid":
                        	rs = PagingHelper.Compare<int>(x.RoleID, y.RoleID, obj.Order);
                        	break;
                        case "accountid":
                        	rs = PagingHelper.Compare<int>(x.AccountID, y.AccountID, obj.Order);
                        	break;
                        case "active":
                        	rs = PagingHelper.Compare<int>(x.Active, y.Active, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableRoleAccount.RoleID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<RoleAccountInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<RoleAccountInfo>(DataProvider.Instance().GetByPage(
            	Table.RoleAccount, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<RoleAccountInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<RoleAccountInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<RoleAccountInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleAccountInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleAccountInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleAccountInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(RoleAccountInfo roleAccountInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_RoleAccount,
            	"",
            	roleAccountInfo.RoleID, roleAccountInfo.AccountID, roleAccountInfo.Active, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(RoleAccountInfo roleAccountInfo)
        {
            return InsertUpdateDelete(roleAccountInfo, DataProviderAction.Insert);
        }
        public static int Update(RoleAccountInfo roleAccountInfo)
        {
            return InsertUpdateDelete(roleAccountInfo, DataProviderAction.Update);
        }
        public static int Delete(RoleAccountInfo roleAccountInfo)
        {
            return InsertUpdateDelete(roleAccountInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RoleDAO
    {
        #region Fields
        public static readonly string Key = "__RoleData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static RoleDAO()
        {
            try
            {
                //<add key="Cache_Role" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Role"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<RoleInfo> GetAll()
        {
            if (Cache)
            {
                List<RoleInfo> list = DataCache.GetCache(Key) as List<RoleInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<RoleInfo>(DataProvider.Instance().GetAll(
                    	Table.Role,
                    	PagingHelper.CreateOrder(new OrderObject(TableRole.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<RoleInfo>(DataProvider.Instance().GetAll(
            	Table.Role,
            	PagingHelper.CreateOrder(new OrderObject(TableRole.ID, SortOrder.Desc))));
        }
        public static List<RoleInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<RoleInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<RoleInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static RoleInfo Find(object columnName, object value)
        {
            return CBO.FillObject<RoleInfo>(DataProvider.Instance().Find(Table.Role, columnName, value));
        }
        public static RoleInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(RoleInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableRole.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<RoleInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(RoleInfo x, RoleInfo y)
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
                        case "rolename":
                        	rs = PagingHelper.Compare<string>(x.RoleName, y.RoleName, obj.Order);
                        	break;
                        case "functions":
                        	rs = PagingHelper.Compare<string>(x.Functions, y.Functions, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableRole.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<RoleInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<RoleInfo>(DataProvider.Instance().GetByPage(
            	Table.Role, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<RoleInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<RoleInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<RoleInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RoleInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(RoleInfo roleInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Role,
            	"@" + TableRole.ID,
            	roleInfo.ID, roleInfo.RoleName, roleInfo.Functions, roleInfo.InformationID, roleInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(RoleInfo roleInfo)
        {
            return InsertUpdateDelete(roleInfo, DataProviderAction.Insert);
        }
        public static int Update(RoleInfo roleInfo)
        {
            return InsertUpdateDelete(roleInfo, DataProviderAction.Update);
        }
        public static int Delete(RoleInfo roleInfo)
        {
            return InsertUpdateDelete(roleInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

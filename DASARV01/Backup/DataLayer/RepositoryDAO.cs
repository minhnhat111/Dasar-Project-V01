using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RepositoryDAO
    {
        #region Fields
        public static readonly string Key = "__RepositoryData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static RepositoryDAO()
        {
            try
            {
                //<add key="Cache_Repository" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Repository"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<RepositoryInfo> GetAll()
        {
            if (Cache)
            {
                List<RepositoryInfo> list = DataCache.GetCache(Key) as List<RepositoryInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<RepositoryInfo>(DataProvider.Instance().GetAll(
                    	Table.Repository,
                    	PagingHelper.CreateOrder(new OrderObject(TableRepository.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<RepositoryInfo>(DataProvider.Instance().GetAll(
            	Table.Repository,
            	PagingHelper.CreateOrder(new OrderObject(TableRepository.ID, SortOrder.Desc))));
        }
        public static List<RepositoryInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<RepositoryInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<RepositoryInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static RepositoryInfo Find(object columnName, object value)
        {
            return CBO.FillObject<RepositoryInfo>(DataProvider.Instance().Find(Table.Repository, columnName, value));
        }
        public static RepositoryInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(RepositoryInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableRepository.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<RepositoryInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(RepositoryInfo x, RepositoryInfo y)
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
                        case "repo_name":
                        	rs = PagingHelper.Compare<string>(x.Repo_Name, y.Repo_Name, obj.Order);
                        	break;
                        case "location":
                        	rs = PagingHelper.Compare<string>(x.Location, y.Location, obj.Order);
                        	break;
                        case "palletid":
                        	rs = PagingHelper.Compare<int>(x.PalletID, y.PalletID, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
                        	break;
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableRepository.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<RepositoryInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<RepositoryInfo>(DataProvider.Instance().GetByPage(
            	Table.Repository, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<RepositoryInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<RepositoryInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<RepositoryInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RepositoryInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RepositoryInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<RepositoryInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(RepositoryInfo repositoryInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Repository,
            	"@" + TableRepository.ID,
            	repositoryInfo.ID, repositoryInfo.Repo_Name, repositoryInfo.Location, repositoryInfo.PalletID, repositoryInfo.ItemID, repositoryInfo.ContID, repositoryInfo.CustomerID, repositoryInfo.InformationID, repositoryInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(RepositoryInfo repositoryInfo)
        {
            return InsertUpdateDelete(repositoryInfo, DataProviderAction.Insert);
        }
        public static int Update(RepositoryInfo repositoryInfo)
        {
            return InsertUpdateDelete(repositoryInfo, DataProviderAction.Update);
        }
        public static int Delete(RepositoryInfo repositoryInfo)
        {
            return InsertUpdateDelete(repositoryInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

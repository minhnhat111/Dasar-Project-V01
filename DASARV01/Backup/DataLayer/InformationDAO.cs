using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class InformationDAO
    {
        #region Fields
        public static readonly string Key = "__InformationData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static InformationDAO()
        {
            try
            {
                //<add key="Cache_Information" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Information"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<InformationInfo> GetAll()
        {
            if (Cache)
            {
                List<InformationInfo> list = DataCache.GetCache(Key) as List<InformationInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<InformationInfo>(DataProvider.Instance().GetAll(
                    	Table.Information,
                    	PagingHelper.CreateOrder(new OrderObject(TableInformation.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<InformationInfo>(DataProvider.Instance().GetAll(
            	Table.Information,
            	PagingHelper.CreateOrder(new OrderObject(TableInformation.ID, SortOrder.Desc))));
        }
        public static List<InformationInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<InformationInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<InformationInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static InformationInfo Find(object columnName, object value)
        {
            return CBO.FillObject<InformationInfo>(DataProvider.Instance().Find(Table.Information, columnName, value));
        }
        public static InformationInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(InformationInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableInformation.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<InformationInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(InformationInfo x, InformationInfo y)
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
                        case "nameinfor":
                        	rs = PagingHelper.Compare<string>(x.NameInfor, y.NameInfor, obj.Order);
                        	break;
                        case "datecreated":
                        	rs = PagingHelper.Compare<DateTime>(x.DateCreated, y.DateCreated, obj.Order);
                        	break;
                        case "createdby":
                        	rs = PagingHelper.Compare<string>(x.CreatedBy, y.CreatedBy, obj.Order);
                        	break;
                        case "datemodified":
                        	rs = PagingHelper.Compare<DateTime>(x.DateModified, y.DateModified, obj.Order);
                        	break;
                        case "modifiedby":
                        	rs = PagingHelper.Compare<string>(x.ModifiedBy, y.ModifiedBy, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableInformation.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<InformationInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<InformationInfo>(DataProvider.Instance().GetByPage(
            	Table.Information, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<InformationInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<InformationInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<InformationInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<InformationInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<InformationInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<InformationInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(InformationInfo informationInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Information,
            	"@" + TableInformation.ID,
            	informationInfo.ID, informationInfo.NameInfor, informationInfo.DateCreated, informationInfo.CreatedBy, informationInfo.DateModified, informationInfo.ModifiedBy, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(InformationInfo informationInfo)
        {
            return InsertUpdateDelete(informationInfo, DataProviderAction.Insert);
        }
        public static int Update(InformationInfo informationInfo)
        {
            return InsertUpdateDelete(informationInfo, DataProviderAction.Update);
        }
        public static int Delete(InformationInfo informationInfo)
        {
            return InsertUpdateDelete(informationInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

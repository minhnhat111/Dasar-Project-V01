using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class PalletDAO
    {
        #region Fields
        public static readonly string Key = "__PalletData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static PalletDAO()
        {
            try
            {
                //<add key="Cache_Pallet" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Pallet"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<PalletInfo> GetAll()
        {
            if (Cache)
            {
                List<PalletInfo> list = DataCache.GetCache(Key) as List<PalletInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<PalletInfo>(DataProvider.Instance().GetAll(
                    	Table.Pallet,
                    	PagingHelper.CreateOrder(new OrderObject(TablePallet.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<PalletInfo>(DataProvider.Instance().GetAll(
            	Table.Pallet,
            	PagingHelper.CreateOrder(new OrderObject(TablePallet.ID, SortOrder.Desc))));
        }
        public static List<PalletInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<PalletInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<PalletInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static PalletInfo Find(object columnName, object value)
        {
            return CBO.FillObject<PalletInfo>(DataProvider.Instance().Find(Table.Pallet, columnName, value));
        }
        #endregion

        #region Common
        public static Comparison<PalletInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(PalletInfo x, PalletInfo y)
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
                        case "pallet":
                        	rs = PagingHelper.Compare<string>(x.Pallet, y.Pallet, obj.Order);
                        	break;
                        case "tray_number":
                        	rs = PagingHelper.Compare<int>(x.Tray_Number, y.Tray_Number, obj.Order);
                        	break;
                        case "reposityid":
                        	rs = PagingHelper.Compare<int>(x.ReposityID, y.ReposityID, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
                        	break;
                        case "empty_pallet":
                        	rs = PagingHelper.Compare<string>(x.Empty_Pallet, y.Empty_Pallet, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TablePallet.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<PalletInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<PalletInfo>(DataProvider.Instance().GetByPage(
            	Table.Pallet, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<PalletInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<PalletInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<PalletInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<PalletInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<PalletInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<PalletInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(PalletInfo palletInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Pallet,
            	"",
            	palletInfo.ID, palletInfo.Pallet, palletInfo.Tray_Number, palletInfo.ReposityID, palletInfo.ContID, palletInfo.Empty_Pallet, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(PalletInfo palletInfo)
        {
            return InsertUpdateDelete(palletInfo, DataProviderAction.Insert);
        }
        public static int Update(PalletInfo palletInfo)
        {
            return InsertUpdateDelete(palletInfo, DataProviderAction.Update);
        }
        public static int Delete(PalletInfo palletInfo)
        {
            return InsertUpdateDelete(palletInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

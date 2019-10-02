using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ItemDAO
    {
        #region Fields
        public static readonly string Key = "__ItemData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static ItemDAO()
        {
            try
            {
                //<add key="Cache_Item" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Item"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<ItemInfo> GetAll()
        {
            if (Cache)
            {
                List<ItemInfo> list = DataCache.GetCache(Key) as List<ItemInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<ItemInfo>(DataProvider.Instance().GetAll(
                    	Table.Item,
                    	PagingHelper.CreateOrder(new OrderObject(TableItem.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<ItemInfo>(DataProvider.Instance().GetAll(
            	Table.Item,
            	PagingHelper.CreateOrder(new OrderObject(TableItem.ID, SortOrder.Desc))));
        }
        public static List<ItemInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<ItemInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<ItemInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static ItemInfo Find(object columnName, object value)
        {
            return CBO.FillObject<ItemInfo>(DataProvider.Instance().Find(Table.Item, columnName, value));
        }
        public static ItemInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(ItemInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableItem.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<ItemInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(ItemInfo x, ItemInfo y)
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
                        case "itemid":
                        	rs = PagingHelper.Compare<string>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "itemname":
                        	rs = PagingHelper.Compare<string>(x.ItemName, y.ItemName, obj.Order);
                        	break;
                        case "type":
                        	rs = PagingHelper.Compare<string>(x.Type, y.Type, obj.Order);
                        	break;
                        case "size":
                        	rs = PagingHelper.Compare<string>(x.Size, y.Size, obj.Order);
                        	break;
                        case "itemsperpack":
                        	rs = PagingHelper.Compare<int>(x.ItemsPerPack, y.ItemsPerPack, obj.Order);
                        	break;
                        case "crop":
                        	rs = PagingHelper.Compare<string>(x.Crop, y.Crop, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
                        	break;
                        case "information":
                        	rs = PagingHelper.Compare<int>(x.Information, y.Information, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableItem.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<ItemInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<ItemInfo>(DataProvider.Instance().GetByPage(
            	Table.Item, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<ItemInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<ItemInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<ItemInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ItemInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ItemInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ItemInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(ItemInfo itemInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Item,
            	"@" + TableItem.ID,
            	itemInfo.ID, itemInfo.ItemID, itemInfo.ItemName, itemInfo.Type, itemInfo.Size, itemInfo.ItemsPerPack, itemInfo.Crop, itemInfo.Note, itemInfo.Information, itemInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(ItemInfo itemInfo)
        {
            return InsertUpdateDelete(itemInfo, DataProviderAction.Insert);
        }
        public static int Update(ItemInfo itemInfo)
        {
            return InsertUpdateDelete(itemInfo, DataProviderAction.Update);
        }
        public static int Delete(ItemInfo itemInfo)
        {
            return InsertUpdateDelete(itemInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

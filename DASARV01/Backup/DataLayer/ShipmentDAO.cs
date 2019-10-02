using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ShipmentDAO
    {
        #region Fields
        public static readonly string Key = "__ShipmentData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static ShipmentDAO()
        {
            try
            {
                //<add key="Cache_Shipment" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Shipment"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<ShipmentInfo> GetAll()
        {
            if (Cache)
            {
                List<ShipmentInfo> list = DataCache.GetCache(Key) as List<ShipmentInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<ShipmentInfo>(DataProvider.Instance().GetAll(
                    	Table.Shipment,
                    	PagingHelper.CreateOrder(new OrderObject(TableShipment.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<ShipmentInfo>(DataProvider.Instance().GetAll(
            	Table.Shipment,
            	PagingHelper.CreateOrder(new OrderObject(TableShipment.ID, SortOrder.Desc))));
        }
        public static List<ShipmentInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<ShipmentInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<ShipmentInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static ShipmentInfo Find(object columnName, object value)
        {
            return CBO.FillObject<ShipmentInfo>(DataProvider.Instance().Find(Table.Shipment, columnName, value));
        }
        public static ShipmentInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(ShipmentInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableShipment.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<ShipmentInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(ShipmentInfo x, ShipmentInfo y)
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
                        case "year":
                        	rs = PagingHelper.Compare<int>(x.Year, y.Year, obj.Order);
                        	break;
                        case "month":
                        	rs = PagingHelper.Compare<DateTime>(x.Month, y.Month, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
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
                        case "lot":
                        	rs = PagingHelper.Compare<string>(x.Lot, y.Lot, obj.Order);
                        	break;
                        case "certificate":
                        	rs = PagingHelper.Compare<int>(x.Certificate, y.Certificate, obj.Order);
                        	break;
                        case "quality_control_assessment":
                        	rs = PagingHelper.Compare<string>(x.Quality_Control_Assessment, y.Quality_Control_Assessment, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableShipment.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<ShipmentInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<ShipmentInfo>(DataProvider.Instance().GetByPage(
            	Table.Shipment, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<ShipmentInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<ShipmentInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<ShipmentInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ShipmentInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ShipmentInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<ShipmentInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(ShipmentInfo shipmentInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Shipment,
            	"@" + TableShipment.ID,
            	shipmentInfo.ID, shipmentInfo.Year, shipmentInfo.Month, shipmentInfo.ContID, shipmentInfo.ItemID, shipmentInfo.Purchase_Quantity_Bulbs, shipmentInfo.Price_EUR, shipmentInfo.Lot, shipmentInfo.Certificate, shipmentInfo.Quality_Control_Assessment, shipmentInfo.Note, shipmentInfo.InformationID, shipmentInfo.OrderID, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(ShipmentInfo shipmentInfo)
        {
            return InsertUpdateDelete(shipmentInfo, DataProviderAction.Insert);
        }
        public static int Update(ShipmentInfo shipmentInfo)
        {
            return InsertUpdateDelete(shipmentInfo, DataProviderAction.Update);
        }
        public static int Delete(ShipmentInfo shipmentInfo)
        {
            return InsertUpdateDelete(shipmentInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using DataTools;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Customer_ComplaintDAO
    {
        #region Fields
        public static readonly string Key = "__Customer_ComplaintData";
        public static bool Cache;
        private static OrderObject[] orderObjects;
        #endregion

        #region Contructors
        static Customer_ComplaintDAO()
        {
            try
            {
                //<add key="Cache_Customer_Complaint" value="true"/>
                Cache = ConvertType.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("Cache_Customer_Complaint"));
            }
            catch
            {
                 Cache = false;
            }
        }
        #endregion
  
        #region Methods
        #region GetAll
        public static List<Customer_ComplaintInfo> GetAll()
        {
            if (Cache)
            {
                List<Customer_ComplaintInfo> list = DataCache.GetCache(Key) as List<Customer_ComplaintInfo>;
                if (list == null)
                {
                    list = CBO.FillCollection<Customer_ComplaintInfo>(DataProvider.Instance().GetAll(
                    	Table.Customer_Complaint,
                    	PagingHelper.CreateOrder(new OrderObject(TableCustomer_Complaint.ID, SortOrder.Desc))));
                    list.TrimExcess();
                    DataCache.SetCache(Key, list);
                }
                return list;
            }
            return CBO.FillCollection<Customer_ComplaintInfo>(DataProvider.Instance().GetAll(
            	Table.Customer_Complaint,
            	PagingHelper.CreateOrder(new OrderObject(TableCustomer_Complaint.ID, SortOrder.Desc))));
        }
        public static List<Customer_ComplaintInfo> GetTop(FilterObject[] filters, OrderObject[] orders)
        {
            return GetTop(filters, orders, -1);
        }
        public static List<Customer_ComplaintInfo> GetTop(string fieldList, FilterObject[] filters, OrderObject[] orders, int number)
        {
            int pageCount = 0;
            int totalRowCount = 0;
            return GetByPage(fieldList, filters, orders, 1, number, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ComplaintInfo> GetTop(FilterObject[] filters, OrderObject[] orders, int number)
        {
            return GetTop("*", filters, orders, number);
        }
        #endregion

        #region Find
        public static Customer_ComplaintInfo Find(object columnName, object value)
        {
            return CBO.FillObject<Customer_ComplaintInfo>(DataProvider.Instance().Find(Table.Customer_Complaint, columnName, value));
        }
        public static Customer_ComplaintInfo Find(int iD)
        {
            if (Cache)
            {
                return GetAll().Find(delegate(Customer_ComplaintInfo objObject)
                {
                    return objObject.ID == iD;
                });
            }
            return Find(TableCustomer_Complaint.ID, iD);
        }
        #endregion

        #region Common
        public static Comparison<Customer_ComplaintInfo> Comparison(OrderObject[] orderObjects)
        {
            if (orderObjects == null) return null;
            if (orderObjects.Length == 0) return null;
            return delegate(Customer_ComplaintInfo x, Customer_ComplaintInfo y)
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
                        case "customerid":
                        	rs = PagingHelper.Compare<int>(x.CustomerID, y.CustomerID, obj.Order);
                        	break;
                        case "grower_claim":
                        	rs = PagingHelper.Compare<string>(x.Grower_Claim, y.Grower_Claim, obj.Order);
                        	break;
                        case "itemid":
                        	rs = PagingHelper.Compare<int>(x.ItemID, y.ItemID, obj.Order);
                        	break;
                        case "supplierid":
                        	rs = PagingHelper.Compare<int>(x.SupplierID, y.SupplierID, obj.Order);
                        	break;
                        case "lot":
                        	rs = PagingHelper.Compare<string>(x.Lot, y.Lot, obj.Order);
                        	break;
                        case "certificate":
                        	rs = PagingHelper.Compare<int>(x.Certificate, y.Certificate, obj.Order);
                        	break;
                        case "import_quantity":
                        	rs = PagingHelper.Compare<int>(x.Import_Quantity, y.Import_Quantity, obj.Order);
                        	break;
                        case "delivery_quantity":
                        	rs = PagingHelper.Compare<int>(x.Delivery_Quantity, y.Delivery_Quantity, obj.Order);
                        	break;
                        case "selling_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Selling_Date, y.Selling_Date, obj.Order);
                        	break;
                        case "contid":
                        	rs = PagingHelper.Compare<string>(x.ContID, y.ContID, obj.Order);
                        	break;
                        case "dmg_qty_before":
                        	rs = PagingHelper.Compare<int>(x.Dmg_QTY_Before, y.Dmg_QTY_Before, obj.Order);
                        	break;
                        case "dmg_qty_after":
                        	rs = PagingHelper.Compare<int>(x.Dmg_QTY_After, y.Dmg_QTY_After, obj.Order);
                        	break;
                        case "checked_date":
                        	rs = PagingHelper.Compare<DateTime>(x.Checked_Date, y.Checked_Date, obj.Order);
                        	break;
                        case "grower_before":
                        	rs = PagingHelper.Compare<string>(x.Grower_Before, y.Grower_Before, obj.Order);
                        	break;
                        case "grower_after":
                        	rs = PagingHelper.Compare<string>(x.Grower_After, y.Grower_After, obj.Order);
                        	break;
                        case "conclusion_before":
                        	rs = PagingHelper.Compare<string>(x.Conclusion_Before, y.Conclusion_Before, obj.Order);
                        	break;
                        case "conclusion_after":
                        	rs = PagingHelper.Compare<string>(x.Conclusion_After, y.Conclusion_After, obj.Order);
                        	break;
                        case "technical":
                        	rs = PagingHelper.Compare<string>(x.Technical, y.Technical, obj.Order);
                        	break;
                        case "solution":
                        	rs = PagingHelper.Compare<string>(x.Solution, y.Solution, obj.Order);
                        	break;
                        case "status":
                        	rs = PagingHelper.Compare<string>(x.Status, y.Status, obj.Order);
                        	break;
                        case "claiming_supplier":
                        	rs = PagingHelper.Compare<string>(x.Claiming_Supplier, y.Claiming_Supplier, obj.Order);
                        	break;
                        case "note":
                        	rs = PagingHelper.Compare<string>(x.Note, y.Note, obj.Order);
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
            	orderObjects = new OrderObject[] { new OrderObject(TableCustomer_Complaint.ID, SortOrder.Desc) };
            return orderObjects;
        }
        #endregion

        #region GetByPage
        public static List<Customer_ComplaintInfo> GetByPage(string fieldList, FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (!(orderObjects != null && orderObjects.Length > 0))
            	orderObjects = DefaultOrder();
            return CBO.FillCollection<Customer_ComplaintInfo>(DataProvider.Instance().GetByPage(
            	Table.Customer_Complaint, fieldList, filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount));
        }
        public static List<Customer_ComplaintInfo> GetByPage(FilterObject[] filterObjects, OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            if (Cache && (filterObjects == null || filterObjects.Length == 0))
            {
                List<Customer_ComplaintInfo> list = GetAll(); 
                totalRowCount = list.Count;
                return PagingHelper.GetCollection<Customer_ComplaintInfo>(list, Comparison(orderObjects), pageNum, pageSize, ref pageCount);
            }
            return GetByPage("*", filterObjects, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ComplaintInfo> GetByPage(FilterObject[] filterObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(filterObjects, DefaultOrder(), pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ComplaintInfo> GetByPage(OrderObject[] orderObjects, int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(null, orderObjects, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        public static List<Customer_ComplaintInfo> GetByPage(int pageNum, int pageSize, ref int pageCount, ref int totalRowCount)
        {
            return GetByPage(new OrderObject[] { }, pageNum, pageSize, ref pageCount, ref totalRowCount);
        }
        #endregion

        #region InsertUpdateDelete
        private static int InsertUpdateDelete(Customer_ComplaintInfo customer_ComplaintInfo, DataProviderAction action)
        {
            int rs = DataProvider.Instance().InsertUpdateDelete(
            	action,
            	StoredProcedureName.InsertUpdateDelete_Customer_Complaint,
            	"@" + TableCustomer_Complaint.ID,
            	customer_ComplaintInfo.ID, customer_ComplaintInfo.CustomerID, customer_ComplaintInfo.Grower_Claim, customer_ComplaintInfo.ItemID, customer_ComplaintInfo.SupplierID, customer_ComplaintInfo.Lot, customer_ComplaintInfo.Certificate, customer_ComplaintInfo.Import_Quantity, customer_ComplaintInfo.Delivery_Quantity, customer_ComplaintInfo.Selling_Date, customer_ComplaintInfo.ContID, customer_ComplaintInfo.Dmg_QTY_Before, customer_ComplaintInfo.Dmg_QTY_After, customer_ComplaintInfo.Checked_Date, customer_ComplaintInfo.Grower_Before, customer_ComplaintInfo.Grower_After, customer_ComplaintInfo.Conclusion_Before, customer_ComplaintInfo.Conclusion_After, customer_ComplaintInfo.Technical, customer_ComplaintInfo.Solution, customer_ComplaintInfo.Status, customer_ComplaintInfo.Claiming_Supplier, customer_ComplaintInfo.Note, 
            	(int)action);
            if (rs > 0 && Cache)
            	DataCache.RemoveCache(Key);
            return rs;
        }
        public static int Insert(Customer_ComplaintInfo customer_ComplaintInfo)
        {
            return InsertUpdateDelete(customer_ComplaintInfo, DataProviderAction.Insert);
        }
        public static int Update(Customer_ComplaintInfo customer_ComplaintInfo)
        {
            return InsertUpdateDelete(customer_ComplaintInfo, DataProviderAction.Update);
        }
        public static int Delete(Customer_ComplaintInfo customer_ComplaintInfo)
        {
            return InsertUpdateDelete(customer_ComplaintInfo, DataProviderAction.Delete);
        }
        #endregion
        
        #endregion
    }
}

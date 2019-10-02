using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Supplier_ContractInfo
    {
        #region Fields
        private int _ID;
        private string _Supplier_Contract_Name;
        private DateTime _Ordered_Date = DataTools.Null.NullSqlDate;
        private int _SupplierID;
        private int _ItemID;
        private int _Purchase_Quantity_Bulbs;
        private double _Price_EUR;
        private int _Shipped_Quantity_Bulbs;
        private string _Note;
        private string _Comment;
        private string _Schedule;
        private DateTime _ETD = DataTools.Null.NullSqlDate;
        private DateTime _ETA = DataTools.Null.NullSqlDate;
        private DateTime _Loading_Date = DataTools.Null.NullSqlDate;
        private DateTime _ETD_CMA_SCHEDULE = DataTools.Null.NullSqlDate;
        private DateTime _ETA_CMA_SCHEDULE = DataTools.Null.NullSqlDate;
        private DateTime _ETD_ONE_SCHEDULE = DataTools.Null.NullSqlDate;
        private DateTime _ETA_ONE_SCHEDULE = DataTools.Null.NullSqlDate;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Supplier_Contract_Name
        {
            get { return _Supplier_Contract_Name; }
            set { _Supplier_Contract_Name = value; }
        }
        public DateTime Ordered_Date
        {
            get { return _Ordered_Date; }
            set { _Ordered_Date = value; }
        }
        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public int Purchase_Quantity_Bulbs
        {
            get { return _Purchase_Quantity_Bulbs; }
            set { _Purchase_Quantity_Bulbs = value; }
        }
        public double Price_EUR
        {
            get { return _Price_EUR; }
            set { _Price_EUR = value; }
        }
        public int Shipped_Quantity_Bulbs
        {
            get { return _Shipped_Quantity_Bulbs; }
            set { _Shipped_Quantity_Bulbs = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        public string Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }
        public DateTime ETD
        {
            get { return _ETD; }
            set { _ETD = value; }
        }
        public DateTime ETA
        {
            get { return _ETA; }
            set { _ETA = value; }
        }
        public DateTime Loading_Date
        {
            get { return _Loading_Date; }
            set { _Loading_Date = value; }
        }
        public DateTime ETD_CMA_SCHEDULE
        {
            get { return _ETD_CMA_SCHEDULE; }
            set { _ETD_CMA_SCHEDULE = value; }
        }
        public DateTime ETA_CMA_SCHEDULE
        {
            get { return _ETA_CMA_SCHEDULE; }
            set { _ETA_CMA_SCHEDULE = value; }
        }
        public DateTime ETD_ONE_SCHEDULE
        {
            get { return _ETD_ONE_SCHEDULE; }
            set { _ETD_ONE_SCHEDULE = value; }
        }
        public DateTime ETA_ONE_SCHEDULE
        {
            get { return _ETA_ONE_SCHEDULE; }
            set { _ETA_ONE_SCHEDULE = value; }
        }
        public int InformationID
        {
            get { return _InformationID; }
            set { _InformationID = value; }
        }
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        #endregion

        #region Contructors
        public Supplier_ContractInfo()
        {
        }
        public Supplier_ContractInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Supplier_ContractDAO.Insert(this);
        }
        public int Update()
        {
            return Supplier_ContractDAO.Update(this);
        }
        public int Delete()
        {
            return Supplier_ContractDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

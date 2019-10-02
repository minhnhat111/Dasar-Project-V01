using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Monitoring_Seed_QuantityInfo
    {
        #region Fields
        private int _ID;
        private DateTime _Date_Added = DataTools.Null.NullSqlDate;
        private string _ContID;
        private int _ItemID;
        private int _SupplierID;
        private string _Lot;
        private int _Certificate;
        private string _Status;
        private int _CustomerID;
        private int _Export_Quantity;
        private DateTime _Export_Date = DataTools.Null.NullSqlDate;
        private int _Damaged_Quantity;
        private string _Customer_Feedback;
        private string _Damaged_Status;
        private DateTime _Checked_Date = DataTools.Null.NullSqlDate;
        private string _Note;
        private string _Process_Status_Customer;
        private string _Process_Status_Supplier;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public DateTime Date_Added
        {
            get { return _Date_Added; }
            set { _Date_Added = value; }
        }
        public string ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        public string Lot
        {
            get { return _Lot; }
            set { _Lot = value; }
        }
        public int Certificate
        {
            get { return _Certificate; }
            set { _Certificate = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public int Export_Quantity
        {
            get { return _Export_Quantity; }
            set { _Export_Quantity = value; }
        }
        public DateTime Export_Date
        {
            get { return _Export_Date; }
            set { _Export_Date = value; }
        }
        public int Damaged_Quantity
        {
            get { return _Damaged_Quantity; }
            set { _Damaged_Quantity = value; }
        }
        public string Customer_Feedback
        {
            get { return _Customer_Feedback; }
            set { _Customer_Feedback = value; }
        }
        public string Damaged_Status
        {
            get { return _Damaged_Status; }
            set { _Damaged_Status = value; }
        }
        public DateTime Checked_Date
        {
            get { return _Checked_Date; }
            set { _Checked_Date = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public string Process_Status_Customer
        {
            get { return _Process_Status_Customer; }
            set { _Process_Status_Customer = value; }
        }
        public string Process_Status_Supplier
        {
            get { return _Process_Status_Supplier; }
            set { _Process_Status_Supplier = value; }
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
        public Monitoring_Seed_QuantityInfo()
        {
        }
        public Monitoring_Seed_QuantityInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Monitoring_Seed_QuantityDAO.Insert(this);
        }
        public int Update()
        {
            return Monitoring_Seed_QuantityDAO.Update(this);
        }
        public int Delete()
        {
            return Monitoring_Seed_QuantityDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

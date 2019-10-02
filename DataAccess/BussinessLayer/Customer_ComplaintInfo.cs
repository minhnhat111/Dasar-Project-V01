using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Customer_ComplaintInfo
    {
        #region Fields
        private int _ID;
        private int _CustomerID;
        private string _Grower_Claim;
        private int _ItemID;
        private int _SupplierID;
        private string _Lot;
        private int _Certificate;
        private int _Import_Quantity;
        private int _Delivery_Quantity;
        private DateTime _Selling_Date = DataTools.Null.NullSqlDate;
        private string _ContID;
        private int _Dmg_QTY_Before;
        private int _Dmg_QTY_After;
        private DateTime _Checked_Date = DataTools.Null.NullSqlDate;
        private string _Grower_Before;
        private string _Grower_After;
        private string _Conclusion_Before;
        private string _Conclusion_After;
        private string _Technical;
        private string _Solution;
        private string _Status;
        private string _Claiming_Supplier;
        private string _Note;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string Grower_Claim
        {
            get { return _Grower_Claim; }
            set { _Grower_Claim = value; }
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
        public int Import_Quantity
        {
            get { return _Import_Quantity; }
            set { _Import_Quantity = value; }
        }
        public int Delivery_Quantity
        {
            get { return _Delivery_Quantity; }
            set { _Delivery_Quantity = value; }
        }
        public DateTime Selling_Date
        {
            get { return _Selling_Date; }
            set { _Selling_Date = value; }
        }
        public string ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
        public int Dmg_QTY_Before
        {
            get { return _Dmg_QTY_Before; }
            set { _Dmg_QTY_Before = value; }
        }
        public int Dmg_QTY_After
        {
            get { return _Dmg_QTY_After; }
            set { _Dmg_QTY_After = value; }
        }
        public DateTime Checked_Date
        {
            get { return _Checked_Date; }
            set { _Checked_Date = value; }
        }
        public string Grower_Before
        {
            get { return _Grower_Before; }
            set { _Grower_Before = value; }
        }
        public string Grower_After
        {
            get { return _Grower_After; }
            set { _Grower_After = value; }
        }
        public string Conclusion_Before
        {
            get { return _Conclusion_Before; }
            set { _Conclusion_Before = value; }
        }
        public string Conclusion_After
        {
            get { return _Conclusion_After; }
            set { _Conclusion_After = value; }
        }
        public string Technical
        {
            get { return _Technical; }
            set { _Technical = value; }
        }
        public string Solution
        {
            get { return _Solution; }
            set { _Solution = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Claiming_Supplier
        {
            get { return _Claiming_Supplier; }
            set { _Claiming_Supplier = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        #endregion

        #region Contructors
        public Customer_ComplaintInfo()
        {
        }
        public Customer_ComplaintInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Customer_ComplaintDAO.Insert(this);
        }
        public int Update()
        {
            return Customer_ComplaintDAO.Update(this);
        }
        public int Delete()
        {
            return Customer_ComplaintDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

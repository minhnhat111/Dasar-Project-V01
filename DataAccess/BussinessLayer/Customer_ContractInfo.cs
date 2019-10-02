using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Customer_ContractInfo
    {
        #region Fields
        private int _ID;
        private string _Customer_Contract;
        private DateTime _Effective_Date = DataTools.Null.NullSqlDate;
        private string _In_Charge;
        private int _CustomerID;
        private int _ItemID;
        private string _Required_Supplier;
        private int _Order_QTY_Bulbs;
        private double _Price_VND;
        private DateTime _Seeding_Date_Lunar = DataTools.Null.NullSqlDate;
        private DateTime _Seeding_Date_Gregorian = DataTools.Null.NullSqlDate;
        private DateTime _Estimated_Arrival_Date = DataTools.Null.NullSqlDate;
        private string _Note;
        private string _ContID;
        private DateTime _Date_Arrived = DataTools.Null.NullSqlDate;
        private double _Deposit;
        private DateTime _Date_1 = DataTools.Null.NullSqlDate;
        private int _Delivery_1;
        private DateTime _Date_2 = DataTools.Null.NullSqlDate;
        private int _Delivery_2;
        private DateTime _Date_3 = DataTools.Null.NullSqlDate;
        private int _Delivery_3;
        private DateTime _Date_4 = DataTools.Null.NullSqlDate;
        private int _Delivery_4;
        private DateTime _Date_5 = DataTools.Null.NullSqlDate;
        private int _Delivery_5;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Customer_Contract
        {
            get { return _Customer_Contract; }
            set { _Customer_Contract = value; }
        }
        public DateTime Effective_Date
        {
            get { return _Effective_Date; }
            set { _Effective_Date = value; }
        }
        public string In_Charge
        {
            get { return _In_Charge; }
            set { _In_Charge = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string Required_Supplier
        {
            get { return _Required_Supplier; }
            set { _Required_Supplier = value; }
        }
        public int Order_QTY_Bulbs
        {
            get { return _Order_QTY_Bulbs; }
            set { _Order_QTY_Bulbs = value; }
        }
        public double Price_VND
        {
            get { return _Price_VND; }
            set { _Price_VND = value; }
        }
        public DateTime Seeding_Date_Lunar
        {
            get { return _Seeding_Date_Lunar; }
            set { _Seeding_Date_Lunar = value; }
        }
        public DateTime Seeding_Date_Gregorian
        {
            get { return _Seeding_Date_Gregorian; }
            set { _Seeding_Date_Gregorian = value; }
        }
        public DateTime Estimated_Arrival_Date
        {
            get { return _Estimated_Arrival_Date; }
            set { _Estimated_Arrival_Date = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public string ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
        public DateTime Date_Arrived
        {
            get { return _Date_Arrived; }
            set { _Date_Arrived = value; }
        }
        public double Deposit
        {
            get { return _Deposit; }
            set { _Deposit = value; }
        }
        public DateTime Date_1
        {
            get { return _Date_1; }
            set { _Date_1 = value; }
        }
        public int Delivery_1
        {
            get { return _Delivery_1; }
            set { _Delivery_1 = value; }
        }
        public DateTime Date_2
        {
            get { return _Date_2; }
            set { _Date_2 = value; }
        }
        public int Delivery_2
        {
            get { return _Delivery_2; }
            set { _Delivery_2 = value; }
        }
        public DateTime Date_3
        {
            get { return _Date_3; }
            set { _Date_3 = value; }
        }
        public int Delivery_3
        {
            get { return _Delivery_3; }
            set { _Delivery_3 = value; }
        }
        public DateTime Date_4
        {
            get { return _Date_4; }
            set { _Date_4 = value; }
        }
        public int Delivery_4
        {
            get { return _Delivery_4; }
            set { _Delivery_4 = value; }
        }
        public DateTime Date_5
        {
            get { return _Date_5; }
            set { _Date_5 = value; }
        }
        public int Delivery_5
        {
            get { return _Delivery_5; }
            set { _Delivery_5 = value; }
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
        public Customer_ContractInfo()
        {
        }
        public Customer_ContractInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Customer_ContractDAO.Insert(this);
        }
        public int Update()
        {
            return Customer_ContractDAO.Update(this);
        }
        public int Delete()
        {
            return Customer_ContractDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

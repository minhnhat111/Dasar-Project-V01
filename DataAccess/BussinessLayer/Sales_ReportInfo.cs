using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Sales_ReportInfo
    {
        #region Fields
        private int _ID;
        private int _Year;
        private DateTime _Month = DataTools.Null.NullSqlDate;
        private DateTime _Export_Date = DataTools.Null.NullSqlDate;
        private DateTime _Date_Arrived = DataTools.Null.NullSqlDate;
        private string _Check_Date;
        private string _Export_Number;
        private string _Bill_Number;
        private int _CustomerID;
        private int _ItemID;
        private int _SupplierID;
        private string _Certificate;
        private int _Tuber_Number;
        private int _Tray_Number;
        private double _Price_VND;
        private string _Status;
        private string _Note;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public DateTime Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        public DateTime Export_Date
        {
            get { return _Export_Date; }
            set { _Export_Date = value; }
        }
        public DateTime Date_Arrived
        {
            get { return _Date_Arrived; }
            set { _Date_Arrived = value; }
        }
        public string Check_Date
        {
            get { return _Check_Date; }
            set { _Check_Date = value; }
        }
        public string Export_Number
        {
            get { return _Export_Number; }
            set { _Export_Number = value; }
        }
        public string Bill_Number
        {
            get { return _Bill_Number; }
            set { _Bill_Number = value; }
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
        public int SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        public string Certificate
        {
            get { return _Certificate; }
            set { _Certificate = value; }
        }
        public int Tuber_Number
        {
            get { return _Tuber_Number; }
            set { _Tuber_Number = value; }
        }
        public int Tray_Number
        {
            get { return _Tray_Number; }
            set { _Tray_Number = value; }
        }
        public double Price_VND
        {
            get { return _Price_VND; }
            set { _Price_VND = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
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
        public Sales_ReportInfo()
        {
        }
        public Sales_ReportInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Sales_ReportDAO.Insert(this);
        }
        public int Update()
        {
            return Sales_ReportDAO.Update(this);
        }
        public int Delete()
        {
            return Sales_ReportDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

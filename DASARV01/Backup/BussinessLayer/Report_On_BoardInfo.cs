using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Report_On_BoardInfo
    {
        #region Fields
        private int _ID;
        private int _ItemID;
        private int _SupplierID;
        private double _Price_EUR;
        private int _CustomerID;
        private int _Order_Quantity;
        private double _Unit_Price;
        private string _Delivery_Time;
        private string _Pay;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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
        public double Price_EUR
        {
            get { return _Price_EUR; }
            set { _Price_EUR = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public int Order_Quantity
        {
            get { return _Order_Quantity; }
            set { _Order_Quantity = value; }
        }
        public double Unit_Price
        {
            get { return _Unit_Price; }
            set { _Unit_Price = value; }
        }
        public string Delivery_Time
        {
            get { return _Delivery_Time; }
            set { _Delivery_Time = value; }
        }
        public string Pay
        {
            get { return _Pay; }
            set { _Pay = value; }
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
        public Report_On_BoardInfo()
        {
        }
        public Report_On_BoardInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Report_On_BoardDAO.Insert(this);
        }
        public int Update()
        {
            return Report_On_BoardDAO.Update(this);
        }
        public int Delete()
        {
            return Report_On_BoardDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

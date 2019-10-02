using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ShipmentInfo
    {
        #region Fields
        private int _ID;
        private int _Year;
        private DateTime _Month = DataTools.Null.NullSqlDate;
        private string _ContID;
        private int _ItemID;
        private int _Purchase_Quantity_Bulbs;
        private double _Price_EUR;
        private string _Lot;
        private int _Certificate;
        private string _Quality_Control_Assessment;
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
        public string Quality_Control_Assessment
        {
            get { return _Quality_Control_Assessment; }
            set { _Quality_Control_Assessment = value; }
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
        public ShipmentInfo()
        {
        }
        public ShipmentInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return ShipmentDAO.Insert(this);
        }
        public int Update()
        {
            return ShipmentDAO.Update(this);
        }
        public int Delete()
        {
            return ShipmentDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

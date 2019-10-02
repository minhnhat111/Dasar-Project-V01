using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Cooling_RequestInfo
    {
        #region Fields
        private int _ID;
        private DateTime _Request_Date = DataTools.Null.NullSqlDate;
        private int _ItemID;
        private int _CustomerID;
        private string _Requester;
        private DateTime _Delivery_Date = DataTools.Null.NullSqlDate;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public DateTime Request_Date
        {
            get { return _Request_Date; }
            set { _Request_Date = value; }
        }
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string Requester
        {
            get { return _Requester; }
            set { _Requester = value; }
        }
        public DateTime Delivery_Date
        {
            get { return _Delivery_Date; }
            set { _Delivery_Date = value; }
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
        public Cooling_RequestInfo()
        {
        }
        public Cooling_RequestInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Cooling_RequestDAO.Insert(this);
        }
        public int Update()
        {
            return Cooling_RequestDAO.Update(this);
        }
        public int Delete()
        {
            return Cooling_RequestDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

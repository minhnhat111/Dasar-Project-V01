using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Shipment_RequestInfo
    {
        #region Fields
        private int _ID;
        private int _CustomerID;
        private int _ItemID;
        private string _Reason;
        private int _InformationID;
        private int _OrderID;

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
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
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
        public Shipment_RequestInfo()
        {
        }
        public Shipment_RequestInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Shipment_RequestDAO.Insert(this);
        }
        public int Update()
        {
            return Shipment_RequestDAO.Update(this);
        }
        public int Delete()
        {
            return Shipment_RequestDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

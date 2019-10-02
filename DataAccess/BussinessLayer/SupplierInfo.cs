using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class SupplierInfo
    {
        #region Fields
        private int _ID;
        private string _SupplierCode;
        private string _SupplierName;
        private string _Nation;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        public string Nation
        {
            get { return _Nation; }
            set { _Nation = value; }
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
        public SupplierInfo()
        {
        }
        public SupplierInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return SupplierDAO.Insert(this);
        }
        public int Update()
        {
            return SupplierDAO.Update(this);
        }
        public int Delete()
        {
            return SupplierDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

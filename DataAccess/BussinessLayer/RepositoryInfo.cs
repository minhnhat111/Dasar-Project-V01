using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RepositoryInfo
    {
        #region Fields
        private int _ID;
        private string _Repo_Name;
        private string _Location;
        private int _PalletID;
        private int _ItemID;
        private string _ContID;
        private int _CustomerID;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Repo_Name
        {
            get { return _Repo_Name; }
            set { _Repo_Name = value; }
        }
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public int PalletID
        {
            get { return _PalletID; }
            set { _PalletID = value; }
        }
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
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
        public RepositoryInfo()
        {
        }
        public RepositoryInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return RepositoryDAO.Insert(this);
        }
        public int Update()
        {
            return RepositoryDAO.Update(this);
        }
        public int Delete()
        {
            return RepositoryDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

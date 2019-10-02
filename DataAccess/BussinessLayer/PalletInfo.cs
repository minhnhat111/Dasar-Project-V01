using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class PalletInfo
    {
        #region Fields
        private int _ID;
        private string _Pallet;
        private int _Tray_Number;
        private int _ReposityID;
        private string _ContID;
        private string _Empty_Pallet;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Pallet
        {
            get { return _Pallet; }
            set { _Pallet = value; }
        }
        public int Tray_Number
        {
            get { return _Tray_Number; }
            set { _Tray_Number = value; }
        }
        public int ReposityID
        {
            get { return _ReposityID; }
            set { _ReposityID = value; }
        }
        public string ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
        public string Empty_Pallet
        {
            get { return _Empty_Pallet; }
            set { _Empty_Pallet = value; }
        }

        #endregion

        #region Contructors
        public PalletInfo()
        {
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return PalletDAO.Insert(this);
        }
        public int Update()
        {
            return PalletDAO.Update(this);
        }
        public int Delete()
        {
            return PalletDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

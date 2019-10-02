using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RoleAccountInfo
    {
        #region Fields
        private int _RoleID;
        private int _AccountID;
        private int _Active;

        #endregion

        #region Properties
        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }
        public int Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        #endregion

        #region Contructors
        public RoleAccountInfo()
        {
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return RoleAccountDAO.Insert(this);
        }
        public int Update()
        {
            return RoleAccountDAO.Update(this);
        }
        public int Delete()
        {
            return RoleAccountDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public AccountInfo GetAccountOwner()
        {
            return AccountDAO.Find(this.AccountID);
        }

        public RoleInfo GetRoleOwner()
        {
            return RoleDAO.Find(this.RoleID);
        }

        #endregion
      
        #endregion
    }
}

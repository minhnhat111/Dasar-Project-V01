using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class RoleInfo
    {
        #region Fields
        private int _ID;
        private string _RoleName;
        private string _Functions;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        public string Functions
        {
            get { return _Functions; }
            set { _Functions = value; }
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
        public RoleInfo()
        {
        }
        public RoleInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return RoleDAO.Insert(this);
        }
        public int Update()
        {
            return RoleDAO.Update(this);
        }
        public int Delete()
        {
            return RoleDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<RoleAccountInfo> GetRoleAccount()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableRoleAccount.RoleID, EqualityOperator.Equal, this.ID)
            };
            return RoleAccountDAO.GetTop(filters, null, -1);
        }

        public InformationInfo GetInformationOwner()
        {
            return InformationDAO.Find(this.InformationID);
        }

        #endregion
      
        #endregion
    }
}

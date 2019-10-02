using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class InformationInfo
    {
        #region Fields
        private int _ID;
        private string _NameInfor;
        private DateTime _DateCreated = DataTools.Null.NullSqlDate;
        private string _CreatedBy;
        private DateTime _DateModified = DataTools.Null.NullSqlDate;
        private string _ModifiedBy;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string NameInfor
        {
            get { return _NameInfor; }
            set { _NameInfor = value; }
        }
        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public DateTime DateModified
        {
            get { return _DateModified; }
            set { _DateModified = value; }
        }
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        #endregion

        #region Contructors
        public InformationInfo()
        {
        }
        public InformationInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return InformationDAO.Insert(this);
        }
        public int Update()
        {
            return InformationDAO.Update(this);
        }
        public int Delete()
        {
            return InformationDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<RoleInfo> GetRole()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableRole.InformationID, EqualityOperator.Equal, this.ID)
            };
            return RoleDAO.GetTop(filters, null, -1);
        }

        public List<AccountInfo> GetAccount()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableAccount.InformationID, EqualityOperator.Equal, this.ID)
            };
            return AccountDAO.GetTop(filters, null, -1);
        }

        #endregion
      
        #endregion
    }
}

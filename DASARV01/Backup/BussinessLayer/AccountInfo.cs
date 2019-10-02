using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class AccountInfo
    {
        #region Fields
        private int _ID;
        private string _AccountName;
        private string _Password;
        private string _FirstName;
        private string _LastName;
        private string _IdentifyID;
        private string _Email;
        private string _Phone;
        private string _Mobile;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string IdentifyID
        {
            get { return _IdentifyID; }
            set { _IdentifyID = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
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
        public AccountInfo()
        {
        }
        public AccountInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return AccountDAO.Insert(this);
        }
        public int Update()
        {
            return AccountDAO.Update(this);
        }
        public int Delete()
        {
            return AccountDAO.Delete(this);
        }
        #endregion

        #region GetByFK
        public List<RoleAccountInfo> GetRoleAccount()
        {
            FilterObject[] filters = new FilterObject[] {
            	new FilterObject(TableRoleAccount.AccountID, EqualityOperator.Equal, this.ID)
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

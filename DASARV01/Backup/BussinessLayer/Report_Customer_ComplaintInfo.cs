using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class Report_Customer_ComplaintInfo
    {
        #region Fields
        private int _ID;
        private string _Technical_staff;
        private string _Customer_A_Quantity;
        private string _Customer_A_Times;
        private string _Customer_B_Quantity;
        private string _Customer_B_Times;
        private string _Customer_C_Quantity;
        private string _Customer_C_Times;
        private string _Customer_D_Quantity;
        private string _Customer_D_Times;
        private string _Result;
        private int _InformationID;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Technical_staff
        {
            get { return _Technical_staff; }
            set { _Technical_staff = value; }
        }
        public string Customer_A_Quantity
        {
            get { return _Customer_A_Quantity; }
            set { _Customer_A_Quantity = value; }
        }
        public string Customer_A_Times
        {
            get { return _Customer_A_Times; }
            set { _Customer_A_Times = value; }
        }
        public string Customer_B_Quantity
        {
            get { return _Customer_B_Quantity; }
            set { _Customer_B_Quantity = value; }
        }
        public string Customer_B_Times
        {
            get { return _Customer_B_Times; }
            set { _Customer_B_Times = value; }
        }
        public string Customer_C_Quantity
        {
            get { return _Customer_C_Quantity; }
            set { _Customer_C_Quantity = value; }
        }
        public string Customer_C_Times
        {
            get { return _Customer_C_Times; }
            set { _Customer_C_Times = value; }
        }
        public string Customer_D_Quantity
        {
            get { return _Customer_D_Quantity; }
            set { _Customer_D_Quantity = value; }
        }
        public string Customer_D_Times
        {
            get { return _Customer_D_Times; }
            set { _Customer_D_Times = value; }
        }
        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
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
        public Report_Customer_ComplaintInfo()
        {
        }
        public Report_Customer_ComplaintInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return Report_Customer_ComplaintsDAO.Insert(this);
        }
        public int Update()
        {
            return Report_Customer_ComplaintsDAO.Update(this);
        }
        public int Delete()
        {
            return Report_Customer_ComplaintsDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

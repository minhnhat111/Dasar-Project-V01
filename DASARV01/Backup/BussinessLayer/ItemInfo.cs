using System;
using System.Collections.Generic;
using DataTools.PagingUtils;

namespace DataAccess
{
    public class ItemInfo
    {
        #region Fields
        private int _ID;
        private string _ItemID;
        private string _ItemName;
        private string _Type;
        private string _Size;
        private int _ItemsPerPack;
        private string _Crop;
        private string _Note;
        private int _Information;
        private int _OrderID;

        #endregion

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        public int ItemsPerPack
        {
            get { return _ItemsPerPack; }
            set { _ItemsPerPack = value; }
        }
        public string Crop
        {
            get { return _Crop; }
            set { _Crop = value; }
        }
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        public int Information
        {
            get { return _Information; }
            set { _Information = value; }
        }
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        #endregion

        #region Contructors
        public ItemInfo()
        {
        }
        public ItemInfo(int iD)
        {
            _ID = iD;
        }

        #endregion

        #region Methods
        #region InsertUpdateDelete
        public int Insert()
        {
            return ItemDAO.Insert(this);
        }
        public int Update()
        {
            return ItemDAO.Update(this);
        }
        public int Delete()
        {
            return ItemDAO.Delete(this);
        }
        #endregion

      
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
   public class DataAttr:Attribute
    {
        private bool bquery;
        public bool Bquery
        {
            get { return bquery; }
            set { bquery = value; }
        }
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        private bool key;
        public bool Key
        {
            get { return key; }
            set { key = value; }
        }
        public DataAttr()
        {

        }
        public DataAttr(string tableName)
        {
            this.tableName = tableName;
        }
        public DataAttr(bool bquery)
        {
            this.bquery = bquery;
        }
        public DataAttr(bool bquery,bool key)
        {
            this.bquery = bquery;
            this.key = key;
        }
    }
}

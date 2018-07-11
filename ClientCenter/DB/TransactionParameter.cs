using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ClientCenter.DB
{
    public class TransactionParameter
    {
        private string sqlString;
        public string SqlString
        {
            get { return sqlString; }
            set { sqlString = value; }
        }
        private List<MySqlParameter> sqlParameter;
        public List<MySqlParameter> SqlParameters
        {
            get { return sqlParameter; }
            set { sqlParameter = value; }
        }
    }
}

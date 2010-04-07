using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace Trillium_CC_Allocation
{
    class CSVReader
    {

        static public DataSet Read(string filePath, string fileName, string newDSName, string newTableName)
        {
            //TODO: Filter for invalid filepath and filename?
            // Driver={Microsoft Text Driver (*.txt; *.csv)}
            string ConnectionString = null;

            ConnectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=" + filePath;
            fileName = "`" + fileName + "`";
            
            OdbcConnection connection = new OdbcConnection(ConnectionString);
            connection.Open();  //TODO: necessary?
            OdbcDataAdapter da;

            da = new OdbcDataAdapter("Select * FROM " + fileName, connection);
            
            DataSet ds = new DataSet(newDSName);       
            da.FillSchema(ds, SchemaType.Source, newTableName);
            da.Fill(ds, newTableName);

            return ds;

        }

    }
}

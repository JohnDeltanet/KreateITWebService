using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class RegionDAL
    {
        public static DataSet ListRegions()
        {
            return DAL.GetDataset("SELECT * FROM GR_Regions");
        }

        public static DataSet GetDetails(int RegionID)
        {
            return DAL.GetDataset("SELECT * FROM GR_Regions WHERE GRR_ID = @RegionID", new SQLArg("@RegionID", RegionID));
        }

        public static int Create(string RegionCode, string RegionName)
        {
            string SQLString = "INSERT INTO GR_Regions (GRR_ID, GRR_CODE, GRR_NAME, GRR_STATUS) " +
                                "OUTPUT Inserted.GRR_ID " +
                                "SELECT " +
                                "(SELECT MIN(Number) " +
                                "FROM Numbers n " +
                                "LEFT JOIN GR_Regions r " +
                                "   ON R.GRR_ID = N.Number " +
                                "WHERE R.GRR_ID IS Null " +
                                "AND N.Number > 0), @RegionCode, @RegionName, 'v'";
            return DAL.GetDataInt(SQLString, new SQLArg("@RegionCode", RegionCode), new SQLArg("@RegionName", RegionName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class EntityDAL
    {
        public static DataSet ListRegions()
        {
            return DAL.GetDataset("SELECT * FROM GR_Entities");
        }

        public static DataSet GetDetails(int EntityID)
        {
            return DAL.GetDataset("SELECT * FROM GR_Entities WHERE GRE_ID = @EntityID", new SQLArg("@EntityID", EntityID));
        }

        public static int Create(int RegionID, string EntityCode, string EntityName)
        {
            string SQLString = "INSERT INTO GR_Entities (GRE_ID, GRE_GRR_ID, GRE_CODE, GRE_NAME, GRE_APPROVAL_LEVEL_PO, GRE_PREAPPROVAL_LEVEL_PO, " +
                                "                       GRE_APPROVAL_LEVEL_NON_PO, GRE_PREAPPROVAL_LEVEL_NON_PO, GRE_STATUS) " +
                                "OUTPUT Inserted.GRE_ID " +
                                "SELECT " +
                                "(SELECT MIN(Number) " +
                                "FROM Numbers n " +
                                "LEFT JOIN GR_Entities e " +
                                "   ON e.GRE_ID = N.Number " +
                                "WHERE E.GRE_ID IS Null " +
                                "AND N.Number > 0), @RegionID, @EntityCode, @EntityName, 0, 0, 0, 0, 'v'";
            return DAL.GetDataInt(SQLString, new SQLArg("@RegionID", RegionID), new SQLArg("@EntityCode", EntityCode), new SQLArg("@EntityName", EntityName));
        }
    }
}

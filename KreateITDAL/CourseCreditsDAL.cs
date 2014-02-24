using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class CourseCreditsDAL
    {
        public static DataSet List()
        {
            return DAL.GetDataset("SELECT * FROM Course_Credits");
        }

        public static DataSet GetDetails(int CourseCreditID)
        {
            return DAL.GetDataset("SELECT * FROM Course_Credits WHERE CC_ID = @CourseCreditID", new SQLArg("@CourseCreditID", CourseCreditID));
        }

        public static DataSet GetDetails(string Key)
        {
            return DAL.GetDataset("SELECT * FROM Course_Credits WHERE CC_COURSE_CREDIT_KEY = @Key", new SQLArg("@Key", Key));
        }

        public static int IncrementUsedCredits(int CourseCreditID)
        {
            return DAL.GetDataInt("UPDATE Course_Credits SET CC_Used_Credits = CC_Used_Credits + 1 OUTPUT Inserted.CC_ID WHERE CC_ID = @CourseCreditID", new SQLArg("@CourseCreditID", CourseCreditID));
        }

        public static int Save(int EventID, int AdminID, string CreditKey, string Reference, int TotalCredits)
        {
            string SQLString = "INSERT INTO Course_Credits " +
                                "(CC_CREATE_DT, CC_CREATE_ADMIN_U_ID, CC_COURSE_CREDIT_KEY, CC_CO_ID, CC_EV_ID, CC_REF, CC_TOTAL_CREDITS, CC_USED_CREDITS, CC_STATUS) " +
                                "OUTPUT Inserted.CC_ID " + 
                                "SELECT CURRENT_TIMESTAMP, @AdminID, @CreditKey, EV_CO_ID, EV_ID, @Ref, @TotalCredits, 0, 'v' " +
                                "FROM Events " +
                                "WHERE EV_ID = @EventID ";
            List<SQLArg> args = new List<SQLArg>();
            args.Add(new SQLArg("@EventID", EventID));
            args.Add(new SQLArg("@AdminID", AdminID));
            args.Add(new SQLArg("@CreditKey", CreditKey));
            args.Add(new SQLArg("@Ref", Reference));
            args.Add(new SQLArg("@TotalCredits", TotalCredits));
            return DAL.GetDataInt(SQLString, args);
        }
    }
}

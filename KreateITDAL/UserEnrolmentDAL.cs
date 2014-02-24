using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class UserEnrolmentDAL
    {
        public static DataSet List()
        {
            return DAL.GetDataset("SELECT * FROM User_Enrollment ORDER BY UEN_ID, UEN_EV_ID");
        }

        public static DataSet GetDetails(int EnrolmentID)
        {
            return DAL.GetDataset("SELECT * FROM User_Enrollment WHERE UEN_ID = @EnrolmentID", new SQLArg("@EnrolmentID", EnrolmentID));
        }

        public static DataSet GetDetails(int UserID, int EventID)
        {
            return DAL.GetDataset("SELECT * FROM User_Enrollment WHERE UEN_U_ID = @UserID AND UEN_EV_ID = @EventID", new SQLArg("@UserID", UserID), new SQLArg("@EventID", EventID));
        }

        public static int Save(int UserID, int EventID, int AdminUserID, string Type, string Status, int CourseCreditID)
        {
            int EnrolmentID = 0;
            List<SQLArg> Args = new List<SQLArg>();
            Args.Add(new SQLArg("@UserID", UserID));
            Args.Add(new SQLArg("@EventID", EventID));

            EnrolmentID = DAL.GetDataInt("SELECT UEN_U_ID FROM User_Enrollment WHERE UEN_U_ID = @UserID AND UEN_EV_ID = @EventID", Args);
            if (EnrolmentID == 0)
            {
                Args.Add(new SQLArg("@AdminUserID", AdminUserID));
                Args.Add(new SQLArg("@Type", Type));
                Args.Add(new SQLArg("@Status", Status));
                if (Type == "s")
                { Args.Add(new SQLArg("@CourseCreditID", CourseCreditID)); } else { Args.Add(new SQLArg("@CourseCreditID", null)); }
                string SQLString = "INSERT INTO User_Enrollment (UEN_U_ID, UEN_CO_ID, UEN_EV_ID, UEN_CREATED_DT, UEN_ADMIN_U_ID, UEN_TYPE, UEN_STATUS, UEN_CC_ID) " +
                                    "OUTPUT inserted.UEN_ID " + 
                                    "SELECT @UserID, EV_CO_ID, EV_ID, CURRENT_TIMESTAMP, @AdminUserID, @Type, @Status, @CourseCreditID " +
                                    "FROM Events " +
                                    "WHERE EV_ID = @EventID ";
                EnrolmentID = DAL.GetDataInt(SQLString, Args);
            }
            return EnrolmentID;
        }
    }
}

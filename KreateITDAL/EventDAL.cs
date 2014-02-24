using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class EventDAL
    {
        public static DataSet ListEvents()
        {
            return DAL.GetDataset("SELECT * FROM Events");
        }

        public static DataSet GetDetails(int EventID)
        {
            return DAL.GetDataset("SELECT * FROM Events WHERE EV_ID = @EventID", new SQLArg("@EventID", EventID));
        }

        public static int Create(string Name, int CourseID, DateTime? StartDate, DateTime? EndDate)
        {
            string SQLString = "INSERT INTO Events (EV_Name, EV_CO_ID, EV_Start_Dt, EV_End_Dt, EV_Catalogue, EV_Self_Enrol, " +
                                "EV_Group_Only, EV_Enrol_Request, EV_Taster, EV_Key, EV_Workflow, EV_Status, EV_Auto_Enrol) " +
                                "OUTPUT Inserted.EV_ID " +
                                "SELECT @Name, @CourseID, @StartDate, @EndDate, @ShowInCatalogue, @SelfEnrol, " +
                                "@GroupOnly, @EnrolRequest, @Taster, @Key, @Workflow, @Status, @AutoEnrol";
            List<SQLArg> args = new List<SQLArg>();
            args.Add(new SQLArg("@Name", Name));
            args.Add(new SQLArg("@CourseID", CourseID));
            args.Add(new SQLArg("@StartDate", StartDate));
            args.Add(new SQLArg("@EndDate", EndDate));
            args.Add(new SQLArg("@ShowInCatalogue", "y"));
            args.Add(new SQLArg("@SelfEnrol", "n"));
            args.Add(new SQLArg("@GroupOnly", "n"));
            args.Add(new SQLArg("@EnrolRequest", "n"));
            args.Add(new SQLArg("@Taster", "n"));
            args.Add(new SQLArg("@Key", DateTime.Now.ToString("MdHms") + (new Random()).Next(1, 10000).ToString()));
            args.Add(new SQLArg("@Workflow", "p"));
            args.Add(new SQLArg("@Status", "v"));
            args.Add(new SQLArg("@AutoEnrol", "n"));
            return DAL.GetDataInt(SQLString, args);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class CourseDAL
    {
        public static DataSet GetDetails(int CourseID)
        {
            return DAL.GetDataset("SELECT * FROM Courses WHERE CO_ID = @CourseID", new SQLArg("@CourseID", CourseID));
        }

        public static DataSet Search(string SearchString)
        {
            //string SQLString = "SELECT CS.CS_SUB_NAME, E.EV_ID, E.EV_NAME, C.* " +
            //                    "FROM CAT_SUBJECTS CS " +
            //                    "INNER JOIN COURSES C " +
            //                    "   ON C.CO_CS_ID = CS.CS_ID " +
            //                    "INNER JOIN EVENTS E " +
            //                    "   ON E.EV_CO_ID = C.CO_ID " +
            //                    "WHERE ISNULL(E.EV_END_DT, '29990101') >= CURRENT_TIMESTAMP " +
            //                    "AND E.EV_STATUS = 'v' " +
            //                    "AND C.CO_STATUS = 'v' " +
            //                    "AND C.CO_WORKFLOW = 'p' " +
            //                    "AND E.EV_WORKFLOW <> 'd' " +
            //                    "AND ISNULL(E.EV_ENROLMENT_LOCKED, 'n') <> 'y' " +
            //                    "AND E.EV_CATALOGUE IN ('y', 'r') " +
            //                    "AND " + 
            //                    "(" +
            //                    "   CS.CS_SUB_NAME like '%' + @SearchString + '%' " +
            //                    "   OR C.CO_Title like '%' + @SearchString + '%' " +
            //                    "   OR C.CO_Desc like '%' + @SearchString + '%' " +
            //                    "   OR E.EV_Name like '%' + @SearchString + '%' " +
            //                    ") " + 
            //                    "ORDER BY CS.CS_SUB_NAME, E.EV_NAME, C.CO_TITLE";
            string SQLString = "SELECT * FROM Courses " +
                                "WHERE CO_Title like '%' + @SearchString + '%' " +
                                "OR CO_Desc like '%' + @SearchString + '%' ";
            return DAL.GetDataset(SQLString, new SQLArg("@SearchString", SearchString));
        }
    }

    public class SubjectDAL
    {
        public static DataSet GetDetails(int SubjectID)
        {
            return DAL.GetDataset("SELECT * FROM Cat_Subjects WHERE CS_ID = @SubjectID", new SQLArg("@SubjectID", SubjectID));
        }

        public static DataSet List()
        {
            return DAL.GetDataset("SELECT * FROM Cat_Subjects");
        }
    }
}

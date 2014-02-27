using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;

namespace KreateIT.Business
{
    public class RegionBLL
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public static implicit operator RegionBLL(DataRow dr)
        {
            return new RegionBLL
            {
                ID = dr.Table.Columns.Contains("GRR_ID") ? (dr.Field<int?>("GRR_ID") ?? 0) : 0,
                Code = dr.Table.Columns.Contains("GRR_CODE") ? (dr.Field<string>("GRR_CODE") ?? "") : "",
                Name = dr.Table.Columns.Contains("GRR_NAME") ? (dr.Field<string>("GRR_NAME") ?? "") : "",
                Status = dr.Table.Columns.Contains("GRR_STATUS") ? (dr.Field<string>("GRR_STATUS") ?? "") : ""
            };
        }

        public static List<RegionBLL> ListRegions()
        {
            return RegionDAL.ListRegions().Tables[0].AsEnumerable().Select(r => (RegionBLL)r).ToList();
        }

        public static int Create(string RegionCode, string RegionName)
        {
            return RegionDAL.Create(RegionCode, RegionName);
        }

        public static RegionBLL GetDetails(int RegionID)
        {
            RegionBLL r = new RegionBLL();
            DataTable dt = RegionDAL.GetDetails(RegionID).Tables[0];
            if (dt.Rows.Count > 0) { r = (RegionBLL)dt.Rows[0]; }
            return r;
        }
    }
}

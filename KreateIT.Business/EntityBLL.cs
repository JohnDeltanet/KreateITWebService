using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;

namespace KreateIT.Business
{
    public class EntityBLL
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int RegionID { get; set; }
        public RegionBLL Region { get { return RegionBLL.GetDetails(RegionID); } }
        public string Status { get; set; }

        public static implicit operator EntityBLL(DataRow dr)
        {
            return new EntityBLL
            {
                ID = dr.Table.Columns.Contains("GRE_ID") ? (dr.Field<int?>("GRE_ID") ?? 0) : 0,
                Code = dr.Table.Columns.Contains("GRE_CODE") ? (dr.Field<string>("GRE_CODE") ?? "") : "",
                Name = dr.Table.Columns.Contains("GRE_NAME") ? (dr.Field<string>("GRE_NAME") ?? "") : "",
                RegionID = dr.Table.Columns.Contains("GRE_GRR_ID") ? (dr.Field<int?>("GRE_GRR_ID") ?? 0) : 0,
                Status = dr.Table.Columns.Contains("GRE_STATUS") ? (dr.Field<string>("GRE_STATUS") ?? "") : ""
            };
        }

        public static List<EntityBLL> ListEntities()
        {
            return EntityDAL.ListRegions().Tables[0].AsEnumerable().Select(r => (EntityBLL)r).ToList();
        }

        public static int Create(int RegionID, string EntityCode, string EntityName)
        {
            return EntityDAL.Create(RegionID, EntityCode, EntityName);
        }

        public static EntityBLL GetDetails(int EntityID)
        {
            EntityBLL e = new EntityBLL();
            DataTable dt = EntityDAL.GetDetails(EntityID).Tables[0];
            if (dt.Rows.Count > 0)
            { e = (EntityBLL)dt.Rows[0]; }
            return e;
        }
    }
}

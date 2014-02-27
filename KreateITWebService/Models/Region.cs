using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class RegionDisplay
    {
        /// <summary>
        /// Unique ID for the region
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Short code for the region
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the region
        /// </summary>
        public string Name { get; set; }

        public static implicit operator RegionDisplay(RegionBLL r)
        {
            return new RegionDisplay { ID = r.ID, Code = r.Code, Name = r.Name };
        }

        public static List<RegionDisplay> List()
        {
            return RegionBLL.ListRegions().Select(r => (RegionDisplay)r).ToList();
        }

        public static RegionDisplay GetDetails(int RegionID)
        {
            return (RegionDisplay)(RegionBLL.GetDetails(RegionID));
        }
    }

    public class RegionData
    {
        /// <summary>
        /// Short code for the region (optional)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the region
        /// </summary>
        public string Name { get; set; }

        public int Create()
        {
            return RegionBLL.Create(Code, Name);
        }
    }
}
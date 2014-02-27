using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class EntityDisplay
    {
        /// <summary>
        /// Unique ID for the entity
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Unique ID for the entity
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Short code for entity
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ID of region to which this entity belongs
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// Name of the region to which this entity relates
        /// </summary>
        public string RegionName { get; set; }

        public static implicit operator EntityDisplay(EntityBLL e)
        {
            return new EntityDisplay { ID = e.ID, Code = e.Code, Name = e.Name, RegionID = e.RegionID, RegionName = e.Region.Name };
        }

        public static List<EntityDisplay> List()
        {
            return EntityBLL.ListEntities().Select(e => (EntityDisplay)e).ToList();
        }

        public static EntityDisplay GetDetails(int EntityID)
        {
            return (EntityDisplay)(EntityBLL.GetDetails(EntityID));
        }
    }

    public class EntityData
    {
        /// <summary>
        /// ID number of the region to which this entity relates
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// Short code for entity (optional)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name of the entity
        /// </summary>
        public string Name { get; set; }

        public int Create()
        {
            return EntityBLL.Create(RegionID, Code, Name);
        }
    }
}
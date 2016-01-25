﻿using System;
using System.Runtime.Serialization;

namespace ReportMS.DataTransferObjects.Dtos
{
    /// <summary>
    /// 菜单角色 Dto
    /// </summary>
    [DataContract]
    public class MenuRoleDto
    {
        /// <summary>
        /// 获取或设置 Id
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// 获取或设置菜单 ID
        /// </summary>
        [DataMember]
        public Guid MenuId { get; set; }

        /// <summary>
        /// 获取或设置角色 ID
        /// </summary>
        [DataMember]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 获取或设置创建人
        /// </summary>
        [DataMember]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreatedDate { get; set; }
    }
}

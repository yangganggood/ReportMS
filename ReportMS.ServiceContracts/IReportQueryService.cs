﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using Gear.Infrastructure;
using Gear.Infrastructure.Services.ApplicationServices;
using ReportMS.DataTransferObjects;
using ReportMS.DataTransferObjects.Dtos;

namespace ReportMS.ServiceContracts
{
    /// <summary>
    /// 表示实现此接口类为 Report 查询类。
    /// 查询报表及字段，也可以根据角色来查询报表及其限制的字段
    /// </summary>
    [ServiceContract]
    public interface IReportQueryService : IApplicationQueryService
    {
        /// <summary>
        /// 获取所有的报表数据, 不包含字段
        /// </summary>
        /// <returns>报表数据集合</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IEnumerable<ReportDto> GetReports();

        /// <summary>
        /// 获取指定的角色所拥有的所有报表，不包含字段.
        /// </summary>
        /// <param name="roleId">指定的角色 Id</param>
        /// <returns>报表数据集合</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IEnumerable<ReportDto> GetReports(Guid roleId);

        /// <summary>
        /// 获取指定的角色所拥有的所有报表配置，不包含字段。
        /// </summary>
        /// <param name="roleId">指定的角色 Id</param>
        /// <returns>报表配置集合</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IEnumerable<ReportProfileDto> GetReportProfiles(Guid roleId);

        /// <summary>
        /// 获取报表数据。
        /// 用户名和密码已解密
        /// </summary>
        /// <param name="reportId">报表 Id</param>
        /// <param name="includeFields">是否包含关联项（Field），默认包含</param>
        /// <returns>报表</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ReportDto GetReport(Guid reportId, bool includeFields = true);

        /// <summary>
        /// 获取配置了的报表的信息。
        /// 不同的配置信息呈现的字段不同。
        /// 用户名和密码已解密
        /// </summary>
        /// <param name="reportProfileId">报表配置 Id</param>
        /// <returns>报表 Dto 对象，包含字段</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ReportDto GetReportWithProfile(Guid reportProfileId);
    }
}

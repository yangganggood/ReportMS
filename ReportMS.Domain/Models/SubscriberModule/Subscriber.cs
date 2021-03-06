﻿using System;
using Gear.Infrastructure;

namespace ReportMS.Domain.Models.SubscriberModule
{
    /// <summary>
    /// 订阅用户
    /// </summary>
    public class Subscriber : Entity
    {
        #region Properties

        /// <summary>
        /// 获取主题 Id
        /// </summary>
        public Guid TopicId { get; private set; }

        /// <summary>
        /// 获取主题
        /// </summary>
        public virtual Topic Topic { get; private set; }

        /// <summary>
        /// 获取订阅者邮件
        /// </summary>
        public string Email { get; private set; }

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<c>Subscriber</c>实例。仅供 EntityFramework 调用
        /// </summary>
        public Subscriber()
        {
        }

        /// <summary>
        /// 初始化一个新的<c>Subscriber</c>实例
        /// </summary>
        /// <param name="topicId">主题 Id</param>
        /// <param name="email">订阅者邮件</param>
        public Subscriber(Guid topicId, string email)
        {
            TopicId = topicId;
            Email = email;

            this.GenerateNewIdentity();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 附加到父节点（主题）
        /// </summary>
        /// <param name="parentId">要附加的父节点（主题）</param>
        public void AttachToParent(Guid parentId)
        {
            this.TopicId = parentId;
        }

        #endregion
    }
}

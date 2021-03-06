﻿using System;

namespace Gear.Infrastructure.Storage
{
    /// <summary>
    /// 存储异常
    /// </summary>
    [Serializable]
    public class StorageException : InfrastructureException
    {
         /// <summary>
        /// 初始化 <c>StorageException</c> 实例
        /// </summary>
        public StorageException()
        { }

        /// <summary>
        /// 初始化 <c>StorageException</c> 实例
        /// </summary>
        /// <param name="message">异常消息</param>
        public StorageException(string message) : base(message)
        { }

        /// <summary>
        /// 初始化 <c>StorageException</c> 实例
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="innerException">引起的内部异常</param>
        public StorageException(string message, Exception innerException) : base(message, innerException)
        { }

        /// <summary>
        /// 初始化 <c>StorageException</c> 实例
        /// </summary>
        /// <param name="format">异常消息格式</param>
        /// <param name="args">异常消息集合</param>
        public StorageException(string format, params object[] args)
            : base(String.Format(format, args))
        { }
    }
}

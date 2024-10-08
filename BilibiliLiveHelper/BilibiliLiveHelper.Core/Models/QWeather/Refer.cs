﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.QWeather
{
    /// <summary>
    /// 数据来源信息
    /// </summary>
    public class Refer
    {
        public Refer() { }

        /// <summary>
        /// 原始数据来源，或数据源说明，可能为空
        /// </summary>
        public string[] sources { get; set; }
        /// <summary>
        /// 数据许可或版权声明，可能为空
        /// </summary>
        public string[] license { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Model
{
    /// <summary>
    /// 客户状态
    /// </summary>
    public class CustomerState:EntityBase
    {
        public string  StatusStr { get; set; }

        public int DefaultSort { get; set; }

        public string Status { get; set; }
    }
}
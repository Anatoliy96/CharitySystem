﻿using AidSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharitySystemBLL.BLL.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public int MemberCount { get; set; }
        public int ActivityCount { get; set; }
    }
}

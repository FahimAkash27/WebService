﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public interface IServiceBookIssue
    {
        void IssueBook(string[] values);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    public interface IGetFromWebservice
    {
        string GetMethod(string url, string value);
    }
}

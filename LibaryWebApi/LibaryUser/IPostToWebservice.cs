using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    public interface IPostToWebservice
    {
        void PostMethod(string[] values, string url);
    }
}

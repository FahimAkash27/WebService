using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    public interface IPutToWebservice
    {
        void PutMethod(string[] values, string url);
    }
}

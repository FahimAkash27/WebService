using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public interface IServiceFine
    {
        double ShowFine(int id);

        void GiveFine(string[] values);
    }
}

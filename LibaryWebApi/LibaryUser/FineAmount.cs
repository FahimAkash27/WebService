using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    class FineAmount : IFineAmount
    {
        private const string showFineUrl = "https://localhost:44327/api/fine/GetFineAmount";

        private const string giveFineUrl = "https://localhost:44327/api/fine/PutGiveFine";

        private IGetFromWebservice _getFromWebservice;
        private IPutToWebservice _putToWebservice;

        public FineAmount(IGetFromWebservice getFromWebservice, IPutToWebservice putToWebservice)
        {
            _getFromWebservice = getFromWebservice;
            _putToWebservice = putToWebservice;
        }

        public void ShowFineAmount()
        {
            string value;
            Console.Write("Please enter student Id: ");
            value = Console.ReadLine();

            string fine =  _getFromWebservice.GetMethod(showFineUrl, value);

            Console.WriteLine(fine);
            
        }

        public void GiveFine()
        {
            string[] values = new string[2];

            Console.Write("Please enter student Id: ");
            values[0] = Console.ReadLine();

            Console.Write("Please enter fine amount you want to give: ");
            values[1] = Console.ReadLine();

            _putToWebservice.PutMethod(values, giveFineUrl);


        }
    }
}

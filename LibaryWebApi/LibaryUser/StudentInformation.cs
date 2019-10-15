using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    class StudentInformation : IStudentInformation
    {   
        private const string url = "https://localhost:44327/api/student/poststudent";

        private IPostToWebservice _postToWebservice;

        public StudentInformation(IPostToWebservice postToWebservice)
        {
            _postToWebservice = postToWebservice;
        }

        public void InssertStudent()
        {
            string[] values = new string[2];
            Console.Write("Please enter student ID: ");
            values[0] = Console.ReadLine();
            Console.Write("Please enter student NAME: ");
            values[1] = Console.ReadLine();

            _postToWebservice.PostMethod(values, url);

            
        }
    }
}

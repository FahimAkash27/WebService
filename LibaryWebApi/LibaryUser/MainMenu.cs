using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    class MainMenu : IMainMenu
    {
        private IStudentInformation _studentInformation;
        private IBookInformation _bookInformation;
        private IIssueBook _issueBook;
        private IFineAmount _fineAmount;

        public  MainMenu(IStudentInformation studentInformation, IBookInformation bookInformation, IIssueBook issueBook, IFineAmount fineAmount)
        {
            _studentInformation = studentInformation;
            _bookInformation = bookInformation;
            _issueBook = issueBook;
            _fineAmount = fineAmount;
        }
        public void OpeningScreen()
        {
            Console.WriteLine("Welcome to library system.");
            Console.WriteLine("Please enter your choice:");
            Console.WriteLine("To entry student information enter: 1");
            Console.WriteLine("To entry book information enter: 2");
            Console.WriteLine("To issue a book, enter: 3");
            Console.WriteLine("To return a book enter: 4");
            Console.WriteLine("To check fine, enter: 5");
            Console.WriteLine("To receive fine, enter: 6");
            Console.WriteLine("To exit, enter: 7");

            Console.Write("Enter : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        _studentInformation.InssertStudent();
                        //UserInterface(context);
                        break;
                    case 2:
                        _bookInformation.InsertBook();
                        //UserInterface(context);
                        break;
                    case 3:
                        _issueBook.BookIssue();
                        //UserInterface(context);
                        break;
                    case 4:
                        _issueBook.ReturnBook();
                        //UserInterface(context);
                        break;
                    case 5:
                        _fineAmount.ShowFineAmount();
                        //UserInterface(context);
                        break;
                    case 6:
                        _fineAmount.GiveFine();
                        //UserInterface(context);
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;

                }
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to library system.");
                Console.WriteLine("Please enter your choice:");
                Console.WriteLine("To entry student information enter: 1");
                Console.WriteLine("To entry book information enter: 2");
                Console.WriteLine("To issue a book, enter: 3");
                Console.WriteLine("To return a book enter: 4");
                Console.WriteLine("To check fine, enter: 5");
                Console.WriteLine("To receive fine, enter: 6");
                Console.WriteLine("To exit, enter: 7");

                Console.Write("Enter : ");
                choice = Convert.ToInt32(Console.ReadLine());


            }
        }
    }
}

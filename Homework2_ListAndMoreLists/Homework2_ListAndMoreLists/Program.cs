using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2_ListAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var theQuery_allRecords = from records in users
                                      select records;


            var theQuery_hello = from records in users
                           where records.Password == "hello"
                           select records;
//#1
            Console.WriteLine("1.  Display to console, all the passwords that are \"hello\"");
            foreach (var record in theQuery_hello)
            {
                Console.WriteLine(record.Password);

            }


            Console.WriteLine();
            Console.WriteLine("2. Delete any passwords that are the lower-cased version of their Name");
            //#2
              var deleteRecords = from records in users
                                  where records.Password.ToString() == records.Name.ToLower().ToString()
                                  select records;

              users.RemoveAll(deleteRecords.Contains);
            /*Console.WriteLine("users after deleting lowercase password = name:");
            foreach (var record in theQuery_allRecords)
            {
                Console.WriteLine("{0} {1}", record.Name, record.Password);

            }
            */
            //#3
              Console.WriteLine("3. Delete the first User that has the password \"hello\"");
            users.Remove(theQuery_hello.First());
            Console.WriteLine();
            //#4

            foreach (var record in theQuery_allRecords)
             {
                 Console.WriteLine("{0} {1}",record.Name,record.Password);

             }
             
            


        }
    }
}

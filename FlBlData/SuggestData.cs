using FlBlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlBlData
{
    internal class SuggestData
    {


        static SqlData sqlDataAccess = new();
        static List<Accounts> Account = new();

        public void ShowSuggestions(string course, string section, string studentNo)
        {
            Account = sqlDataAccess.GetCourseSection(course, section, studentNo);

            foreach (var account in Account)
            {
                Console.WriteLine($"\nUsername: {account.Username}");
                Console.WriteLine($"Course: {account.Course}");
                Console.WriteLine($"Section: {account.Section}");
            }

        }

    }
}

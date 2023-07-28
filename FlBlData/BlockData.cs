using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlModel;

namespace FlBlData
{
    public class BlockData
    {


        static SqlData sqlDataAccess = new();
        static List<Blocked> Block = new();

        public void ShowBlockedList(string accountBlocked)
        {
            Block = sqlDataAccess.GetBlockedList(accountBlocked);

            if (Block.Count == 0)
            {
                Console.WriteLine("No blocked list to show.");
            }
            else if (Block.Count > 0)
            {
                foreach (var blocked in Block)
                {
                    Console.WriteLine("StudentNo: " + blocked.StudentNo);
                    Console.WriteLine("Username: " + blocked.BlockedName);
                    Console.WriteLine("Course: " + blocked.BlockedCourse);
                    Console.WriteLine("Section: " + blocked.BlockedSection);
                    Console.WriteLine();
                }
            }
        }
    }
}
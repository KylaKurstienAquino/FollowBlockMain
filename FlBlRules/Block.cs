using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlData;
using FlBlModel;

namespace FlBlRules
{
    public  class Block
    {
        private BlockData blockData;    

        public Block() {
        
            blockData = new BlockData();
        }

        public void BlockAcc(StudentAccount block, StudentAccount studentUser) {

            blockData.dataBlock(follower.user, studentUser.user);
        }

        public void BlockerAcc(StudentAccount block, StudentAccount studentUser)
        {

            blockerData.dataBlocker(block.user, studentUser.user);
        }
    }
}

public class BlockData
{
    private List<BlockedAccounts> blockedAccounts;

    public BlockData()
    {
        BlockedAccounts = new List<BlockedAccounts>();
    }

    public void dataBlock(string blockerUser, string studentUser)
    {
        if (blockedAccounts.Any(b => b.BlockerUser == blockerUser && b.StudentUser == studentUser))
        {
            Console.WriteLine("This user has been blocked to your account.");
            return;
        }

        BlockedAccounts newAccounts = new BlockedAccounts(blockerUser, studentUser);
        BlockedAccounts.Add(newAccounts);

        Console.WriteLine($"User '{studentUser}' is blocked .");
    }

    public void dataUnblock(string blockerUser, string studentUser)
    {
        BlockedAccounts accounts = blockedAccounts.FirstOrDefault(b => b.BlockerUser == blockerUser && b.StudentUser == studentUser);
        
        if (accounts != null)
        {
            BlockedAccounts.Remove(accounts);
            Console.WriteLine($"User '{blockerUser}' has unblocked '{studentUser}'.");
        }
        else
        {
            Console.WriteLine("You haven't blocked this user yet.");
        }
    }
}


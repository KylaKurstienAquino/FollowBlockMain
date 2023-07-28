 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlData;
using FlBlModel;

namespace FlBlRules
{
    public class Suggestions
    {
       
    private List<User> users;

    public FriendSuggester()
    {
        users = new List<User>();
    }


    public List<string> GetFriendSuggestions(string targetUser)
    {
        var targetUserObj = users.FirstOrDefault(u => u.Username == targetUser);
        if (targetUserObj == null)
        {
            Console.WriteLine($"User '{targetUser}' not found.");
            return new List<string>();
        }

        var targetFriends = targetUserObj.Friends;
        var targetInterests = targetUserObj.Interests;

        var suggestions = new List<string>();
        foreach (var user in users)
        {
            if (user.Username != targetUser && !targetFriends.Contains(user.Username))
            {
                
                var commonInterests = user.Interests.Intersect(targetInterests)
                if (commonInterests.Any())
                {
                    suggestions.Add(user.Username);
                }
            }
        }

        return suggestions;
    }
}

}

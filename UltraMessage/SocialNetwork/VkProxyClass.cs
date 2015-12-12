using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace SocialNetwork
{
    public class VkProxyClass
    {
        VkApi _api;
        public VkProxyClass(string email, string password, int appID = 5185160)
        {
            _api = new VkApi();

            _api.Authorize(appID, email, password, Settings.All);
        }


        public Dictionary<long, string> GetFriends()
        {
            Dictionary<long, string> friends = new Dictionary<long, string>();
            try
            {
                var friendsVk = _api.Friends.Get(_api.UserId.Value, ProfileFields.FirstName);

                foreach (var friend in friendsVk)
                {
                    friends.Add(friend.Id, String.Format("{0} {1}", friend.FirstName, friend.LastName));
                }
            }
            catch
            {
                friends = null;
            }

            return friends;
        }

        public bool SendMessage(long idReceiver, string message)
        {
            try
            {
                _api.Messages.Send(idReceiver, false, message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

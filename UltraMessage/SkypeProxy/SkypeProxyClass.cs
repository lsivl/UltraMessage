using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKYPE4COMLib;
using System.Collections;

namespace SkypeProxy
{
    public class SkypeProxyClass
    {
        private Skype skype_machine;

        public SkypeProxyClass() {
            skype_machine = new Skype();
        }

        public void SendMessage(string key, string message){
            if (skype_machine.Client.IsRunning)
            {
                skype_machine.Attach(6, true);
                skype_machine.SendMessage(key, message);
            }
        }

        public Dictionary<string, string> GetFriends()
        {
            Dictionary<string, string> userList = new Dictionary<string,string>();
            skype_machine = new Skype();
            foreach (User user in skype_machine.Friends) {
                // Full name - Value
                // Handle - Key
                userList.Add(user.Handle, user.FullName);
            }
            return userList;
        } 
    }
}

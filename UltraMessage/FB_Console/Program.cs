using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceBookProxy;
using SkypeProxy;

namespace FB_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var facebook = new FaceBookProxyClass();
            //Dictionary<string, string> facebookFriends = facebook.GetFriends();
            //foreach (var friend in facebookFriends) {
            //    Console.WriteLine(String.Format("Id = {0}  Name = {1}", friend.Key, friend.Value));
            //}
            var skype = new SkypeProxyClass();
            skype.GetFriends();
            //skype.SendMessage();
            Console.ReadLine();
        }
    }
}

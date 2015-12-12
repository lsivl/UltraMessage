using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Newtonsoft.Json.Linq;

namespace FaceBookProxy
{
    public class FaceBookProxyClass
    {
        private FacebookClient _fbClient;
        private const string TOKEN = "CAAFbFWGGQ0EBAFSZAgjgTVhXc9jOuIGeZBgqtNlp3mUQfsCqRK2T62I64sZCMGsA3BTr2g7pHgcW7IAXQTRilev8R2mPTtM2736FFZC0YrqZCeMOvbVvEGwl93D2zGikhtZCZCK4el3dmD9AnJ7YLXCfLTwnlQNjWIwOeQ4c2NGZBhOJimBgfk5IWSzRodndAEDeZBtB5wVntpwZDZD";

        public FaceBookProxyClass() {
            _fbClient = new FacebookClient(TOKEN); 
        }

        public string GetString() {
            return "Test";
        }

        public Dictionary<string, string> GetFriends() {
            try
            {
                dynamic friendList = _fbClient.Get("me/taggable_friends");
                JObject friendListJson = JObject.Parse(friendList.ToString());
                var friendDictionary = new Dictionary<string, string>();
                foreach (var friend in friendListJson["data"].Children())
                {
                    var friendId = friend["id"].ToString().Replace("\"", "");
                    var friendName = friend["name"].ToString().Replace("\"", "");
                    friendDictionary.Add(friendId, friendName);
                }
                return friendDictionary;
            }
            catch (FacebookOAuthException)
            {
                return new Dictionary<string, string>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorage.Entity;
using Newtonsoft.Json;

namespace DataStorage
{
   public static class DataStorageProvider
    {
       const string _contactUrl = @"D:\contacts.txt";
       const string _credentialUrl = @"D:\credentials.txt";
       public static bool CreateOrUpdateCredentials(Credentials credential)
       {
           try
           {
               SaveCredentials(credential);
               return true;
           }
           catch
           {
               return false;
           }
       }

       public static bool CreateOrUpdateContact(Contact contact)
       {
           try
           {
               var contactList = GetContactList();

               if (contact.Id != null)
               {
                   contactList = DeleteContactFromList(contact.Id, contactList);
               }

               contactList.Add(contact);

               SaveContactList(contactList);

               return true;
           }
           catch { return false; }
       }

       public static bool DeleteContact(Guid Id)
       {
           try
           {
               var contactList = GetContactList();

               contactList = DeleteContactFromList(Id, contactList);

               SaveContactList(contactList);

               return true;
           }
           catch { return false; }
       }

       public static Credentials GetCredentials()
       {
           try
           {
               var json = System.IO.File.ReadAllText(_credentialUrl);

               return JsonConvert.DeserializeObject<Credentials>(json);
           }
           catch
           {
               return new Credentials();
           }
       }

       private static List<Contact> DeleteContactFromList(Guid Id, List<Contact> contactList)
       {
           var oldContact = contactList.Where(p => p.Id == Id).FirstOrDefault();
           if (oldContact != null) contactList.Remove(oldContact);

           return contactList;
       }


       private static List<Contact> GetContactList()
       {
           try
           {
               var json = System.IO.File.ReadAllText(_contactUrl);

               return JsonConvert.DeserializeObject<List<Contact>>(json);
           }
           catch
           {
               return new List<Contact>();
           }
       }

       private static void SaveContactList(List<Contact> contactList)
       {
            var json = JsonConvert.SerializeObject(contactList);

            System.IO.File.WriteAllText(_contactUrl, json);
       }

       private static void SaveCredentials(Credentials credentials)
       {
           var json = JsonConvert.SerializeObject(credentials);

           System.IO.File.WriteAllText(_credentialUrl, json);
       }
    }
}

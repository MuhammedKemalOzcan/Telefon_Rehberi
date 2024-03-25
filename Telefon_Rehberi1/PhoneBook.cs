using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Telefon_Rehberi1
{
    internal class PhoneBook
    {
        private List<Contact> contacts;
        public PhoneBook() 
        {
            contacts = new List<Contact>()
            {
                new Contact() {FirstName = "aaa", LastName = "aaa", PhoneNumber = "000"},
                new Contact() {FirstName = "bbb", LastName = "bbb", PhoneNumber = "111"},
                new Contact() {FirstName = "ccc", LastName = "ccc", PhoneNumber = "222"},
                new Contact() {FirstName = "ddd", LastName = "ddd", PhoneNumber = "333"},
                new Contact() {FirstName = "eee", LastName = "eee", PhoneNumber = "444"},
            };
        }

        public void AddContact()
        {
            Console.WriteLine("Lütfen kaydetmek istediğiniz kişinin adını giriniz");
            string firstName = Console.ReadLine();
            Console.WriteLine("Lütfen kaydetmek istediğiniz kişinin soyadını giriniz");
            string lastName = Console.ReadLine();
            Console.WriteLine("Lütfen kaydetmek istediğiniz kişinin numarasını giriniz");
            string number = Console.ReadLine();

            contacts.Add(new Contact() { FirstName = firstName, LastName = lastName, PhoneNumber = number });
        }
        
        public void RemoveContact()
        {
            Console.WriteLine("Rehberden silmek istediğiniz kişinin adını veya soyadını giriniz.");
            string search = Console.ReadLine();

            Contact contactToRemove = contacts.FirstOrDefault(x => x.FirstName.ToLower() == search || x.LastName.ToLower() == search);
            if (contactToRemove == null)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Silmeyi sonlandırmak için : 1");
                Console.WriteLine("Yeniden denemek için 2:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        RemoveContact();
                        break;
                }
            }
            Console.WriteLine($"{contactToRemove.FirstName} {contactToRemove.LastName} adlı kişi rehberden silinsin mi? (y/n)");
            string removeConfirmation = Console.ReadLine();
            if (removeConfirmation.ToLower() == "y")
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Silme işlemi başarılı.");
            }
            else
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
                Console.WriteLine();
            }
        }

        public void UpdateContact()
        {
            Console.WriteLine("Güncellemek istediğiniz kişinin adını soyadını giriniz.");
            string search = Console.ReadLine();
            Contact contactToUpdate = contacts.FirstOrDefault(x=> x.FirstName.ToLower() == search || x.LastName.ToLower() == search);
            if (contactToUpdate == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kişi bulunamadı!");
                Console.WriteLine("Güncellemeyi sonlandırmak için (1)");
                Console.WriteLine("Yeniden denemek için (2)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        RemoveContact();
                        break;
                }
            }

            Console.WriteLine($"{contactToUpdate.FirstName} {contactToUpdate.LastName} adlı kişinin yeni numarasını giriniz");
            contactToUpdate.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Numara başarıyla güncellendi!");
        }
        public void DisplayContact()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"İsim: {contact.FirstName}, Soyisim: {contact.LastName}, Telefon Numarası: {contact.PhoneNumber} ");
            }
        }
        public void SearchContact()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz");
            Console.WriteLine("*************************************");
            Console.WriteLine("İsim Soyisime göre arama yapmak için (1)");
            Console.WriteLine("Numaraya göre arama yapmak için (2)");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Arama yapmak istediğiniz kişinin adını veya soyadını giriniz.");
                string searchTerm = Console.ReadLine();
                var searchResult = contacts.Where(x=>x.FirstName.ToLower().Contains(searchTerm) || 
                x.LastName.ToLower().Contains(searchTerm)).ToList();
                if (searchResult == null)
                {
                    Console.WriteLine("Arama sonucu bulunamadı");
                }
                Console.WriteLine("Arama sonuçlarınız:");
                Console.WriteLine("*******************");
                foreach (var contact in searchResult)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber}");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Arama yapmak istediğiniz kişinin numarasını giriniz");
                string searchTerm = Console.ReadLine();
                var searchResult = contacts.Where(x => x.PhoneNumber.Contains(searchTerm)).ToList();
                if (searchTerm == null)
                {
                    Console.WriteLine("Arama sonucu bulunamadı");
                }
                Console.WriteLine("Arama sonuçlarınız:");
                Console.WriteLine("*******************");
                foreach (var contact in searchResult)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.PhoneNumber}");
                }

            }


        }


    }
}

namespace Telefon_Rehberi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("*****************************************");
            Console.WriteLine("1. Telefon numarası kaydet");
            Console.WriteLine("2. Telefon numarası sil");
            Console.WriteLine("3. Telefon numarası güncelle");
            Console.WriteLine("4. Rehberi görüntüle");
            Console.WriteLine("5. Rehberde arama");
            Console.WriteLine("*****************************************");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    phoneBook.AddContact();
                    phoneBook.DisplayContact();
                    break;
                case 2:
                    phoneBook.RemoveContact();
                    phoneBook.DisplayContact();
                    break;
                case 3:
                    phoneBook.UpdateContact();
                    phoneBook.DisplayContact();
                    break;
                case 4:
                    phoneBook.DisplayContact();
                    break;
                case 5:
                    phoneBook.SearchContact();
                    break;
                default:
                    break;
            }

        }
    }
}

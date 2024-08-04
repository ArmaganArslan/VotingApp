using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = new List<string> { "Film Kategorileri", "Teknoloji Kategorileri", "Spor Kategorileri", "Oyun Kategorileri", "Dizi Kategorileri", "Kitap Kategorileri" };

            var users = new Dictionary<string, Users>();
            var votes = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                votes[category] = 0;
            }

            Console.WriteLine("Hoşgeldiniz! Aşağıdaki kategorilerde oy kullanabilirsiniz:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            while (true)
            {
                Console.WriteLine("Kullanıcı adınızı giriniz:");
                string username = Console.ReadLine();

                if (!users.ContainsKey(username))
                {
                    Console.WriteLine("Kullanıcı sistemde kayıtlı değil. Kayıt işlemi yapmanız gerekiyor.");
                    Console.WriteLine("Adınızı giriniz:");
                    string name = Console.ReadLine();
                    users[username] = new Users { Username = username, Name = name };
                    Console.WriteLine("Kayıt işleminiz tamamlandı.");
                }
                else
                {
                    Console.WriteLine($"Hoşgeldiniz {users[username].Name}!");
                }

                Console.WriteLine("Oy kullanmak istediğiniz kategoriyi seçin (sayı ile seçin):");
                int categoryIndex;
                if (int.TryParse(Console.ReadLine(), out categoryIndex) && categoryIndex >= 1 && categoryIndex <= categories.Count)
                {
                    string selectedCategory = categories[categoryIndex - 1];
                    votes[selectedCategory]++;
                    Console.WriteLine($"Oyunuz '{selectedCategory}' kategorisine kaydedildi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir kategori numarası girin.");
                }

                Console.WriteLine("Başka bir oy kullanmak ister misiniz? (E/H)");
                string continueVoting = Console.ReadLine();
                if (continueVoting.ToUpper() != "E")
                {
                    break;
                }
            }

            Console.WriteLine("\nOylama Sonuçları:");
            int totalVotes = votes.Values.Sum();
            foreach (var category in categories)
            {
                int categoryVotes = votes[category];
                double percentage = totalVotes > 0 ? (double)categoryVotes / totalVotes * 100 : 0;
                Console.WriteLine($"{category}: {categoryVotes} oy ({percentage:F2}%)");
            }

            Console.WriteLine("Uygulama sonlandırılıyor...");
        }
    }
}

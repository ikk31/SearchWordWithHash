using System.Security.Cryptography;
using System.Text;

namespace traesurekod
{
    internal class Program
    {
        static string ComputeMd5Hex(string s)
        {
            using var md5 = MD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(s);
            byte[] hash = md5.ComputeHash(data);
            var sb = new System.Text.StringBuilder(hash.Length * 2);
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        static string ComputeSha256Hex(string s)
        {
            using var sha256 = SHA256.Create();
            byte[] data = Encoding.UTF8.GetBytes(s);
            byte[] hash = sha256.ComputeHash(data);
            var sb = new System.Text.StringBuilder(hash.Length * 2);
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            //Пути к файлам со словами
            string[] paths = { 
                @"C:\Users\mihal\Desktop\wordlist\wordlist1.txt", 
                
                @"C:\Users\mihal\Desktop\wordlist\wordlist2.txt", 
                
                @"C:\Users\mihal\Desktop\wordlist\wordlist3.txt", 
                
                @"C:\Users\mihal\Desktop\wordlist\wordlist4.txt" };

            //В переменной хранятся все строки из всех текстовых документов
            string[] AllLines = paths.SelectMany(path => File.ReadAllLines(path)).ToArray();

            string[] HashList =
            {
                "5f1e2408e2290940d2f77bc688e96378", "5ac09104603448a6f905bd494b6d549b", "c09d2644aa265a0b675c380b14fe0922", "0a9988b6cd69464701873d79b06928030db91412c02f429967628d952438f38b"
            };

            //циклом перебираем каждое слово
            foreach (var line in AllLines)
            {
                string md5Hex = ComputeMd5Hex(line);
                string Sha256 = ComputeSha256Hex(line);

                foreach (var hash in HashList)
                {
                    if (hash.Equals(md5Hex) || hash.Equals(Sha256))
                    {
                        Console.WriteLine(line);
                    }
                }

                //foreach (string line in AllLines) {

                //    switch (ComputeMd5Hex(line))
                //    {
                //        case "5f1e2408e2290940d2f77bc688e96378":
                //            Console.WriteLine($"Код от первого сундукка: {line}");
                //            break;
                //        case "6c34fd5b51dcdd56ad9204c67209d6b5":
                //            Console.WriteLine($"Код от второго сундука: {line}");
                //            break;
                //        case "c09d2644aa265a0b675c380b14fe0922":
                //            Console.WriteLine($"Код от третьего сундука: {line}");
                //            break;
                //        case "2bb80d537b1da3e38bd30361aa855686bde0ba30abf1f0c0c4b0f5e9d9e6fdae":
                //            Console.WriteLine($"код от четвертого сундука: {line}");
                //            break;
                //    }

            }
            

        }
    }
}

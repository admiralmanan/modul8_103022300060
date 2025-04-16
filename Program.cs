using modul8_103022300060;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig bankconfig = BankTransferConfig();
        bankconfig.ReadConfigFile(url);

        bool defaultUtang = bankconfig.lang == "en";

       Console.WriteLine(defaultUtang ? "Welcome" : "Selamat Datang";
        Console.WriteLine(defaultUtang ? "Program languange! " : "Bahasa Saat Ini!:" + bankconfig.lang);
        
        try
        {

        }
       

    }
}
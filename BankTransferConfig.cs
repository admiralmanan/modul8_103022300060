using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300060
{
  
    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public class method
    {

    }
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }
        public Transfer transfer { get; set; }

        public BankTransferConfig()
        {

        }

        public BankTransferConfig(string lang, Transfer transfer, string[] methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
        public void WriteConfigFile(string url)
        {
            if (url != null)
            {
                try
                {
                    JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    };
                    string jsonStr = JsonSerializer.Serialize(this, jsonOptions);
                    File.WriteAllText(url, jsonStr);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Terjadi Kesalahan dalam write config file  " + e.Message);
                }
            }
            else
            {
                Console.Error.WriteLine("Tidak ada file pada url");
            }
        }
        public void ReadConfigFile(string url)
        {
            if (url != null)
            {
                try
                {
                    var json = File.ReadAllText(url);
                    var bankConfig = JsonSerializer.Deserialize<BankTransferConfig>(json);

                    lang = bankConfig!.lang;
                    transfer = bankConfig!.transfer;
                    methods = bankConfig!.methods;
                    confirmation = bankConfig!.confirmation;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Terjadi Kesalahan dalam read config file  " + e.Message);
                }
            }
            else
            {
                Console.Error.WriteLine("Tidak ada file pada url");
            }
        }
    }
}
}

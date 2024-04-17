using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302220084
{
    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set;}
    }

    public class Confirmation
    {
        public String en { get; set; }
        public String id { get; set; }
    }
    public class Config
    {
        public String lang { get; set; }
        public Transfer transfer { get; set; }
        public String[] method {  get; set; }
        public Confirmation confirmation { get; set; }
        public Config() { }

        public Config(String lang, Transfer transfer, String[] method, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.method = method;
            this.confirmation = confirmation;
        }
    }
    public class BankTransferConfig
    {
        public Config config;
        public const String filePath = "../../../bank_transfer_config.json";

        public BankTransferConfig() {
            try
            {
                config = readConfigFile();
            } catch (Exception e)
            {
                setDefault();
                writeNewConfigFile();
            }
        }

        private Config readConfigFile()
        {
            String jsonData = File.ReadAllText(filePath);
            Config config = JsonSerializer.Deserialize<Config>(jsonData);
            return config;
        }

        private void setDefault()
        {
            //deklarasi objek tf sebagai temp untuk dimasukan ke constructor config
            Transfer tf = new Transfer();
            tf.threshold = 25000000;
            tf.low_fee = 6500;
            tf.high_fee = 15000;

            //deklarasi temp md
            String[] md = {"RTO (real-time)", "SKN", "RTGS", "BI FAST" };

            //deklarasi temp cf
            Confirmation cf = new Confirmation();
            cf.en = "yes";
            cf.id = "ya";


            config = new Config(lang: "en", transfer: tf, method: md, confirmation: cf);
        }

        private void writeNewConfigFile()
        {
            JsonSerializerOptions option = new JsonSerializerOptions() { WriteIndented = true };
            String jsonString = JsonSerializer.Serialize(config, option);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

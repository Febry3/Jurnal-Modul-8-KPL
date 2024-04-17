using modul8_1302220084;

internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig cfg = new BankTransferConfig();

        int jumlahTransfer = 0;
        int biayaTransfer = 0;
        String metode;
        String konfirmasi;
        

        if (cfg.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer");
            jumlahTransfer = Convert.ToInt32(Console.ReadLine());
        } 
        else if (cfg.config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer");
            jumlahTransfer = Convert.ToInt32(Console.ReadLine());
        }

        if (jumlahTransfer <= cfg.config.transfer.threshold)
        {
            biayaTransfer = cfg.config.transfer.low_fee;
        } else
        {
            biayaTransfer = cfg.config.transfer.high_fee;
        }

        if (cfg.config.lang == "en")
        {
            Console.WriteLine("Transfer fee = {0} \nTotal amount = {1}", biayaTransfer, biayaTransfer + jumlahTransfer);
        }
        else if (cfg.config.lang == "id")
        {
            Console.WriteLine("Biaya transfer = {0} \nTotal biaya = {1}", biayaTransfer, biayaTransfer + jumlahTransfer);
        }

        if (cfg.config.lang == "en")
        {
            Console.WriteLine("Select transfer method:");
        }
        else if (cfg.config.lang == "id")
        {
            Console.WriteLine("Pilih metode transfer:");
        }

        for (int i = 0; i < cfg.config.method.Count(); i++) 
        {
            Console.WriteLine(i+1 + ". " + cfg.config.method[i]);
        }
        metode = Console.ReadLine();

        if (cfg.config.lang == "en")
        {
            Console.WriteLine("Please type \"{0}\" to confirm the transaction", cfg.config.confirmation.en);
        }
        else if (cfg.config.lang == "id")
        {
            Console.WriteLine("Ketik \"{0}\" untuk mengkonfirmasi transaksi", cfg.config.confirmation.id);
        }
        konfirmasi = Console.ReadLine();
        
        if (konfirmasi == cfg.config.confirmation.id || konfirmasi == cfg.config.confirmation.en) { 
            if (cfg.config.lang == "en")
            {
                Console.WriteLine("The transfer is completed");
            } else if (cfg.config.lang == "id") {
                Console.WriteLine("Proses transfer berhasil");
            }
        } else
        {
            if (cfg.config.lang == "en")
            {
                Console.WriteLine("Transfer is cancelled");
            }
            else if (cfg.config.lang == "id")
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }

    }
}
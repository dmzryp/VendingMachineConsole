using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineConsole
{
    class Program
    {
        static void Main()
        { 
            List<ListMenu> listmenus = new();

            listmenus.Add(new ListMenu() { nama = "Biskuit", harga = 6000, stock = 10, id = 1 });
            listmenus.Add(new ListMenu() { nama = "Chips", harga = 8000, stock = 8, id = 2 });
            listmenus.Add(new ListMenu() { nama = "Oreo", harga = 10000, stock = 6, id = 3 });
            listmenus.Add(new ListMenu() { nama = "Tanggo", harga = 12000, stock = 3, id = 4 });
            listmenus.Add(new ListMenu() { nama = "Cokelat", harga = 15000, stock = 2, id = 5 });

            Mulai(0, listmenus);
        }
        
        static void Mulai(double saldo, List<ListMenu> listmenus)
        {
            _ = new Program();
            Double inputan;
                       
             Console.Write("Masukan Uang:");
             inputan = Convert.ToDouble(Console.ReadLine()); 

            bool uangOK = IsOk(inputan);

            if (uangOK){
                saldo += inputan;
                Proses(saldo, listmenus);
                            }
            else{
                Console.WriteLine("Maaf Uang tdk valid");
                Mulai(saldo, listmenus);
            }
        }

        static void Proses(double saldo, List<ListMenu> listmenus)
        {
            String inputanStr;
            Console.WriteLine($"Saldo anda : {saldo}");
            Console.WriteLine("ketik p untuk pesan atau t untuk Tambah Saldo");
            inputanStr = Console.ReadLine();
            if (inputanStr.ToLower() == "t")
            {
                Mulai(saldo, listmenus);
            }
            else if (inputanStr.ToLower() == "p")
            {
                foreach (ListMenu o in listmenus)
                {
                    Console.WriteLine($" {o.nama} harga: {o.harga}  stock: {o.stock} ID: {o.id}");
                }
                Console.WriteLine("Ketik ID untuk pesan");
                inputanStr = Console.ReadLine();
                foreach (var o in from o in listmenus
                                  where o.id == Convert.ToInt32(inputanStr)
                                  select new { o.nama, o.harga })
                {
                    if (saldo >= o.harga)
                    {
                        Console.WriteLine($"Pesanan anda {o.nama} behasil");
                        Console.WriteLine($"Kembalian anda adalah {saldo - o.harga}");
                        Console.Write("Terima kasih");
                    }
                    else
                    {
                        Console.WriteLine("Maaf Saldo anda tidak cukup");
                        Proses(saldo, listmenus);
                    }
                }
            }
            else
            {
                Console.WriteLine("ketik p/t aja");
                Proses(saldo, listmenus);
            }
        }

        protected static bool IsOk(double uang)
        {
            double[] objectUang = new double[5] { 2000.00, 5000.00, 10000.00, 20000.00, 50000.00 };
            bool ok = false;
            for (int j = 0; j < objectUang.Length; j++)
            {
                if (uang == objectUang[j])
                {
                    ok = true;
                    break;
                }
            }    
            return ok;
        }
    }
}

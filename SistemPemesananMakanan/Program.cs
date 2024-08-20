// Kelas Makanan adalah blueprint atau template
public class Makanan
{
    // Atribut / Props 
    public string Nama { get; } // public berarti bisa diakses di luar kelas
    public int Harga { get; } // get untuk ngambil nilai dri props ini

    public Makanan(string nama, int harga) // Spesial Method pokonya supaya tidak duplikasi kode,, jadi tinggal new Makanan(namanya, harganya) 
    {
        Nama = nama; // ini menginialisasi bahwa nama itu dari props Nama
        Harga = harga; 
    }

    public void TampilkanInfo() 
    {
        Console.WriteLine($"Nama: {Nama}, Harga: {Harga}");
    }
}

// Kelas Pemesanan adalah 
public class Pemesanan
{
    // atibut / props
    private List<Makanan> daftarMakananValid = new List<Makanan>(); // daftar makanan yg tersedia
    private List<Makanan> daftarMakanan = new List<Makanan>(); // daftar makanan yg dipesan

    // konstruktor untuk inialisasi daftar makanan yg valid atau tersedia
    public Pemesanan()
    {
        daftarMakananValid.Add(new Makanan("Pizza", 10000));
        daftarMakananValid.Add(new Makanan("Burger", 15000));
        daftarMakananValid.Add(new Makanan("Soda", 5000));
    }

    // method untuk nambah pesanan,, terdapat validasi jika makanan yg dipesan tidak ada dalam daftar makanan, maka pesanan yg tidak ada akan di tolak dan di konfirmasikan di console
    public void TambahMakanan(Makanan makanan)
    {
        if (makanan != null && daftarMakananValid.Exists(m => m.Nama == makanan.Nama && m.Harga == makanan.Harga)) // Exists dengan lambda expresion, m = parameter, apakah m memiliki Nama dan Harga yg sesuai dengan Nama dan Harga yg ada di dalam makanan?
        {
            daftarMakanan.Add(makanan);
            Console.WriteLine($"{makanan.Nama} berhasil ditambahkan ke dalam pesananmu :D");
        }
        else
        {
            Console.WriteLine("Maaf, makanan yg anda inginkan tidak tersedia..");
        }
    }

    // method untuk menghitung total harga dari semua pesanan
    public int HitungTotalHarga()
    {
        return daftarMakanan.Sum(makanan => makanan.Harga);
    }


    //  method untuk menampilkan pesanan yg ada di daftar 
    public void TampilkanPesanan() 
    {
        Console.WriteLine("Daftar Pesanan:");
        foreach (var makanan in daftarMakanan)
        {
            makanan.TampilkanInfo();
        }
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        // inisialisasi
        Pemesanan pesanan = new Pemesanan();

        // deklarasi dan inisialisasi dengan objek makanan
        List<Makanan> makananList = new List<Makanan>
        {
            new Makanan("Pizza", 10000),
            new Makanan("Burger", 15000),
            new Makanan("Soda", 5000),
            new Makanan("udang busuk", 3000)
        };

        // menambahkan makanan ke dalam pesanan dengan loop
        foreach (var makanan in makananList)
        {
            pesanan.TambahMakanan(makanan);
        }
        
        // menampilkan pesanan ke console
        pesanan.TampilkanPesanan();

        // memanggil method hitungtotalharga dan menampilkan total harganya ke console
        int totalHarga = pesanan.HitungTotalHarga();
        Console.WriteLine($"Total Harga Pesanan: {totalHarga}");
    }
}


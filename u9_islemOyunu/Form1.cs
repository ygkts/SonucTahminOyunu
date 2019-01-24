using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace u9_islemOyunu
{
    public partial class Form1 : Form
    {
        // random üretilmiş 2 adet 1 -9 arasında sayının, radnom seçilmiş bir hesap işemiyle (+-*/) 
        // sonucu hesaplanıyor. Kulanıcı bu sonucu tahmin etmeye çalışıyor. 
        // 3 kerede bilemezse -1, bilirse +1 puan alıyor.  
        // 5 kere ardarda bilirse 1 tahmin hakkı daha kazanıyor.
        public Form1()
        {
            InitializeComponent();
        }
        int sayi1, sayi2, islem, sonuc, skor, tahmin, sayacDogru, sayacYanlis = 0, hak = 3;

        public void hesaplama()
        {
            sonuc = 0; tahmin = 0;
            Random rast = new Random();

            sayi1 = rast.Next(1, 10);
            sayi2 = rast.Next(1, 10);
            islem = rast.Next(1, 4);

            if (islem == 1)
            {
                sonuc = sayi1 + sayi2;
                label5.Text = sayi1.ToString() + " + " + sayi2.ToString();
            }
            else if (islem == 2)
            {
                sonuc = sayi1 - sayi2;
                label5.Text = sayi1.ToString() + " - " + sayi2.ToString();
            }
            else if (islem == 3)
            {
                sonuc = sayi1 * sayi2;
                label5.Text = sayi1.ToString() + " * " + sayi2.ToString();
            }
            else if (islem == 4)
            {
                sonuc = sayi1 / sayi2;
                label5.Text = sayi1.ToString() + " / " + sayi2.ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hesaplama();   
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            tahmin = Convert.ToInt32(textBox2.Text);        // butona her tıklandığında yeni bir değer girilebilsin diye
            if (tahmin == sonuc)
            {
                skor++; sayacDogru++;
                label4.Text = skor.ToString();
                label6.Text = "Dogru Tahmin :)";

                if (sayacDogru == 5)
                {
                    hak++;
                    MessageBox.Show("1 adet tahmin hakkı kazandınız :)");
                    label7.Text = "Yanlış tahmin hakkı : " + hak.ToString();
                    sayacDogru = 0;
                }
                hesaplama();
                label7.Text = "Kalan hak : " + hak.ToString();
                sayacYanlis = 0;
            }
            else if (tahmin != sonuc)
            {
                hak--;         // hak = 3;
                sayacYanlis++; sayacDogru = 0;
                label6.Text = "Yanlış tahmin :( Tahmin hakkınız 1 azaldı :(";
                label7.Text = " Yanlış tahmin hakkı : " + hak.ToString();
            }
            if (hak == 0 || sayacYanlis == 3)       // 3 hakkı bitince skoru bir azalıyor ve hak tekrar 3 yapılıyor.
            {
                MessageBox.Show("Sayıyı bulamadınız :( ");
                skor--; sayacYanlis = 0;
                label4.Text = skor.ToString();
                // hesaplama();
                hak += 3;
                label6.Text = "3 KERE ARD ARDA YANLIŞ GİRİŞ YAPTINIZ! ";
                label7.Text = "OYUN BİTTİ !!!!!";
                MessageBox.Show("OYUN BİTTİ. SKOR: "  + skor);
                Application.Exit();
            }

        }
    }
}

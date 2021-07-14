using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modern_Hesap_Makinesi
{
    public partial class Modern_Hesap_Makinesi : Form
    {
        decimal birinciSayi, ikinciSayi, hafiza;
        string islem;
        Boolean sonuclandi,farkliMi;


        public Modern_Hesap_Makinesi()
        {
            InitializeComponent();
        }

        private void Modern_Hesap_Makinesi_Load(object sender, System.EventArgs e)
        {
            txtSonuc.Focus();
            this.Text = "Hesap Makinesi";
            txtSonuc.Text = "";
        }
        decimal sonuc;
        private void rakamlar(object sender, System.EventArgs e)
        {
            if (sonuclandi)
                txtSonuc.Text = (sender as Button).Text;
            else
            {
                txtSonuc.Text = txtSonuc.Text + (sender as Button).Text;
            }
            sonuclandi = false;
        }

        private void btnArtiEksi_Click(object sender, System.EventArgs e)
        {
            if (txtSonuc.Text.Length > 0)
                if (txtSonuc.Text.Substring(0, 1) == "-")
                    //Sayinin basinda - varsa sil
                    txtSonuc.Text = txtSonuc.Text.Substring(1);
                else
                    //- yoksa - ekle
                    txtSonuc.Text = "-" + txtSonuc.Text.Substring(0);
        }

        private void btnVirgul_Click(object sender, System.EventArgs e)
        {
            //sayida virgul yoksa
            if (txtSonuc.Text.IndexOf(",") <= 0)
                if (txtSonuc.Text.Length == 0)
                    //hiç karakter yoksa 0, ekle
                    txtSonuc.Text = "0,";
                else
                    //sayi varsa sonuna virgul ekle
                    txtSonuc.Text = txtSonuc.Text + ",";
        }

        private void btnSil_Click(object sender, System.EventArgs e)
        {
            txtSonuc.Text = "";
            sonuc = 0;
            op = "";
        }

        private void btnGeriSil_Click(object sender, System.EventArgs e)
        {
            if (txtSonuc.Text.Length > 0)
            {
                txtSonuc.Text = txtSonuc.Text.Substring(0, txtSonuc.Text.Length - 1);
            }
        }

        private void hafiza_islemleri(object sender, System.EventArgs e)
        {
            if (txtSonuc.Text.Length == 0)
            {
                txtSonuc.Text = "0";
            }

            switch ((sender as Button).Text)
            {
                case "MC":
                    hafiza = 0;
                    break;
                case "M+":
                    hafiza = hafiza + decimal.Parse(txtSonuc.Text);
                    break;
                case "M-":
                    hafiza = hafiza - decimal.Parse(txtSonuc.Text);
                    break;
                case "MR":
                    txtSonuc.Text = hafiza.ToString();
                    break;
            }
        }      

        private void Button_Esit_Click(object sender, System.EventArgs e)
        {
            if (txtSonuc.Text.Length == 0)
            {
                txtSonuc.Text = "0";
            }
            txtSonuc.Text = sonuc.ToString();           

            sonuclandi = true;
        }

        private void islem_Yap_2(object sender, System.EventArgs e)
        {
            decimal sayi;
            if (txtSonuc.Text.Length == 0)
                txtSonuc.Text = "0";
            sayi = decimal.Parse(txtSonuc.Text);
            switch ((sender as Button).Text)
            {
                case "Kök":
                    if (sayi >= 0)
                        txtSonuc.Text = Math.Sqrt((double)sayi).ToString();
                    break;
                case "x²":
                    txtSonuc.Text = (sayi * sayi).ToString();
                    break;
                case "1/x":
                    if (sayi != 0)
                        txtSonuc.Text = (1 / sayi).ToString();
                    break;               
            }
        }

        
        string op;
        private void btnArtii_Click(object sender, EventArgs e)
        {
           
            if (btnArtii.Text == op)
            {
                sonuc += decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            else
            {
                sonuc = decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;
            op = "+";            
        }

        private void btnEksii_Click(object sender, EventArgs e)
        {
             if (btnEksii.Text == op)
            {
                if (sonuc == 0)
                    {
                       sonuc = decimal.Parse(txtSonuc.Text);
                       txtSonuc.Text = sonuc.ToString();
                    }
                 else
                   {
                       sonuc -= decimal.Parse(txtSonuc.Text);
                       txtSonuc.Text = sonuc.ToString();
                   }
            }
             else
             {
                 sonuc = decimal.Parse(txtSonuc.Text);
                 txtSonuc.Text = sonuc.ToString();
             }
            sonuclandi = true;
            op = "-";
        }

        private void btnboluu_Click(object sender, EventArgs e)
        {

            if (btnboluu.Text== op)
            {
                if (sonuc == 0)
                {
                    sonuc = decimal.Parse(txtSonuc.Text);
                    txtSonuc.Text = sonuc.ToString();
                }
                else
                {
                    sonuc /= decimal.Parse(txtSonuc.Text);
                    txtSonuc.Text = sonuc.ToString();
                }
            }
            else
            {
                sonuc = decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;
            op = "/";
        }

        private void btnCarpii_Click(object sender, EventArgs e)
        {

            if (btnCarpii.Text == op)
            {
                if (sonuc == 0)
                {
                    sonuc = decimal.Parse(txtSonuc.Text);
                    txtSonuc.Text = sonuc.ToString();
                }
                else
                {
                    sonuc *= decimal.Parse(txtSonuc.Text);
                    txtSonuc.Text = sonuc.ToString();
                }
            }
            else
            {
                sonuc = decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;
            op = "*";
        }

        private void btnUs_Click(object sender, EventArgs e)
        {
            if (btnUs.Text == op)
            {
                sonuc = decimal.Parse( Math.Pow(double.Parse(sonuc.ToString()),double.Parse(txtSonuc.Text)).ToString());
                txtSonuc.Text = sonuc.ToString();
            }
            else
            {
                sonuc = decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;
            op = "x^y";                 
        }

        private void btnSin_Click(object sender, EventArgs e)
        {           
                sonuc = decimal.Parse(Math.Sin((Math.PI* double.Parse(txtSonuc.Text))/180.0).ToString());
                txtSonuc.Text = sonuc.ToString();           
                sonuclandi = true;                 
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Cos((Math.PI * double.Parse(txtSonuc.Text)) / 180.0).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true;
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Tan((Math.PI * double.Parse(txtSonuc.Text)) / 180.0).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true;
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Sinh(double.Parse(txtSonuc.Text)).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true;  
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Cosh(double.Parse(txtSonuc.Text)).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true;  
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Tanh(double.Parse(txtSonuc.Text)).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true;  
        }

        private void btnKup_Click(object sender, EventArgs e)
        {           
            sonuc = decimal.Parse(Math.Pow(double.Parse(txtSonuc.Text), double.Parse("3")).ToString());
            txtSonuc.Text = sonuc.ToString();           
            sonuclandi = true;                    
        }

        private void btnFaktoriyel_Click(object sender, EventArgs e)
        {
            sonuc = 1;
            if (decimal.Parse(txtSonuc.Text) == 0)
            {
                sonuc = 1;
                txtSonuc.Text = sonuc.ToString();
            }
            else
            {
                for (decimal i =decimal.Parse(txtSonuc.Text) ; i >0; i--)
                {
                    sonuc *= i;
                }
                
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;  
        }

        private void btnOnUzeri_Click(object sender, EventArgs e)
        {           
               
              string s="1";              
                  if (decimal.Parse(txtSonuc.Text) == 0)
                  {
                      sonuc = 1;
                      txtSonuc.Text = sonuc.ToString();
                  }

                  else
                  {
                      for (decimal i = decimal.Parse(txtSonuc.Text); i > 0; i--)
                      {
                          s += "0";
                      }
                      sonuc = decimal.Parse(s);
                      txtSonuc.Text = sonuc.ToString();
                  }
             
            sonuclandi = true;
       
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            sonuc = decimal.Parse(Math.Log10(double.Parse(txtSonuc.Text)).ToString());
            txtSonuc.Text = sonuc.ToString();
            sonuclandi = true; 
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (btnMod.Text == op)
            {
                sonuc = decimal.Parse((double.Parse(sonuc.ToString())% double.Parse(txtSonuc.Text)).ToString());
                txtSonuc.Text = sonuc.ToString();
            }
            else
            {
                sonuc = decimal.Parse(txtSonuc.Text);
                txtSonuc.Text = sonuc.ToString();
            }
            sonuclandi = true;
            op = "Mod";       
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("PrzePoj")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ZED1200")]
[assembly: AssemblyProduct("PrzePoj")]
[assembly: AssemblyCopyright("Free")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("0.1.*")]

/*
KB, MB, GB, TB, PB - peta bajty, EB - eksa bajty, ZB - zetta bajty, YB - jotta bajty
*/

public class Okno:Form
{
	Form Pomoc; // !!
	TextBox textBoxl;
	ComboBox combobox_wielokrotnosc_danych;
	Label label_wynik_odpowiedz_1 = new Label();
	Label label_wynik_odpowiedz_2 = new Label();
	
	
	public string COMBOBOX_STRING_0;
	public string DANE_TEXTBOX;
	public double WYLICZENIE_WARTOSCI = 0;
	
	
	private  void  OnPomoc(object sender, EventArgs ea)
	{
		Pomoc = new Form(); // !!!
		Pomoc.Text = "Pomoc";
		Pomoc.Width = 300;
		Pomoc.Height = 230;
		
		Label label_pomoc = new Label();
		
		label_pomoc.Text = "\nProgram przelicza pojemność nośnika jaka\njest dostępna dla użytkownika z jednostek\nfizycznych na jednosteki informatyczne.\n\nKB - kilo bajty, MB - mega bajty, GB - giga bajty,\nTB - tera bajty, PB - peta bajty, EB - eksa bajty,\nZB - zetta bajty, YB - jotta bajty";
		label_pomoc.AutoSize = true;
		label_pomoc.Left = 10;
		label_pomoc.Top = 30;
		Pomoc.Controls.Add(label_pomoc);
		
		Button button_pomoc = new Button();
		button_pomoc.Text ="Ok"; 
		button_pomoc.Left = ((Pomoc.Width - button_pomoc.Width) / 2)-10; 
		button_pomoc.Top = (Pomoc.Height-80);
		button_pomoc.Click += new EventHandler(ZamknicieOkna);
		
		Pomoc.Controls.Add(button_pomoc);
		
		Pomoc.Show();
	}
	
	private void ZamknicieOkna(object sender, EventArgs ea)
	{
		Pomoc.Close();
	}
	
	private void OnWyjdz(object sender, EventArgs ea)
	{
		Application.Exit();
	}
	
	private void OnButtonLicz(object sender, EventArgs ea)
	{
		string wynik_kontorla;
		char odpowiedz = new char();
		wynik_kontorla = textBoxl.Text;
		odpowiedz = Czy_to_jest_liczba(wynik_kontorla);
		
		if (odpowiedz =='t')
		{
			double odpowiedz_2 = new double();
			WYLICZENIE_WARTOSCI = double.Parse(textBoxl.Text);
			
			WYLICZENIE_WARTOSCI = Liczenie_pojemnosci(COMBOBOX_STRING_0, WYLICZENIE_WARTOSCI);
			
			odpowiedz_2 = WYLICZENIE_WARTOSCI * 1024;
			WYLICZENIE_WARTOSCI = Math.Round(WYLICZENIE_WARTOSCI,2);
			
			label_wynik_odpowiedz_1.Text = WYLICZENIE_WARTOSCI.ToString("N2")+" "+ COMBOBOX_STRING_0;
			label_wynik_odpowiedz_1.AutoSize = true;
			label_wynik_odpowiedz_1.Left = 150;
			label_wynik_odpowiedz_1.Top = 120;
			this.Controls.Add(label_wynik_odpowiedz_1);
			
		if (COMBOBOX_STRING_0 == "KB")
		{
			label_wynik_odpowiedz_2.Text = WYLICZENIE_WARTOSCI.ToString("N2")+" "+ "KB";
		}
		else if (COMBOBOX_STRING_0 == "MB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "KB";
		}
		else if (COMBOBOX_STRING_0 == "GB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "MB";
		}
		else if (COMBOBOX_STRING_0 == "TB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "GB";
		}
		else if (COMBOBOX_STRING_0 == "PB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "TB";
		}
		else if (COMBOBOX_STRING_0 == "EB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "PB";
		}
		else if (COMBOBOX_STRING_0 == "ZB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "EB";
		}
		else if (COMBOBOX_STRING_0 == "YB")
		{
			label_wynik_odpowiedz_2.Text = odpowiedz_2.ToString("N2")+" "+ "ZB";
		}
			
			label_wynik_odpowiedz_2.AutoSize = true;
			label_wynik_odpowiedz_2.Left = 150;
			label_wynik_odpowiedz_2.Top = 145;
			this.Controls.Add(label_wynik_odpowiedz_2);

		}
		else
		{
			MessageBox.Show("Wprowadzona wartość nie jest liczbą.",  "Komunikat");
		}
	}	
	
	private void Oncombobox_wielokrotnosc_danych_Select(object sender, EventArgs ea)
	
	{
		COMBOBOX_STRING_0 = ((ComboBox)sender).SelectedItem.ToString(); 
		
	}
	
	public Okno()
	{
		this.Width=350;
		this.Height=273;
		this.Text = "PrzePoj"; //tytuł belki 
		
		// Menu w pionie
		
		MainMenu mm = new MainMenu();
		MenuItem miPlik = new MenuItem("Plik");
	
		MenuItem miPomoc = new MenuItem("Pomoc");
		MenuItem miWyjdz = new MenuItem("Wyjdź"); 
	
		miPomoc.Click += new EventHandler(OnPomoc);
		
		miWyjdz.Click +=new EventHandler(OnWyjdz);
		
		mm.MenuItems.Add(miPlik);
		miPlik.MenuItems.Add(miPomoc);
		miPlik.MenuItems.Add(miWyjdz);
		
		Menu = mm;
		
		// Label
		
		Label label_przy_combo = new Label();
		label_przy_combo.Text = "Wielokrotność pojemności: ";
		label_przy_combo.AutoSize = true;
		label_przy_combo.Left = 10;
		label_przy_combo.Top = 40;
		this.Controls.Add(label_przy_combo);
		
		Label label_przy_textBox = new Label();
		label_przy_textBox.Text = "Wielkość danych:";
		label_przy_textBox.AutoSize = true;
		label_przy_textBox.Left = 55;
		label_przy_textBox.Top = 80;
		this.Controls.Add(label_przy_textBox);
		
		Label label_wynik1 = new Label();
		label_wynik1.Text = "Wynik: ";
		label_wynik1.AutoSize = true;
		label_wynik1.Left = 108;
		label_wynik1.Top = 120;
		this.Controls.Add(label_wynik1);
		
		Label label_wynik2 = new Label();
		label_wynik2.Text = "Wynik: ";
		label_wynik2.AutoSize = true;
		label_wynik2.Left = 108;
		label_wynik2.Top = 145;
		this.Controls.Add(label_wynik2);

		
		// Combo
		
		combobox_wielokrotnosc_danych = new ComboBox();
		combobox_wielokrotnosc_danych.Items.AddRange
		(
		new object[]
		{
			"KB","MB", "GB", "TB", "PB", "EB", "ZB", "YB"
		}
		);
		combobox_wielokrotnosc_danych.Left = ((ClientSize.Width - combobox_wielokrotnosc_danych.Width) / 2)+45;
		combobox_wielokrotnosc_danych.Top = 36;
		combobox_wielokrotnosc_danych.DropDownWidth = 20; 
		combobox_wielokrotnosc_danych.SelectedIndexChanged += Oncombobox_wielokrotnosc_danych_Select;
		Controls.Add(combobox_wielokrotnosc_danych); 
		
		// textbox
		
		textBoxl =new TextBox();
		textBoxl.Top = 80; 
		textBoxl.Left = ((ClientSize.Width - textBoxl.Width) / 2)+ 35; 
		Controls.Add(textBoxl); 
		
		// button
		
		Button button_licz= new Button();
		button_licz.Text ="Ok"; 
		button_licz.Left = ((ClientSize.Width - button_licz.Width) / 2)-5; 
		button_licz.Top = (ClientSize.Height-55);
		button_licz.Click += new EventHandler(OnButtonLicz);
		
		this.Controls.Add(button_licz);
		
	}
	public static void Main()
	{
		Application.Run (new Okno());
	}
	
	/*
			FUNKCJE
	*/
	
	
	//Sprawdzanie czy dany ciąg znaków to liczba
		   
	static char Czy_to_jest_liczba (string czy_to_liczba)
	{
		int ile_liczb = new int ();
		ile_liczb = czy_to_liczba.Length;
		char liczba = new char();
		liczba = 'n';
		// kod ascii liczb to 0 = 48 a 9 = 57, ',' = 44
		for(int a = 0;a < ile_liczb;a++)
		{
		   if ((int)czy_to_liczba[a] >= 48 & (int)czy_to_liczba[a] <= 57|| (int)czy_to_liczba[a] == 44)
		   {
			   liczba = 't';
		   }
		   else
		   {
			   liczba = 'n';
			   a = ile_liczb;
		   }
		}
			   return liczba;
	}
	
	// Wyliczenie wyniku
	
	static double Liczenie_pojemnosci (string wielokrotnosc_danych, double dane)
	{
		double pojemnosc_fizyczna = new double();
		double pojemnosc_informatyczna = new double ();
		int mnoznik = new int();
		pojemnosc_fizyczna = 1;
		pojemnosc_informatyczna = 1;
		mnoznik = 1;
		
		if (wielokrotnosc_danych == "MB")
		{
			mnoznik = 2;
		}
		else if (wielokrotnosc_danych == "GB")
		{
			mnoznik = 3;
		}
		else if (wielokrotnosc_danych == "TB")
		{
			mnoznik = 4;
		}
		else if (wielokrotnosc_danych == "PB")
		{
			mnoznik = 5;
		}
		else if (wielokrotnosc_danych == "EB")
		{
			mnoznik = 6;
		}
		else if (wielokrotnosc_danych == "ZB")
		{
			mnoznik = 7;
		}
		else if (wielokrotnosc_danych == "YB")
		{
			mnoznik = 8;
		}
		
		for(int a = 0;a <mnoznik;a++)
		{
			pojemnosc_fizyczna *=1000;
			pojemnosc_informatyczna *=1024;
		}
		
		dane = (dane/pojemnosc_informatyczna)*pojemnosc_fizyczna;

		return dane;
		
	}
}
using autok.Models;
//-3 perec
AutokKezeloje kezelo = new();
kezelo.LoadFromTXT("jeladas.txt");
kezelo.Utolso();
kezelo.Elso();
//kezelo.Jeladasok();
kezelo.MaxSEbesseg();
kezelo.Tavolsag();
kezelo.WriteTXT();
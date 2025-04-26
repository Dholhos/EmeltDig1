using utemez.Models;

TaborKezelo kezelo = new();

//A 6. feladat nem sikerült és a 7. feladatban nem tudom, hogy lehetne megcsinálni az ellenörzést
//1 óra 22 perc 42 másodperc volt eddig megcsinálni

kezelo.LoadFromTXT("taborok.txt");
Console.WriteLine($"2. feladat\nAz adatok száma: {kezelo.OsszesTabor()}\nAz először rögzített tábor témája: {kezelo.ElsoTabor()}\nAz utoljára rögzített tábor témája : {kezelo.UtolsoTabor()}");
kezelo.ZeneiTaborok();
kezelo.LegtobenJelentkezdtek();
kezelo.Kiiratasa();
kezelo.Elmentes();
// See https://aka.ms/new-console-template for more information
//REFERENZIO I NAMESPACE O CON LO USING O LA CLASSE SPECIFICA CON IL NOME COMPLETO
//using Unicam.Paradigmi.Test.Models;

using System.Collections;
using System.Collections.Concurrent;
using Unicam.Paradigmi.Test.Models;

var persona = new Unicam.Paradigmi.Test.Models.Persona();
persona.Nome = "Lorenzo";
persona.Cognome = "Pompili";
persona.Età = 21;
//************************************************//

//DICHIARAZIONE DI UN ARRAY

string[] stagioni = new string[4];

stagioni[0] = "Primavera";
stagioni[1] = "Estate";
stagioni[2] = "Autunno";
stagioni[3] = "Inverno";
foreach(var stagione in stagioni)
{
    Console.WriteLine($"Ciclo sulla stagione {stagione}");
}
//*********************************************************

//PROVA PASSAGGIO PER VALORE / RIFERIMENTO
var miaEtà = 15;
var nome = "Lorenzo";
var cognome = "Pompili";
ModificaValore(miaEtà);
Console.WriteLine($"Ciao mi chiamo {nome} {cognome}. La mia età è : {miaEtà}");
ModificaValorePerRiferimento(ref miaEtà);
Console.WriteLine($"Ciao mi chiamo {nome} {cognome}. La mia età è : {miaEtà}");
int annoNascità = 0;
IsMaggiorenne(miaEtà, out annoNascità);
Console.WriteLine($"Sono nato nell'anno {annoNascità}");
//Console.ReadLine();

void ModificaValore(int età)
{
    età = 20;
}

void ModificaValorePerRiferimento(ref int età)
{
    età = 20;
}

bool IsMaggiorenne(int età, out int annoNascità)
{
    annoNascità = DateTime.Now.Year - età;
    return età >= 18;
}
//*********************************************//


//GESTIONE DI EVENTI//
ArrayList listaArticoli = CreaListaArticoli();

foreach(Articolo articolo in listaArticoli)
{
    articolo.QtaMagazzino -= 8;
}

ArrayList CreaListaArticoli()
{
    var lista = new ArrayList();
    for (int i = 0; i < 10; i++)
    {
        var articolo = new Articolo();
        articolo.CodiceArticolo = $"CODART{i:000}";
        articolo.Descrizione = $"DESCART{i:000}";
        Random rdm = new Random(30);
        articolo.QtaMagazzino = rdm.Next(10, 20);
        articolo.LivelloScortaMinima = articolo.QtaMagazzino / 2;
        articolo.SottoScortaEvent += Articolo_SottoScortaEvent;
        lista.Add(articolo);
    }
    return lista;
}

void Articolo_SottoScortaEvent(Articolo art, DateTime time)
{
    Console.WriteLine($"L'articolo {art.CodiceArticolo} è andato sotto scorta. QtaMagazzino : {art.QtaMagazzino} Livello Scorta Minimo : {art.LivelloScortaMinima}" );
}

//*********************************************//
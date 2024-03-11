// See https://aka.ms/new-console-template for more information
//REFERENZIO I NAMESPACE O CON LO USING O LA CLASSE SPECIFICA CON IL NOME COMPLETO
//using Unicam.Paradigmi.Test.Models;

using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Examples;
using Unicam.Paradigmi.Test.Models;

var examples = new List<IExample>();

//examples.Add(new InizializzazioneClassiExample());
//examples.Add(new GestioneEventiExample());
//examples.Add(new FileManagementExample());
//examples.Add(new JsonSerializerExample());
//examples.Add(new AdoNetExample());
examples.Add(new EntityFrameworkExample());



foreach (var example in examples)
{
    example.RunExample();
}

Console.ReadLine();

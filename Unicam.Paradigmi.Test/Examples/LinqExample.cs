using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Test.Examples
{
    public class LinqExample : IExample
    {
        public async Task RunExampleAsync()
        {
        }
        public void RunExample()
        {
            var ctx = new MyDbContext();

            Func<Dipendente, bool> queryPerCognome =
                (dipendente) => dipendente.Cognome == "Pompili";

            ctx.Dipendenti.Where(queryPerCognome);
            var maxDateNascita = ctx.Dipendenti.ToList()
                .Max(m => m.DataNascita);

            var minDateNascita = ctx.Dipendenti.ToList()
                .Min(m => m.DataNascita);

            var queryResult = ctx.Dipendenti
                .GroupBy(g => g.IdAzienda);

            foreach (var item in queryResult.ToList())
            {
                Console.WriteLine($"Azienda con codice {item.Key}");
                foreach(var dipendente in item.ToList())
                {
                    Console.WriteLine($"{dipendente.Cognome} {dipendente.Nome}");
                }
            }
        }

        public void Enumerazione(MyDbContext ctx)
        {

            IQueryable<Dipendente> query = ctx.Dipendenti
                .Where(w => w.IdDipendente == 1);

            bool filterByCompany = true;
            if (filterByCompany)
            {
                query = query.Where(w => w.IdAzienda == 1);
            }

            //Restituisci il primo
            Dipendente dip01 = query.FirstOrDefault();
            //Restituisce tutti i dipendenti che trova nella query
            List<Dipendente> listaDipendente = query.ToList();
            //Restituisce il primo, assicurandosi che nella query ci sia un solo risultato
            Dipendente dp02 = query.Single();
        }
    }
}

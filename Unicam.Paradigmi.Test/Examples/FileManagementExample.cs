﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Exceptions;
using Unicam.Paradigmi.Test.Models;

namespace Unicam.Paradigmi.Test.Examples
{
    public class FileManagementExample : IExample
    {

        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            string path = "Content\\alunni.csv";
            var listaAlunni = ReadAlunniFromCsv(path);
            //var listaAlunni = ReadAlunniCsvFromStream(path);
            var enumerableAlunni = ReadAlunniWithYield(path);
            foreach (var alunno in enumerableAlunni)
            {
                Console.WriteLine(alunno.Nome);
            }

            listaAlunni.Add(new Alunno()
            {
                Cognome = "Aggiunto",
                Nome = "Alunno",
                Matricola = "XXXXX",
                DataNascita = new DateTime(2000, 10, 10)
            });

            SaveAlunniInCsv(path, listaAlunni);


            Console.ReadLine();
        }

        private void SaveAlunniInCsv(string path, List<Alunno> alunni)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Nome;Cognome;Matricola;DataNascita");
            foreach (var alunno in alunni)
            {
                sb.AppendLine($"{alunno.Nome};{alunno.Cognome};{alunno.Matricola};{alunno.DataNascita:dd/MM/yyyy}");
            }
            System.IO.File.WriteAllText(path, sb.ToString());
        }

        private IEnumerable<Alunno> ReadAlunniWithYield(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    int i = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        if (i > 0)
                        {
                            yield return new Alunno(line);
                        }
                        i++;
                    }
                }
            }
        }
        private List<Alunno> ReadAlunniCsvFromStream(string path)
        {
            List<Alunno> list = new List<Alunno>();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    int i = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        if (i > 0)
                        {
                            list.Add(new Alunno(line));
                        }
                        i++;
                    }
                }
            }
            return list;
        }

        private List<Alunno> ReadAlunniFromCsv(string path)
        {
            //Leggo il file alunni.csv
            //Due opportunità : Path Assoluto
            //System.IO.File.ReadAllText("D:\\Progetti\\Unicam\\Unicam.Paradigmi\\Unicam.Paradigmi.Test\\Content\\alunni.csv");
            //Path Relativo
            var list = new List<Alunno>();
            //string contentAlunni = System.IO.File.ReadAllText("Content\\alunni.csv");
            if (File.Exists(path))
            {
                string[] righeAlunni = System.IO.File.ReadAllLines(path);
                int i = 0;
                foreach (var riga in righeAlunni)
                {
                    if (i > 0)
                    {
                        list.Add(new Alunno(riga));
                    }
                    i++;
                }
            }
            else
            {
                throw new FileErrorException("Impossibile aprire il path", path);
            }
            return list;
        }

    }
}
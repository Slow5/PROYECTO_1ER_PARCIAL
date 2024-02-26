using System;
using System.Collections.Generic;
using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers.interfaces;
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Services
{

    public class FinService : IfinService
    {

        private float meta;
        private bool metaAlcanzada = false;
        private static List<Transaction> transactions = new List<Transaction>();
        private float ingreso = 0;



        public void EstablecerMeta(float nuevaMeta)
        {
            meta = nuevaMeta;
        }

        public Finance ProcessFin(Income income)
        {
            float opcion = income.opcion;
            var finance = new Finance();
            var concepto = income.Concept;

            if (opcion == 1.0)
            {
                if (concepto.Equals("Ingreso"))
                {
                    ingreso += income.ingreso;

                    // Agregar la transacción nueva 
                    transactions.Add(new Transaction
                    {
                        Amount = income.ingreso,
                        Category = income.Category,
                        Concept = income.Concept,
                    });

                    finance.Index = ingreso;
//&& !metaAlcanzada
                    if (ingreso >= meta)
                    {
                        Console.WriteLine($"¡Felicidades Has alcanzado tu meta de {meta}!");
                        metaAlcanzada = true;
                    }
                }
                else if (concepto.Equals("Gasto"))
                {
                    var retiro = income.ingreso;

                    if (ingreso >= retiro)
                    {
                        ingreso -= retiro;

                        transactions.Add(new Transaction
                        {
                            Amount = retiro,
                            Category = income.Category,
                            Concept = income.Concept,
                        });

                        finance.Index = ingreso;
                    }
                    else
                    {

                    }
                }
            }

            return finance;
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
    }
}

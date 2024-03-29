using System;
using System.Collections.Generic;
using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers.interfaces;
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Services
{

    public class FinService : IfinService
    {

        public float meta;
        public float presupuesto;
        public bool metaAlcanzada = false;
        public static List<Transaction> transactions = new List<Transaction>();
        public float ingreso = 0;



        public void EstablecerMeta(float nuevaMeta)
        {
            meta = nuevaMeta;
        }
        public void EstablecerPresupuesto(float nuevoPresupuesto)
        {
            presupuesto = nuevoPresupuesto;
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

                    if (meta > 0 && ingreso >= meta)
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


                        if (ingreso < presupuesto)
                        {
                            double porcentaje = ((ingreso * 100) / presupuesto);
                            Console.WriteLine($"El límite de tu presupuesto está al % {porcentaje}");
                        }

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

using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers;
using PROYECTO.CORE.Managers.interfaces;
using PROYECTO.CORE.Services;
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.APP;

public static class Program
{
    public static void Main(String[] args)
    {
        float ingreso = 0;
        float opcion = 0;
        bool continuar = true;
        bool valor = false;


        var service = new FinService();
        var managers = new FinManager(service);

        while (continuar)
        {
            Console.WriteLine("=====❤✿ Menu ✿❤===== ");
            Console.WriteLine("[1] Realizar transacción");
            Console.WriteLine("[2] Estado Financiero");
            Console.WriteLine("[3] Establecer una meta");
            Console.WriteLine("[4] salir");
            Console.Write("Opcion (1-4): ");
            Single.TryParse(Console.ReadLine(), out opcion);

            if (opcion == 1.0f)
            {
                Console.Write("Ingresa la cantidad: ");
                Single.TryParse(Console.ReadLine(), out float amount);

                Console.WriteLine("Ingresa el número de la categoría: ");
                Console.WriteLine("[1]Entretenimiento");
                Console.WriteLine("[2]Alimentación");
                Console.WriteLine("[3]Transporte");
                Console.WriteLine("[4]Vivienda");
                Console.WriteLine("[5]Otro");
                int category = int.Parse(Console.ReadLine());
                string categoryIn = "";

                if(category == 1){
                    categoryIn = "Entretenimiento";
                }else if(category == 2){
                    categoryIn = "Alimentación";
                }else if(category == 3){
                    categoryIn = "Transporte";
                }else if(category == 4){
                    categoryIn = "Vivienda";
                }else if(category == 5){
                    categoryIn = "Otro";
                    Console.WriteLine("Ingresa la categoria: ");
                    categoryIn = Console.ReadLine();

                }


                Console.Write("Ingresa el concepto (Gasto/Ingreso): ");
                string concept = Console.ReadLine();

                if (concept.Equals("Gasto") && amount > ingreso)
                {
                    Console.WriteLine("¡NO TIENES SUFICIENTES FONDOS PARA REALIZAR LA TRANSACCIÓN!");
                    Console.WriteLine("Saldo actual: " + ingreso);
                }
                else
                {

                    var transaction = new Income
                    {
                        ingreso = amount,
                        opcion = 1.0f,
                        Category = categoryIn,
                        Concept = concept
                    };

                    var finance = managers.GetFinance(transaction);
                    ingreso = finance.Index;
                    
                    Console.WriteLine(concept.Equals("Gasto") ? "CANTIDAD RETIRADA CON ÉXITO" : "CANTIDAD INGRESADA CON ÉXITO");
                    Console.WriteLine("Saldo actual: " + ingreso);
                }
            }
            else if (opcion == 2.0f)
            {
                Console.WriteLine("=====❤✿ Transacciones ✿❤=====");
                foreach (var trans in managers.GetAll())
                {
                    Console.WriteLine($"Cantidad: {trans.Amount}, Categoría: {trans.Category}, Concepto: {trans.Concept}");
                }
            }
            else if (opcion == 3.0f)
            {
                Console.Write("Ingresa la cantidad de tu nueva meta: ");
                float nuevaMeta = float.Parse(Console.ReadLine());
                service.EstablecerMeta(nuevaMeta);
            }
            else if (opcion == 4.0f)
            {
                continuar = false;
            }
            else
            {
                Console.WriteLine("¡Selecciona una opción válida!");
            }
        }
    }

}





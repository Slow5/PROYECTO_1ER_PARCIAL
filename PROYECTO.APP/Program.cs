using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers;
using PROYECTO.CORE.Managers.interfaces;
using PROYECTO.CORE.Services;
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.APP;

public static class Program {
    public static void Main(String[]args){
        
        List<Transaction> transactions = new List<Transaction>();

        float dinero = 0;
        float opcion = 0;

        bool valor = false;

        float ingreso = 0;
        string? categoria = "";
        string? con = "";


        bool continuar = true;

        while(continuar){

        Console.WriteLine("Opciones: ");
        Console.WriteLine("1- Transacciones");
        Console.WriteLine("2- Ingresar Saldo");
        Console.WriteLine("3- Retirar Saldo");
        Console.WriteLine("4- Estado Financiero");
        Console.WriteLine("5- Metas y presupuestos");
        Console.WriteLine("6- salir");
        Console.Write("Opcion :");
        Single.TryParse(Console.ReadLine(), out opcion);

        if(opcion == 1.0f){
            
        // Nueva opción para ingresar transacciones
        Console.Write("Ingresa la cantidad: ");
        Single.TryParse(Console.ReadLine(), out float amount);

        Console.Write("Ingresa la categoría: ");
        string category = Console.ReadLine();

        Console.Write("Ingresa el concepto: ");
        string concept = Console.ReadLine();
        
        if(concept.Equals("Gasto")){
                valor = false;
            }else if(concept.Equals("Ingreso")){
                valor = true;
            }else{
                valor = false;
            }

        var transaction = new Income {
            ingreso = amount, 
            opcion = 1.0f,  // Asignamos 1.0 para indicar un ingreso
            Category = category,
            Concept = valor
        }; 

        var tran = new Transaction{
            Amount = amount, 
            Category = category,
            Concept = valor
        }; 

        var service = new FinService();
        var managers = new FinManager(service);

        // Procesar la transacción y actualizar el ingreso
        var finance = managers.GetFinance(transaction);

        ingreso = finance.Index;

        Console.WriteLine("Transacción ingresada correctamente.");
        
        // Imprimir la lista de transacciones después de cada transacción
        Console.WriteLine("Lista de Transacciones:");

        foreach (var trans in service.GetAllTransactions()) {
            Console.WriteLine($"Cantidad: {trans.Amount}, Categoría: {trans.Category}, Concepto: {(trans.Concept ? "Ingreso" : "Gasto")}");
        }

        }else if(opcion == 2.0f){

            Console.Write("Ingresa dinero: ");
            Single.TryParse(Console.ReadLine(), out dinero);
            var salary = new Income{ingreso = dinero, opcion = 1.0f};
            var service = new FinService();
            var managers = new FinManager(service);
            Finance fin = managers.GetFinance(salary);
                
            ingreso = ingreso + fin.Index;

        }else if(opcion == 3.0f){

            Console.Write("Cantidad a retirar: ");
            Single.TryParse(Console.ReadLine(), out dinero);

            var salary = new Income{ingreso = ingreso, opcion = 3.0f, retiro = dinero};
            var service = new FinService();
            var managers = new FinManager(service);
            Finance fin = managers.GetFinance(salary);

            if(ingreso >= dinero){
                Console.WriteLine("Cantidad Retirada");
                ingreso = fin.Index;
                Console.WriteLine("Saldo actual: " + ingreso);
            }else{
                Console.WriteLine("Cantidad Insuficiente");
            }

        }else if(opcion == 4.0f){
            

            var service = new FinService();
            var managers = new FinManager(service);
            

            Console.WriteLine("Lista de Transacciones:");
            foreach (var trans in managers.GetAll())
            {
                Console.WriteLine($"Cantidad: {trans.Amount}, Categoría: {trans.Category}, Concepto: {(trans.Concept ? "Ingreso" : "Gasto")}");
            }

        }else if(opcion == 5.0f){

        }else if(opcion == 6.0f){
            continuar = false;
        }else {
            Console.WriteLine("Opcion no disponible");
        }
    }
}
}


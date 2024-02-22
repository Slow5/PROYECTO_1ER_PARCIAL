using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers;
using PROYECTO.CORE.Services; 

namespace PROYECTO.APP;

public static class Program
{
    public static void Main(String[]args)
    {
        float dinero = 0;
        float opcion = 0;
        float ingreso = 0;
        //1-Transacciones
        //a---Ingresar
        //b---Gastos
        //c---Ingresar Servicio
        //d---Retirar

        //2-consultar saldo y estado financiero 
        //3-Metas y presupuestos

        bool continuar = true;
        while(continuar){

        Console.WriteLine("Opciones: ");
        Console.WriteLine("1- Transacciones");
        Console.WriteLine("2- Saldo y estado Financiero");
        Console.WriteLine("3- Metas y rpesupuestos");
        Console.WriteLine("4- Salir");
        Single.TryParse(System.Console.ReadLine(), out opcion);
        
        if(opcion == 1.0f){
            
            float op = 0;
            Console.WriteLine("Transacciones");
            System.Console.Write("Opciones: ");
            Console.WriteLine("1- Ingresar Saldo: ");
            Console.WriteLine("2- Mostrar Saldo: ");
            Console.WriteLine("3- Retirar Saldo");
            Console.WriteLine("4- Gastos");
            Single.TryParse(System.Console.ReadLine(), out op);

            if(op == 1.0f){
                System.Console.Write("Ingresa dinero: ");
                Single.TryParse(System.Console.ReadLine(), out dinero);

                var salary = new Income{money = dinero, opcion = 1.0f};
                var service = new FinService();
                var managers = new FinManager(service);
                Finance fin = managers.GetFinance(salary);
                
                ingreso = ingreso + fin.Index;

            }else if(op == 2.0f){

                var salary = new Income{money = ingreso, opcion = 2.0f};
                var service = new FinService();
                var managers = new FinManager(service);
                Finance fin = managers.GetFinance(salary);

                //Console.WriteLine(fin.cadena);
            }else if(op == 3.0f){
                
                System.Console.Write("Cantidad a retirar: ");
                Single.TryParse(System.Console.ReadLine(), out dinero);

                var salary = new Income{money = ingreso, opcion = 3.0f, retiro = dinero};
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
                
            }

        }else if(opcion == 4.0f){
            continuar = false;
        }

        else{
            Console.WriteLine("Opcion no disponible");
        }
    }
}
}


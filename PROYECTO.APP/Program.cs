using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers;
using PROYECTO.CORE.Services; 

namespace PROYECTO.APP;

public static class Program
{
    public static void Main(String[]args)
    {
        float dinero = 0;
        
        System.Console.Write("Ingresa dinero: ");
        Single.TryParse(System.Console.ReadLine(), out dinero);

        var salary = new Income{money = dinero};
        var service = new FinService();
        var managers = new FinManager(service);

        //Core.Entites.ISR isr = managers.Getisr(salary);
        Finance fin = managers.GetFinance(salary);
        //System.Console.WriteLine($"BMI {bmi.Index} Type {bmi.BmiType}");
        System.Console.WriteLine($"ISR: {fin.Index}");
    }
}


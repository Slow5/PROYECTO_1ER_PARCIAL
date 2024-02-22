using System.Data;
using System.Runtime;
using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers.interfaces; 
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Services; 

public class FinService : IfinService {
    float ingreso = 0;
    float opcion = 0;
    
    // Nueva lista para almacenar transacciones
    List<Transaction> transactions = new List<Transaction>();

    public Finance ProcessFin(Income income){
                 
        opcion = income.opcion; 
        var finance = new Finance();

        if(opcion == 1.0){

            ingreso = income.ingreso + ingreso;    

            // Agregar la transacción a la lista
            transactions.Add(new Transaction{
            Amount =  income.ingreso,
            Category = income.Category, 
            Concept = income.Concept,
            });

            finance.Index = ingreso;
            
        }else if(opcion == 2.0){

            Console.WriteLine("Tu saldo es " + income.ingreso);
            
        }else if(opcion == 3.0){
            var ingresos = income.ingreso; 
            var retiro = income.retiro;

            if(ingresos >= retiro){
                finance.Index = ingresos - retiro;
            }else{
                Console.WriteLine("Error");
            }
            
        }
            return finance;
    }
    
    // Nuevo método para obtener todas las transacciones
    public List<Transaction> GetAllTransactions()
    {   
        return transactions;
    }
}

using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers.interfaces; 
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Services; 

public class FinService : IfinService {
    float ingreso = 0;
    float opcion = 0;
    public float Ingreso => ingreso;

    public Finance ProcessFin(Income income){
                 
        opcion = income.opcion; 
        var finance = new Finance();

        if(opcion == 1.0){

            ingreso = income.money + ingreso;    
            finance.Index = ingreso;
            
        }else if(opcion == 2.0){

            Console.WriteLine("Tu saldo es " + income.money);
            
        }else if(opcion == 3.0){
            var ingresos = income.money; 
            var retiro = income.retiro;

            if(ingresos >= retiro){
                finance.Index = ingresos - retiro;
            }else{
                Console.WriteLine("Error");
            }
            
        }
            return finance;
    }
}

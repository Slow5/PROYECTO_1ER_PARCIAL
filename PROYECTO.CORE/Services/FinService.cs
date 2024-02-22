using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Managers.interfaces; 
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Services; 

public class FinService : IfinService {
    public Finance ProcessFin(Income income){
        var finance = new Finance();
        float ingreso = 0;

        ingreso = income.money + ingreso;    
        finance.Index = ingreso; 
        
        return finance;
    }
}

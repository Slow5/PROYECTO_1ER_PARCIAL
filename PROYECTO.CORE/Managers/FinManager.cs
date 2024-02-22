using PROYECTO.CORE.Entities; 
using PROYECTO.CORE.Managers.interfaces;
using PROYECTO.CORE.Services.interfaces;

namespace PROYECTO.CORE.Managers;

public class FinManager : IfinManager
{
    private readonly IfinService _service;
    public FinManager(IfinService service){
        _service = service;
    }

    public Finance GetFinance(Income income){
        return _service.ProcessFin(income);
    }
}
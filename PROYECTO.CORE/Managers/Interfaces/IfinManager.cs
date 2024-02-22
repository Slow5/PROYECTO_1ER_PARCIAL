using PROYECTO.CORE.Entities;

namespace PROYECTO.CORE.Managers.interfaces; 

public interface IfinManager
{
    Finance GetFinance (Income income);
}
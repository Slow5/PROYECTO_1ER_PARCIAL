using PROYECTO.CORE.Entities;

namespace PROYECTO.CORE.Managers.interfaces; 

public interface IfinManager
{
    List<Transaction> GetAll();
    Finance GetFinance (Income income);
}
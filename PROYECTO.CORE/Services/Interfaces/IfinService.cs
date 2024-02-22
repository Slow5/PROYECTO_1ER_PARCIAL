using PROYECTO.CORE.Entities;

namespace PROYECTO.CORE.Services.interfaces;

public interface IfinService
{
    List<Transaction> GetAllTransactions();
    Finance ProcessFin(Income income);
}
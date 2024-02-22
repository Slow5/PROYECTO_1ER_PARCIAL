using PROYECTO.CORE.Entities;

namespace PROYECTO.CORE.Services.interfaces;

public interface IfinService
{
    Finance ProcessFin(Income income);
}
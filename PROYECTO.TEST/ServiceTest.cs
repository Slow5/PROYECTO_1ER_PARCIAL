using PROYECTO.CORE.Entities;
using PROYECTO.CORE.Services;

namespace PROYECTO.TEST;

public class ServiceTest
{
    [Fact]
    public void EstablecerMeta_EstableceMetaCorrectamente()
    {
        var expected = 1000;
        // Arrange
        var finService = new FinService();

        // Act
        finService.EstablecerMeta(1000);

        // Assert
        Assert.Equal(1000, finService.meta);
    }

    [Fact]
    public void EstablecerPresupuesto_EstablecePresupuestoCorrectamente()
    {
        
        var finService = new FinService();
        
        finService.EstablecerPresupuesto(500);
        
        Assert.Equal(500, finService.presupuesto);
    }

    [Fact]
    public void ProcessFin_OpcionIngreso_AumentaIngresoYAgregaTransaccion()
    {
        
        var finService = new FinService();
        
        var ingreso = new Income { opcion = 1.0f, Concept = "Ingreso", ingreso = 200, Category = "Salario" };
        
        var resultado = finService.ProcessFin(ingreso);
        
        Assert.Equal(200, finService.ingreso);
        Assert.Equal(200, resultado.Index);
        Assert.Equal(1, finService.GetAllTransactions().Count);
    }

    [Fact]
    public void ProcessFin_OpcionGasto_DisminuyeIngresoYAgregaTransaccion()
    {
        var finService = new FinService { ingreso = 300 };
        
        var gasto = new Income { opcion = 1.0f, Concept = "Gasto", ingreso = 50, Category = "Comestibles" };
        
        var resultado = finService.ProcessFin(gasto);
        
        Assert.Equal(250, finService.ingreso);
        Assert.Equal(250, resultado.Index);
        Assert.Equal(1, finService.GetAllTransactions().Count);
    }
}
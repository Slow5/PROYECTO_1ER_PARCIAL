namespace PROYECTO.CORE.Entities; 

public class Income {
    public float ingreso {get; set;}
    public float opcion {get; set;}
    public float retiro{get; set;}

    public string? Category { get; set; } // Nueva propiedad
    public string? Concept { get; set; }  // Nueva propiedad
}
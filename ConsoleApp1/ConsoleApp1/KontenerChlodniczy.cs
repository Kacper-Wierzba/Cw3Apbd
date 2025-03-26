using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class KontenerChlodniczy(
    float massOfContainer,
    float height,
    float depth,
    float maxVolumeInKg,
    float temperature)
    : Kontener('C', massOfContainer, height, depth, maxVolumeInKg)

{
    public float Temperature { set; get; } = temperature;
    
    private string? cargotype = null;

    public string? Cargotype
    {
        get => cargotype;
        set
        {
            if(cargotype == null)
                cargotype = value;
        }
    }

    public void Fill(string type, float mass, float temperature)
    {
        if(Temperature < temperature)
            throw new TooLowTemperatureException("Container temperature is: "+Temperature+" trying to add: "+temperature);
        Cargotype = type;
        if(type != Cargotype)
            throw new TypeMismatchException("Cargotype: "+Cargotype+" is not the same as: "+type);
        BaseFillLogic(mass);
    }
    
    
    public override void Empty()
    {
        MassOfCargo = 0;
        cargotype = null;
    }
}

internal class TooLowTemperatureException(string msg): Exception(msg);
internal class TypeMismatchException(string msg): Exception(msg);
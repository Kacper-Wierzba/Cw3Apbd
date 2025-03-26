namespace ConsoleApp1;


public class KontenerPlyn(float massOfContainer, float height, float depth, float maxVolumeInKg)
    : Kontener('L', massOfContainer, height, depth, maxVolumeInKg)
{
    
    public override void Empty()
    {
        throw new NotImplementedException();
    }
    
    protected override void Zaladunek(Cargo cargo)
    {
        MassWithCargo += cargo.Mass;
    }
}
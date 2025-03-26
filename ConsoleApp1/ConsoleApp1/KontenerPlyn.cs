namespace ConsoleApp1;


public class KontenerPlyn(float massOfContainer, float height, float depth, float maxVolumeInKg)
    : Kontener('L', massOfContainer, height, depth, maxVolumeInKg), IHazardNotifier
{
    
    public override void Empty()
    {
        MassOfCargo = 0;
    }
    
    protected override void Zaladunek(Cargo cargo)
    {
        if((cargo.Hazardous && cargo.Mass > maxVolumeInKg*0.5) || cargo.Mass > maxVolumeInKg*0.9)
            NotifyOfRisk(id:this.SerialNumber);
    }

    public void NotifyOfRisk(string id)
    {
        Console.WriteLine("Risky operation detected at : " + id);
    }
}
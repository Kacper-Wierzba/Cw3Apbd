namespace ConsoleApp1;


public class KontenerPlyn(
    float massOfContainer,
    float height,
    float depth,
    float maxVolumeInKg)
    : Kontener('L', massOfContainer, height, depth, maxVolumeInKg), IHazardNotifier
{
    
    public override void Empty()
    {
        MassOfCargo = 0;
    }
    
    public void Fill(string type, float mass, bool hazard)
    {
        BaseFillLogic(mass);
        mass = MassOfCargo;
        if((hazard && mass > maxVolumeInKg*0.5) || mass > maxVolumeInKg*0.9)
            NotifyOfRisk(id:this.SerialNumber);
    }
    

    public void NotifyOfRisk(string id)
    {
        Console.WriteLine(id+" was assigned cargo with too much volume");
    }
}
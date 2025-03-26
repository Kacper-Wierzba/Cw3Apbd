namespace ConsoleApp1;

public class KontenerGaz(
    float massOfContainer,
    float height,
    float depth,
    float maxVolumeInKg,
    float maxPressure)
    : Kontener('G', massOfContainer, height, depth, maxVolumeInKg), IHazardNotifier
{
    public float Pressure{set; get;} = maxPressure;

    public override void Empty()
    {
        MassOfCargo = (float)(MassOfCargo * 0.05);
    }

    public void Fill(string type, float mass, float pressure)
    {
        BaseFillLogic(mass);
        if(pressure>Pressure)
            NotifyOfRisk(this.SerialNumber);
    }

    public void NotifyOfRisk(string id)
    {
        Console.WriteLine(id+" was assigned cargo with too much pressure");
    }
}
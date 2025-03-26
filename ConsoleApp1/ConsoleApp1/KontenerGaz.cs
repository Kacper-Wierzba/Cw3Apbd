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
    public float pressurenow=0;

    public override void Empty()
    {
        MassOfCargo = (float)(MassOfCargo * 0.05);
    }

    public void Fill(string type, float mass, float pressure)
    {
        BaseFillLogic(mass);
        var pres = pressure + pressurenow;
        if(pres>Pressure)
            NotifyOfRisk(this.SerialNumber);
        pressurenow += pressure;
    }

    public void NotifyOfRisk(string id)
    {
        Console.WriteLine(id+" was assigned cargo with too much pressure");
    }
}
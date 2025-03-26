using System.Text;

namespace ConsoleApp1;

public class Kontenerowiec(float maxSpeed, float maxVolumeOfContainers, float maxMassOfContainers)
{
    List<Kontener> kontenery = new();
    
    public float MaxSpeed { set; get; } = maxSpeed;

    public float MaxVolumeOfContainers { set; get; } = maxVolumeOfContainers;
    public float MaxMassOfContainers { set; get; } = maxMassOfContainers;

    private float currentmass = 0;

    public void Load(Kontener kontener)
    {
        if(kontenery.Count + 1 > MaxVolumeOfContainers)
            throw new ContainerCountExceededException("MaxVolumeOfContainers would be exceeded");
        float mass = kontener.MassOfCargo + kontener.MassOfContainer;
        if((mass+currentmass)>MaxMassOfContainers)
            throw new TooMuchWeightException("adding new container would exceed max supported mass of cargo");
        kontenery.Add(kontener);
        currentmass += mass;
    }
    
    public void Load(List<Kontener> konteners)
    {
        if(kontenery.Count + konteners.Count > MaxVolumeOfContainers)
            throw new ContainerCountExceededException("MaxVolumeOfContainers would be exceeded");
        float mass = konteners.Select(a=>a.MassOfCargo+a.MassOfContainer).Sum();
        if((mass+currentmass)>MaxMassOfContainers)
            throw new TooMuchWeightException("adding these containers would exceed max supported mass of cargo");
        kontenery.AddRange(konteners);
        currentmass += mass;
    }

    public void Unload(string serialNumber)
    {
        kontenery.Remove(kontenery.Find(k => k.SerialNumber == serialNumber));
    }

    public void Exchange(Kontener kontener, string serialNumber)
    {
        var found = kontenery.Find(k => k.SerialNumber == serialNumber);
        int index = kontenery.IndexOf(found);
        kontenery[index] = kontener;
    }

    public void Transfer(Kontenerowiec ship, string serialNumber)
    {
        var found = kontenery.Find(k => k.SerialNumber == serialNumber);
        kontenery.Remove(found);
        ship.Load(found);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine("Kontenerowiec: Maxspeed: "+maxSpeed+" MaxVolumeOfContainers: "+MaxVolumeOfContainers+" MaxMassOfContainers: "+MaxMassOfContainers);
        sb.AppendLine("cargo: ");
        foreach (var kontener in kontenery)
        {
            sb.AppendLine(kontener.ToString());
        }
        return sb.ToString();
    }
}

internal class TooMuchWeightException(string msg) : Exception(msg);
internal class ContainerCountExceededException(string msg) : Exception(msg);

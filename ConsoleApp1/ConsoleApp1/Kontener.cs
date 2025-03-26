namespace ConsoleApp1;


public abstract class Kontener
{
    private static int nextnum = 1;
    public float MassOfCargo{set; get;}
    public float MassOfContainer{set; get;}
    public float Height{set; get;}
    public float Depth{set; get;}
    public float MaxVolumeInKg{set; get;}
    public Char  Type { get;}
    
    public String SerialNumber { get; }

    protected Kontener(char type, float massOfContainer, float height, float depth, float maxVolumeInKg)
    {
        Type = type;
        SerialNumber = CreateSerialNumber();
        
        
        this.MassOfCargo = 0;
        this.MassOfContainer = massOfContainer;
        this.Height = height;
        this.Depth = depth;
        this.MaxVolumeInKg = maxVolumeInKg;
    }
    
    private string CreateSerialNumber()
    {
        return ("KON-"+Type+"-"+Kontener.nextNum);
    }
    
    private static int nextNum => nextnum++;

    public abstract void Empty();
    
    private void DontOverflow()
    {
        if(MassOfCargo>MaxVolumeInKg)
            throw new OverfillException("Maximum volume: " + MaxVolumeInKg+" was exceeded");
    }
    
    protected void BaseFillLogic(float Mass)
    {
        MassOfCargo+=Mass;
        DontOverflow();
    }

    public override string ToString()
    {
        return SerialNumber + " mass of cargo: " + MassOfCargo + " max volume: "+MaxVolumeInKg+" mass of bare container: " + MassOfContainer + " depth: "+Depth+" height: "+Height;
    }
}
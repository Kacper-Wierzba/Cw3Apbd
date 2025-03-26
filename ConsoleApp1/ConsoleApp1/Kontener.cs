namespace ConsoleApp1;


public abstract class Kontener
{
    private static int nextnum = 1;
    public float MassWithCargo{set; get;}
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
        
        
        this.MassWithCargo = massOfContainer;
        this.MassOfContainer = massOfContainer;
        this.Height = height;
        this.Depth = depth;
        this.MaxVolumeInKg = maxVolumeInKg;
    }
    
    private string CreateSerialNumber()
    {
        return ("KON-"+Type+"-"+Kontener.nextNum);
    }
    
    private static int nextNum
    {
        set
        {
            throw new Exception("cant change automated field");
        }
        get
        {
            return nextnum++;
        }
    }
    
    abstract public void Empty();
    abstract protected void Zaladunek(Cargo cargo);

    private void DontOverflow(float Mass)
    {
        if(Mass>MaxVolumeInKg)
            throw new OverfillException("Maximum volume is " + MaxVolumeInKg);
    }
    
    public void Fill(Cargo cargo)
    {
        DontOverflow(cargo.Mass);
        Zaladunek(cargo);
    }
    
}
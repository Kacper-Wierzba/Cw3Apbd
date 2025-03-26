namespace ConsoleApp1;


public abstract class Kontener
{
    public required float MassWithCargo{set; get;}
    public required float MassOfContainer{set; get;}
    public required float Height{set; get;}
    public required float Depth{set; get;}
    public required float MaxVolumeInKg{set; get;}
    public Char  Type { get;}
    
    public String SerialNumber { get; }

    protected Kontener(char type)
    {
        Type = type;
        SerialNumber = CreateSerialNumber();
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
            return nextNum++;
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
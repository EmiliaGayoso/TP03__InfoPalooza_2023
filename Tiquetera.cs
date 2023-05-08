class Tiquetera
{
public int UltimoId{get;set;}=1;

public Tiquetera(int ID)
{
    UltimoId=ID;
}
public static int DevolverUltimoID()
{
    int devolver=1;
    return devolver;
    devolver++;
}

}
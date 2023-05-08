class Cliente
{

    public string Nombre{get;private set;}
    public int DNI{get;private set;}
    public string Apellido{get;private set;}
    public DateTime FechaInscripcion{get;set;}
    public int TipoEntrada{get;set;}
    public double TotalAbonado{get;set;}
    
    public Cliente(string nom, int dni,string apellido, int tipEntr, double totalAbo)
    {
        Nombre=nom;
        DNI=dni;
        Apellido=apellido;
        TipoEntrada=tipEntr;
        TotalAbonado=totalAbo;
    
    }
    public bool CambiarEntrada(int precioEnt, double entradaCambio)
    {
        bool puede=false;

        if(entradaCambio>precioEnt)
        {
            puede=true;
        }
        return puede;

    }
}
    
    
    
    
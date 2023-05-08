namespace TP03__InfoPalooza_2023;
class Program
{
    static void Main(string[] args)
    {
        string nom,ape;
        int tipEntr, opcion=0,dni,cantClientes=0,i=0,idABuscar,entradaCambio;
        double totalAbo,pago,total=0;

        double[]entrada=new double[]{15000,30000,10000,40000};
        int[]cantEntradas=new int[]{0,0,0,0};

        Dictionary<int, Cliente> DicCliente = new Dictionary<int, Cliente>();
        do
        {
            Menu();
            opcion=IngresarEnteroPositivo("Ingrese opcion:",1,4);
            
            switch(opcion)
            {
                case 1:
                    dni=IngresarEnteroPositivo("Ingrese DNI:",1000000,99999999);
                    nom=IngresarCadena("Nombre:");
                    ape=IngresarCadena("Apellido:");
                
                    Console.Clear();

                    MenuEntradas();
                    tipEntr=IngresarEnteroPositivo("Comprar Entrada(1-4):",1,4);
                    cantEntradas[tipEntr-1]++;
                    pago=IngresarDouble("Abone:");
                    totalAbo=entrada[tipEntr-1];
                    Console.WriteLine("Vuelto:"+ Pagar(pago,entrada,tipEntr));

                    CargarCliente(nom,dni,ape,tipEntr,totalAbo,DicCliente);
                    i++;
                    cantClientes++;
                    total=total+totalAbo;

                break;

                case 2:

                if(DicCliente.ContainsKey(1))
                {
                Console.WriteLine("CANTIDAD CLIENTES:"+cantClientes);

                Console.WriteLine("Dia 1");
                Console.WriteLine("Porcentaje:"+Porcentaje(cantEntradas[0],cantClientes)+"%");
                Console.WriteLine("Recaudado:"+entrada[0]*cantEntradas[0]);
                
                Console.WriteLine("Dia 2");
                Console.WriteLine("Porcentaje:"+Porcentaje(cantEntradas[1],cantClientes)+"%");
                Console.WriteLine("Recaudado:"+entrada[1]*cantEntradas[1]);
                
                Console.WriteLine("Dia 3");
                Console.WriteLine("Porcentaje:"+Porcentaje(cantEntradas[2],cantClientes)+"%");
                Console.WriteLine("Recaudado:"+entrada[2]*cantEntradas[2]);
                
                Console.WriteLine("Full Pass");
                Console.WriteLine("Porcentaje:"+Porcentaje(cantEntradas[3],cantClientes)+"%");
                Console.WriteLine("Recaudado:"+entrada[3]*cantEntradas[3]);

                Console.WriteLine("TOTAL:"+total);

                } else { Console.WriteLine("Aún no se anotó nadie");}

                break;

                case 3:

                idABuscar=IngresarEnteroPositivo("Ingrese ID quere INFO:",1,cantClientes);
                if (DicCliente.ContainsKey(idABuscar))
                {
                    Console.WriteLine(DicCliente[idABuscar]);
                }
                else
                {
                    Console.WriteLine("“No se encuentra el ID”");
                }

                break;

                case 4:
                idABuscar=IngresarEnteroPositivo("CAMBIAR ENTRADA!Ingrese ID:",1,cantClientes);
                if (DicCliente.ContainsKey(idABuscar))
                {
                    entradaCambio=IngresarEnteroPositivo("Ingrese el tipo de la nueva entrada",1,4);
                    pago=IngresarDouble("Abone:");
                    Console.WriteLine("Vuelto:"+ Pagar(pago,entrada,entradaCambio));
                    
                    if(DicCliente[idABuscar].CambiarEntrada(entradaCambio,pago))
                    {
                        DicCliente[idABuscar].TipoEntrada=entradaCambio;
                        DicCliente[idABuscar].TotalAbonado=entrada[entradaCambio-1];
                        DicCliente[idABuscar].FechaInscripcion=DateTime.Today;
                    }

                }
                else{Console.WriteLine("No se encuentra el ID");}
                
                break;
                
                case 5:
                Console.WriteLine("Chau!");
                break;
                
            }
            
            Console.ReadKey();
            Console.Clear();

        }while(opcion!=5);
    }
    static void CargarCliente(string nom, int dni,string ape, int tipEntr, double totalAbo,Dictionary<int,Cliente>DicCliente)
    {
        Cliente a = new Cliente(nom, dni, ape, tipEntr, totalAbo);
        int ID=Tiquetera.DevolverUltimoID();
        DicCliente.Add(ID, a);
        Console.WriteLine("ID:"+ID+". Se cargo cliente");
    }
    //menus
    static void Menu()
    {
        Console.WriteLine("1.Nueva Inscripción\n2.Obtener Estadísticas del Evento\n3.Buscar Cliente\n4.Cambiar entrada de un Cliente\n5.Salir");
    }
    static void MenuEntradas()
    {
         Console.WriteLine("Día 1:$15000\nDia 2:$30000\nDia 3:$10000\nFull Pass:$40000");
    }
    //ingresos
    static int IngresarEnteroPositivo(string mensaje,int desde,int hasta)
    {
        Console.Write(mensaje);
        int num = int.Parse(Console.ReadLine());
        while (VerificarNumero(num,desde,hasta))
        {
            Console.Write("ERROR!"+mensaje);
            num = int.Parse(Console.ReadLine());
        }
        return num;
    }
    static string IngresarCadena(string mensaje)
    {
        Console.Write(mensaje);
        string cadena = Console.ReadLine();
        return cadena;
    }
    static double IngresarDouble(string mensaje)
    {
        Console.Write(mensaje);
        double dec=double.Parse(Console.ReadLine());
        return dec;
    }
    //verificacion
    static bool VerificarNumero(int num,int desde,int hasta)
    {
        bool ver=true;
        if(num<desde || num<=hasta)
        {
            ver=false; 
        }
        return ver;
    }
    //funciones +
    static double Pagar(double pago,double[]entradas,int tipEntr)
    {
        int i=tipEntr-1;
        double vuelto=pago-entradas[i];
        return vuelto;
    }
    static double Porcentaje(int num,int total)
    {
        double porcentaje=num*100/total;
        return porcentaje;
    }
}

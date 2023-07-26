using System;
using System.Collections.Generic;
using System.Threading;
class Program {
    public static Dictionary<long, string> directorio = new Dictionary<long, string>();   
    public static List<int> importantes = new List<int>();
    static void Main() {
        int opcion;

    do
    {
        mostrarMenu();
        opcion = pedirOpcion();

        switch (opcion)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("".PadRight(60) + "AÑADIR ENTRADA\n");
                añadirEntrada();
                break;
            case 2:
               Console.Clear();
               Console.WriteLine("".PadRight(60) + "VER ENTRADAS\n");
               mostrarEntrada();
               Thread.Sleep(6000);
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("".PadRight(60) + "MARCAR COMO IMPORTANTE\n");
                mostrarEntrada();
                MarcarImportante();
                
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("".PadRight(60) + "ELIMINAR ENTRADA\n");
                mostrarEntrada();
                EliminarEntrada();
                
                break;
        }


    } while (opcion != 5);
    

    }



    static void mostrarMenu() {
        
        Console.WriteLine("*********************************");
        Console.WriteLine("*        Menú de opciones       *");
        Console.WriteLine("*********************************");
        Console.WriteLine("*1. Agregar entrada             *");
        Console.WriteLine("*2. Mostrar entradas            *");
        Console.WriteLine("*3. Marcar como importante      *");
        Console.WriteLine("*4. Eliminar entrada            *");
        Console.WriteLine("*5. Salir                       *");
        Console.WriteLine("*********************************");
    
    }

    static int pedirOpcion(){
        try
        {
            Console.Write("\nIngrese la opcion: ");    
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception)
        {
            Console.WriteLine("opcion no valida");
            return 0;
        }
        
    }

    static void añadirEntrada(){

        Console.Write("Ingrese el nombre: ");
        string? nombre = Console.ReadLine();
        Console.Write("Ingrese el número: ");
        long numero = Convert.ToInt64(Console.ReadLine());
        directorio.Add(numero,nombre??"no definido");
        
    }

    static void mostrarEntrada(){
        
        string verDirectorio ="".PadRight(50) + "Id".PadRight(16) + "Nombre".PadRight(16) +
        "Numero\n" + "".PadRight(50) + "--------------------------------------\n" ;
        int id = 0;
        foreach(KeyValuePair<long,string> par in directorio){
            ++id;
            foreach(int idImportante in importantes){
                if( id == idImportante){
                    verDirectorio += ("".PadRight(50) + "\u001b[33m" + $"{id}".PadRight(16) + "¡Importante!\u001b[0m\n");
            }    
            }
            
            verDirectorio += ("".PadRight(50) + $"{id}".PadRight(16) + $"{par.Value}".PadRight(16) + $"{par.Key}\n");

        }
        Console.WriteLine(verDirectorio);
    }
    
    static void MarcarImportante(){
        Console.Write("Ingrese el id del contacto: ");
        int importante = Convert.ToInt32(Console.ReadLine());
        importantes.Add(importante);   
        Console.WriteLine("el contacto se ha añadido a importantes");
    }
    static void EliminarEntrada(){
        Console.Write("Ingrese el id del contacto a eliminar: ");
        int aEliminar = Convert.ToInt32(Console.ReadLine());
        importantes.Remove(aEliminar);   
        List<long> keys = new List<long>(directorio.Keys);
        directorio.Remove(keys[aEliminar - 1]);
        Console.WriteLine("el contacto se ha eliminado");
    }

}




// Console.Write(unEmpleado.Numero.ToString().PadRight(6,‘ ‘)+
// " "+unEmpleado.Nombre.PadRight(30, ‘ ‘)+
// " "+unEmpleado.Sueldo.ToString("C"));





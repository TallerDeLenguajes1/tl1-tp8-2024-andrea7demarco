using System;
using System.IO;
using System.Collections.Generic;
using ClasesParaTarea; 



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Tarea> TareasPendientes= new List<Tarea>();
List<Tarea> TareasRealizadas =new List<Tarea>();
string? desc="" , input , clave;
int num =0 , id ;
bool parseoBool;
int salir =0;
int horas=0;
int n = 10;

//string RutaArchivo = @"c:c:\taller\repo\tp8\tl1_tp8_2023-andrea7demarco\text1.txt";

    // creo una instancia 
    funciones func = new funciones();

    for (int i = 0; i < n; i++)
    {
    Tarea tareaAleatoria = new Tarea
    {
      Descripcion = "Tarea " + num,
      TareaID = num,
      Duracion = new Random().Next(10, 101)
    };
    num += 1;

     TareasPendientes.Add(tareaAleatoria);
     }
     Console.WriteLine($"{n} tareas creadas y añadidas a la lista de pendientes.");



   do{
    Console.WriteLine(":::::::::::::MENU::::::::::::\n");
    Console.WriteLine("1. Listar Tareas Pendientes\n");
    Console.WriteLine("2. Buscar tarea por CLAVE\n");
    Console.WriteLine("3. Marcar tarea como REALIZADA:\n ");
    Console.WriteLine("4. Salir\n");
    Console.WriteLine("Ingresar una opcion del menu:\n");
    input = Console.ReadLine();
    parseoBool = int.TryParse(input, out int operacion);
    
    switch(operacion){
        case 1:
            Console.WriteLine("Listado de tareas PENDIENTES:\n");
            foreach(Tarea tarea in TareasPendientes){
                tarea.MostrarTarea();
            }
            break;
        case 2: 
                Console.WriteLine("Ingrese la descripcion de la tarea:\n");
               desc = Console.ReadLine();
               Tarea nTarea = new Tarea();
               nTarea.Descripcion = desc;
               nTarea.TareaID = num;
               Random random = new Random();
               nTarea.Duracion = random.Next(10,101);
               num+=1;

               TareasPendientes.Add(nTarea);

            break;
        case 3:
           Console.WriteLine("Ingresar Descripción de la tarea a buscar:\n");
           clave= Console.ReadLine();
           Tarea? TareaEncontradaClaveP = func.BuscarTareaPorClave(clave, TareasPendientes);
           Tarea? TareaEncontradaClaveR = func.BuscarTareaPorClave(clave, TareasRealizadas);
            if (TareaEncontradaClaveP == null || TareaEncontradaClaveP == null) {
                Console.WriteLine($"No se encontró ninguna tarea con la clave: {clave}");
            } else {
                Console.WriteLine("Tarea encontrada:\n");
                    TareaEncontradaClaveP?.MostrarTarea();
                    TareaEncontradaClaveR?.MostrarTarea();
            }

           break;
        case 4:
            Console.WriteLine("Marcar tarea PENDIENTE como REALIZADA:\n");
            Console.WriteLine("Ingresar ID de la tarea a buscar:\n");
            parseoBool=int.TryParse(Console.ReadLine(), out id);          
            foreach( Tarea tarea in TareasPendientes){
                if( id == tarea.TareaID){
                    TareasRealizadas.Add(tarea);
                }
            }
            foreach( Tarea tarea in TareasRealizadas){
                if( id == tarea.TareaID){
                    TareasPendientes.Remove(tarea);
                }
            }
           break;
        case 5:
           salir=8;
           Console.WriteLine("Salida exitosa");
           break;
           default:
           Console.WriteLine("Operación no válida.");
           break;
   }

   }while(salir!=8);


    foreach( Tarea tarea in TareasPendientes)
    {
    horas += tarea.Duracion;
    }

    foreach( Tarea tarea in TareasRealizadas)
    {
    horas += tarea.Duracion;
    }

    StreamWriter sw = new StreamWriter("Horas_trabajadas.txt");
    sw.WriteLine($"Horas trabajadas = {horas}");
    sw.Close();

/*
foreach (var numero in MiLista ){
    Console.WriteLine(numero);
}
*/


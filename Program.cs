using EspacioTareas;

internal class Program
{
    private static void Main(string[] args)
    {
        String str;
        bool flag = true;
        int selec, cant, horas=0;
        var Pendientes = new List<Tareas>();
        var Realizadas = new List<Tareas>();

        Console.WriteLine("Ingrese la cantidad de tareas a generar: ");
        str = Console.ReadLine();

        if (int.TryParse(str, out cant))
        {
            for (int i=0; i<cant; i++)
            {
                Pendientes.Add(genTarea(i));
            }
        }


        while (flag)
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("1. Mostrar las Tareas");
            Console.WriteLine("2. Mover Tarea pendiente a realizada");
            Console.WriteLine("3. Buscar tarea por descripcion");
            Console.WriteLine("4. Salir");
            Console.WriteLine("---------------------------\n");

            str = Console.ReadLine();

            if (int.TryParse(str, out selec))
            {
                switch (selec)
                {
                    case 1:
                        if (Pendientes.Count != 0)
                            Console.WriteLine("------ Tareas pendientes ------");
                        foreach (var tarea in Pendientes)
                            tarea.MostrarTarea();
                        
                        if (Realizadas.Count != 0)
                            Console.WriteLine("------ Tareas realizadas ------");
                        foreach (var tarea in Realizadas)
                            tarea.MostrarTarea();
                            Console.WriteLine("--- Pulse una tecla para continuar ---");
                            Console.ReadKey();
                        break;

                    case 2:
                        for (int i=0; i<Pendientes.Count; i++)
                        {
                            Pendientes[i].MostrarTarea();
                            Console.WriteLine("Tarea realizada? (si/no)");

                            str = Console.ReadLine();

                            if (str.ToLower() == "si") {
                                Realizadas.Add(Pendientes[i]);
                                Pendientes.Remove(Pendientes[i]);
                                Console.WriteLine("--- La tarea se movio a Realizadas ---");
                            } else Console.WriteLine ("--- Sin cambios --- ");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Ingrese la subcadena a buscar: ");
                        str = Console.ReadLine();

                        if (str != "")
                        {
                            for (int i=0; i<Pendientes.Count; i++)
                            {
                                if (Pendientes[i].Descripcion.ToString().ToLower().Contains(str.ToLower()))
                                {
                                    Console.WriteLine("\n--- Tarea encontrada ---");
                                    Pendientes[i].MostrarTarea();
                                    Console.WriteLine("--- Pulse una tecla para continuar ---");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                    case 4: 
                        flag = false;
                        for (int i=0; i<Realizadas.Count; i++)
                        {
                            horas += Realizadas[i].Duracion;
                        }
                        Console.WriteLine($"Horas trabajadas: {horas}");

                        using (var archivo = new StreamWriter("archivo.txt"))
                        {
                            archivo.WriteLine($"Horas trabajadas: {horas}"); 
                            archivo.Close();   
                        }

                        Console.WriteLine("\nSaliendo...");
                        break;
                } 
            }
        }
    }

    static Tareas genTarea(int id)
    {
            eTareas etarea;
            Random rnd = new Random();
            eTareas.TryParse($"{rnd.Next(1,11)}", out etarea);
            Tareas Tarea = new Tareas(id, etarea, rnd.Next(10, 101));
            return Tarea;     
    }
}
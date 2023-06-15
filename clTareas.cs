namespace EspacioTareas;

public class Tareas
{
    private int id;
    private eTareas descripcion;
    private int duracion;

    public Tareas(int Id, eTareas Descripcion, int Duracion)
    {
        id = Id;
        descripcion = Descripcion;
        duracion = Duracion;
    }

    public eTareas Descripcion { get => descripcion; }
    public int Duracion { get => duracion; }

    public void MostrarTarea()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Tarea {id}");
        Console.WriteLine($"Descripcion: {descripcion}");
        Console.WriteLine($"Duracion: {duracion}");
        Console.WriteLine("-------------------------------\n");
    }
}


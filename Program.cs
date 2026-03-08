using System.Dynamic;

public class Central_911
{
    private static Central_911? _instance;
    private static readonly object _lock = new object();

    public string Central { get; private set; }

    private Central_911()
    {
        Central = "Central_911";
    }

    public static Central_911 Obtener_Instancia()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Central_911();
                }
            }
        }
        return _instance;
    }
    public void Conectar_Llamada (Operador operador, string tipoEmergencia)
    {
        Console.WriteLine("\nLlamada conectada con el operador " + operador.Nombre);
        operador.AtiendeEmergencia(tipoEmergencia);
    }
}

public class Operador
{
    public int Id_Operador { get; set; }
    public string Nombre { get; set; }

    public Operador(int id, string nomrbe)
    {
        Id_Operador = id;
        Nombre = nomrbe;
    }

    public void AtiendeEmergencia(string tipoEmergencia)
    {
        Console.WriteLine($"Operador {Nombre} atendiendo emergencia de tipo: {tipoEmergencia}");

        switch (tipoEmergencia)
        {
            case "Intento de suicidio":
                Console.WriteLine("Enviando unidades de apoyo y rescate");
                break;
            case "Incendio":
                Console.WriteLine("Enviando bomberos");
                break;
            case "Accidente":
                Console.WriteLine("Enviando paramedicos y ofciales");
                break;
            case "Violeta":
                Console.WriteLine("Enviando una patrulla");
                break;
            default:
                Console.WriteLine("Tipo de emergencia no reconocido");
                break;
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        
        Central_911 Llamadas = Central_911.Obtener_Instancia();

        Operador op1 = new Operador(1, "Juan");
        Operador op2 = new Operador(2, "Maria");
        Operador op3 = new Operador(3, "Felix");
        Operador op4 = new Operador(4, "Fernando");
        Operador op5 = new Operador(5, "Mara");
        Operador op6 = new Operador(6, "Jordan");
        Operador op7 = new Operador(7, "Damian");
        Operador op8 = new Operador(8, "Marta");

        Operador[] operadores = { op1, op2, op3, op4, op5, op6, op7, op8 };

        string[] tipoEmergencia =
        {
            "Intento de suicidio",
            "Incendio",
            "Accidente",
            "Violeta",
            " "
        };

          for (int i = 1; i <= 10; i++)
        {
            Operador operadorRandom = operadores[random.Next(operadores.Length)];
            string emergenciaRandom = tipoEmergencia[random.Next(tipoEmergencia.Length)];

            Console.WriteLine($"\n--- Llamada {i} ---");
            Llamadas.Conectar_Llamada(operadorRandom, emergenciaRandom);
        }

       /* Llamada1.Conectar_Llamada(op1, "Intento de suicidio");
        Llamada2.Conectar_Llamada(op2, "Incendio");
        Llamada1.Conectar_Llamada(op1, "Intento de suicidio");
        Llamada2.Conectar_Llamada(op2, "Incendio");
*/
        Console.WriteLine("\nReferenceEquals:" + ReferenceEquals(Llamadas, Central_911.Obtener_Instancia()));
        Console.ReadKey();
    }
}
using System;

class Program
{
    static string[] materias = { "Español", "Matemáticas", "Ciencias", "Ciencias sociales" };
    static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

    static string[,,] asistencias = new string[materias.Length, dias.Length, 3];

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. Consultar estudiantes");
            Console.WriteLine("4. Salir");
            Console.Write("Elige opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: RegistrarEstudiante(); break;
                case 2: EliminarEstudiante(); break;
                case 3: ConsultarEstudiantes(); break;
            }
        } while (opcion != 4);
    }

    static void RegistrarEstudiante()
    {
        int m = ElegirIndice(materias, "materia");
        int d = ElegirIndice(dias, "día");
        Console.Write("Nombre del estudiante: ");
        string nombre = Console.ReadLine();

        for (int i = 0; i < asistencias.GetLength(2); i++)
        {
            if (asistencias[m, d, i] == nombre)
            {
                Console.WriteLine("El estudiante ya está registrado.");
                return;
            }
        }

        for (int i = 0; i < asistencias.GetLength(2); i++)
        {
            if (asistencias[m, d, i] == null)
            {
                asistencias[m, d, i] = nombre;
                Console.WriteLine("Estudiante registrado.");
                return;
            }
        }
        Console.WriteLine("No hay espacio para más estudiantes en esta clase.");
    }

    static void EliminarEstudiante()
    {
        int m = ElegirIndice(materias, "materia");
        int d = ElegirIndice(dias, "día");
        Console.Write("Nombre del estudiante a eliminar: ");
        string nombre = Console.ReadLine();

        for (int i = 0; i < asistencias.GetLength(2); i++)
        {
            if (asistencias[m, d, i] == nombre)
            {
                asistencias[m, d, i] = null;
                Console.WriteLine("Estudiante eliminado.");
                return;
            }
        }
        Console.WriteLine("Estudiante no encontrado.");
    }

    static void ConsultarEstudiantes()
    {
        int m = ElegirIndice(materias, "materia");
        int d = ElegirIndice(dias, "día");
        Console.WriteLine($"Estudiantes en {materias[m]} el {dias[d]}:");
        for (int i = 0; i < asistencias.GetLength(2); i++)
        {
            if (!string.IsNullOrEmpty(asistencias[m, d, i]))
                Console.WriteLine(asistencias[m, d, i]);
        }
    }

    static int ElegirIndice(string[] opciones, string tipo)
    {
        Console.WriteLine($"Elige {tipo}:");
        for (int i = 0; i < opciones.Length; i++)
            Console.WriteLine($"{i + 1}. {opciones[i]}");
        int idx = int.Parse(Console.ReadLine()) - 1;
        return idx;
    }
}

//Para manejar la lista de estudiantes por materia y día, usé arreglos multidimensionales porque permiten organizar los datos
//en forma ordenada y clara, sin complicaciones. Para recorrer esos arreglos sin errores,
//usé el método GetLength, que me dice cuántos elementos hay en cada dimensión del arreglo.
//Así evito poner números fijos y el código se adapta si cambio el tamaño de las materias, días o estudiantes.
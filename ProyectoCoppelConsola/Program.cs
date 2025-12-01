using System;
using System.Globalization;
record Student(string Nombre, int Edad, DateOnly FechaNacimiento, string Carrera);

Console.WriteLine("Bienvenidos a Universidad Coppel");

var nombre = ReadRequiredString("Nombre completo:");
var edad = ReadInt("Edad:");
var fecha = ReadDate("Fecha nacimiento (DD/MM/AAAA):");
var carrera = ReadRequiredString("Carrera:");

var alumno = new Student(nombre, edad, fecha, carrera);

Console.WriteLine();
Console.WriteLine($"Gracias {alumno.Nombre} por formar parte de UMI");
Console.WriteLine($"Bienvenido a la carrera de {alumno.Carrera}");
Console.WriteLine($"Nombre: {alumno.Nombre}");
Console.WriteLine($"Edad: {alumno.Edad}");
Console.WriteLine($"Fecha Nacimiento: {alumno.FechaNacimiento:dd/MM/yyyy}");
Console.WriteLine($"Carrera: {alumno.Carrera}");

Console.WriteLine("\nPresiona Enter para salir...");
Console.ReadLine();

static string ReadRequiredString(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        var s = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(s)) return s;
        Console.WriteLine("Valor obligatorio. Intenta de nuevo.");
    }
}

static int ReadInt(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        var s = Console.ReadLine()?.Trim();
        if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) && v >= 0)
            return v;
        Console.WriteLine("Edad no válida. Introduce un número entero no negativo.");
    }
}

static DateOnly ReadDate(string prompt)
{
    const string format = "dd/MM/yyyy";
    while (true)
    {
        Console.WriteLine(prompt);
        var s = Console.ReadLine()?.Trim();
        if (DateOnly.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
            return d;
        Console.WriteLine($"Fecha no válida. Usa el formato {format}.");
    }
}


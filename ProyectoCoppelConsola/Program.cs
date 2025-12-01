using System;
using System.Globalization;


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



public class Student
{
    public string Nombre { get; init; }
    public int Edad { get; init; }
    public DateOnly FechaNacimiento { get; init; }
    public string Carrera { get; init; }

    public Student(string nombre, int edad, DateOnly fechaNacimiento, string carrera)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre no puede estar vacío.", nameof(nombre));
        if (edad < 0) throw new ArgumentOutOfRangeException(nameof(edad), "Edad no puede ser negativa.");
        if (fechaNacimiento > DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentException("Fecha de nacimiento no puede estar en el futuro.", nameof(fechaNacimiento));
        if (string.IsNullOrWhiteSpace(carrera)) throw new ArgumentException("Carrera no puede estar vacía.", nameof(carrera));

        Nombre = nombre.Trim();
        Edad = edad;
        FechaNacimiento = fechaNacimiento;
        Carrera = carrera.Trim();
    }

    // Constructor parameterless opcional (útil para serialización)
    public Student()
    {
        Nombre = string.Empty;
        Edad = 0;
        FechaNacimiento = DateOnly.FromDateTime(DateTime.Today);
        Carrera = string.Empty;
    }

    // Edad calculada a partir de FechaNacimiento (más fiable que la edad ingresada)
    public int EdadCalculada
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - FechaNacimiento.Year;
            if (today < FechaNacimiento.AddYears(age)) age--;
            return age;
        }
    }

    public void Deconstruct(out string nombre, out int edad, out DateOnly fechaNacimiento, out string carrera)
    {
        nombre = Nombre;
        edad = Edad;
        fechaNacimiento = FechaNacimiento;
        carrera = Carrera;
    }

    // Crea una copia modificada (similar a 'with' de records)
    public Student With(string? nombre = null, int? edad = null, DateOnly? fechaNacimiento = null, string? carrera = null) =>
        new Student(
            nombre ?? Nombre,
            edad ?? Edad,
            fechaNacimiento ?? FechaNacimiento,
            carrera ?? Carrera
        );

    public override string ToString() =>
        $"{Nombre} - {Carrera} | Edad (ingresada): {Edad} | Nac: {FechaNacimiento:dd/MM/yyyy} | Edad calculada: {EdadCalculada}";
}
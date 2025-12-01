# Universidad Coppel - ProyectoCoppelConsola

Este proyecto de consola da la bienvenida a estudiantes a la **Universidad Coppel** y recoge la información básica del alumno.

## Descripción

El programa solicita los siguientes datos al usuario:
- Nombre completo
- Edad
- Fecha de nacimiento (`DD/MM/AAAA`)
- Carrera

Después de ingresar los datos, muestra un mensaje personalizado de bienvenida y los detalles capturados.

## Fragmento de Código

```csharp
using System;
using System.Globalization;

// Mensaje de bienvenida
Console.WriteLine("Bienvenidos a Universidad Coppel");

// Solicitar datos del alumno
var nombre = ReadRequiredString("Nombre completo:");
var edad = ReadInt("Edad:");
var fecha = ReadDate("Fecha nacimiento (DD/MM/AAAA):");
var carrera = ReadRequiredString("Carrera:");

// Crear el objeto alumno
var alumno = new Student(nombre, edad, fecha, carrera);

// Mostrar información
Console.WriteLine();
Console.WriteLine($"Gracias {alumno.Nombre} por formar parte de UMI");
Console.WriteLine($"Bienvenido a la carrera de {alumno.Carrera}");
Console.WriteLine($"Nombre: {alumno.Nombre}");
Console.WriteLine($"Edad: {alumno.Edad}");
Console.WriteLine($"Fecha Nacimiento: {alumno.FechaNacimiento:dd/MM/yyyy}");
Console.WriteLine($"Carrera: {alumno.Carrera}");

Console.WriteLine("\nPresiona Enter para salir...");
Console.ReadLine();

// Métodos auxiliares
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
```

## Ejecución

Para ejecutar este proyecto:

1. Clona el repositorio.
2. Abre el proyecto en tu IDE preferido (Visual Studio, VS Code, etc).
3. Ejecuta el programa y sigue las instrucciones en consola.

## Requisitos

- .NET 6.0 o superior
- Sistema operativo Windows, macOS o Linux

## Notas

- Verifica que la clase `Student` está implementada en tu código.
- Asegura que usas `DateOnly` (disponible en .NET 6.0+).

## Autor

Creado por josejoelL.

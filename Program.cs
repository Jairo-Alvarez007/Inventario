using System; // Para entrada/salida por consola
using System.Collections.Generic; // Para usar el diccionario

public class Program
{
    // Declaramos un diccionario para almacenar productos y cantidades
    // La clave es el nombre del producto (string), el valor es la cantidad (int)
    static Dictionary<string, int> inventario = new();


    // FUNCION PRINCIPAL
    public static void Main()
    {
        // BUCLE INFINITO HASTA QUE EL USUARIO DECIDA SALIR
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("________________________________");
            Console.WriteLine("*    SISTEMA DE INVENTARIO     *");
            Console.WriteLine("________________________________");
            Console.ResetColor();
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Mostrar inventario");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Actualizar cantidad");
            Console.WriteLine("5. Salir");
            Console.WriteLine("________________________________");
            Console.Write("\nSeleccione una opción: ");

            // SE LEE LA OPCION DEL USUARIO
            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                Console.WriteLine("Opción no valida."); // Mensaje si no es número
                Pausa();
                continue; // Volvemos al menú
            }

            // MANEJO DE ERRORES
            try
            {
                // SE EJECUTA LA OPCION SELECCIONADA
                switch (opcion)
                {
                    case 1: AgregarProducto(); break;
                    case 2: MostrarInventario(); break;
                    case 3: BuscarProducto(); break;
                    case 4: ActualizarProducto(); break;
                    case 5: Console.WriteLine("Saliendo del Inventario..."); return;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion ingresada no se reconoce"); break;
                }
            }

            // MANEJO DE ERRORES
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Muestra el mensaje de error
            }
        }
    }

    // FUNCION PAUSA
    public static void Pausa()
    {
        Console.WriteLine("_______________________________________");
        Console.WriteLine("Presione Enter para regresar al menú...");
        Console.ReadLine();
    }

    // FUNCION AGREGAR PRODUCTO
    public static void AgregarProducto()
    {
        Console.Clear();
        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine()?.Trim() ?? ""; // Leemos y limpia el nombre

        // Verificamos si el producto ya existe en el inventario
        if (inventario.ContainsKey(nombre))  // Revisamos en el diccionario si ya existe
        {
            Console.Write("El producto ya existe. ¿Desea sumar a la cantidad actual? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.Write("Cantidad adicional: ");
                if (int.TryParse(Console.ReadLine(), out int extra))
                {
                    inventario[nombre] += extra;
                    Console.WriteLine("Cantidad actualizada con éxito!!!.");
                }
                else
                {
                    Console.WriteLine("Cantidad invalida. El producto no se actualizó.");
                }
            }
            Pausa();
            return; // Salimos de la función
        }

        Console.Write("Cantidad: ");
        // Leemos la cantidad y validamos que sea un número entero
        if (!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("La cantidad ingresada no es valida.");
            Console.WriteLine("El producto no se ha agregado. Intente de nuevo.");
            Pausa();
            return;
        }

        // Agregamos el producto al diccionario
        inventario[nombre] = cantidad;
        Console.Clear();
        Console.WriteLine("El producto se agregó correctamente!!!.");
        Pausa();
    }

    // FUNCION MOSTRAR INVENTARIO
    public static void MostrarInventario()
    {
        Console.Clear();
        // Verificamos si el inventario está vacío
        if (inventario.Count == 0)
        {
            Console.WriteLine("El inventario esta vacio.");
            Pausa();
            return;
        }

        // Mostramos cada producto y su cantidad
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("_______________________");
        Console.WriteLine("      INVENTARIO      ");
        Console.WriteLine("_______________________");
        Console.ResetColor();

        foreach (var producto in inventario)  // recorre cada elemento dentro del diccionario
            Console.WriteLine($"{producto.Key,15} | Cantidad: {producto.Value}"); //15 alinea a la derecha

        // Esperamos que el usuario presione Enter para volver al menu
        Pausa();
    }

    // FUNCION BUSCAR PRODUCTO
    public static void BuscarProducto()
    {
        Console.Clear();
        Console.Write("Nombre del producto a buscar: ");
        string nombre = Console.ReadLine()?.Trim() ?? "";

        // Intentamos obtener la cantidad del producto buscado
        if (inventario.TryGetValue(nombre, out int cantidad))
            Console.WriteLine($"Producto encontrado: {nombre} - Cantidad: {cantidad}");
        else
            Console.WriteLine("Producto no encontrado.");

        Pausa();
    }

    // FUNCION ACTUALIZAR PRODUCTO
    public static void ActualizarProducto()
    {
        Console.Clear();
        Console.Write("Nombre del producto a actualizar: ");
        string nombre = Console.ReadLine()?.Trim() ?? ""; // Leemos y limpiamos el nombre

        // Verificamos si el producto existe
        if (!inventario.ContainsKey(nombre))
        {
            Console.WriteLine("Producto no disponible en el inventario");
            Pausa();
            return;
        }

        Console.Write("Nueva cantidad: ");
        // Leemos la nueva cantidad y validamos que sea un número
        if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad))
        {
            Console.WriteLine("Cantidad ingresada no valida."); // Si no es número
            Pausa();
            return;
        }

        // Actualizamos la cantidad en el diccionario
        inventario[nombre] = nuevaCantidad;
        Console.WriteLine("Cantidad actualizada con exito!!!."); // Confirmación
        Pausa();
    }
}

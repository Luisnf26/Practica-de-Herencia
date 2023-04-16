using System;
using System.Collections.Generic;

public class Hamburguesa {
    public string tipoPan;
    public string tipoCarne;
    public decimal precioBase;
    public List<string> ingredientes = new List<string>();
    public Dictionary<string, decimal> preciosIngredientes = new Dictionary<string, decimal>();

    public Hamburguesa(string tipoPan, string tipoCarne, decimal precioBase) {
        this.tipoPan = tipoPan;
        this.tipoCarne = tipoCarne;
        this.precioBase = precioBase;
    }

    public void AgregarIngrediente(string ingrediente, decimal precio) {
        ingredientes.Add(ingrediente);
        preciosIngredientes[ingrediente] = precio;
    }

    public decimal CalcularPrecio() {
        decimal precioTotal = precioBase;
        foreach (string ingrediente in ingredientes) {
            precioTotal += preciosIngredientes[ingrediente];
        }
        return precioTotal;
    }

    public void MostrarDetalle() {
        Console.WriteLine("Hamburguesa:");
        Console.WriteLine($"- Tipo de pan: {tipoPan}");
        Console.WriteLine($"- Tipo de carne: {tipoCarne}");
        Console.WriteLine($"- Precio base: {precioBase:C}");
        Console.WriteLine("Ingredientes adicionales:");
        foreach (string ingrediente in ingredientes) {
            Console.WriteLine($"- {ingrediente}: {preciosIngredientes[ingrediente]:C}");
        }
        Console.WriteLine($"Precio total: {CalcularPrecio():C}");
    }
}

public class HamburguesaSaludable : Hamburguesa {
    private List<string> ingredientesSaludables = new List<string>();
    private Dictionary<string, decimal> preciosIngredientesSaludables = new Dictionary<string, decimal>();

    public HamburguesaSaludable(string tipoPan, string tipoCarne, decimal precioBase) : base(tipoPan, tipoCarne, precioBase) {}

    public void AgregarIngredienteSaludable(string ingrediente, decimal precio) {
        if (ingredientesSaludables.Count < 2) {
            ingredientesSaludables.Add(ingrediente);
            preciosIngredientesSaludables[ingrediente] = precio;
        }
    }

    public new decimal CalcularPrecio() {
        decimal precioTotal = base.CalcularPrecio();
        foreach (string ingrediente in ingredientesSaludables) {
            precioTotal += preciosIngredientesSaludables[ingrediente];
        }
        return precioTotal;
    }

public new void MostrarDetalle() {
    Console.WriteLine("Hamburguesa saludable:");
    Console.WriteLine($"- Tipo de pan: {tipoPan}");
    Console.WriteLine($"- Tipo de carne: {tipoCarne}");
    Console.WriteLine($"- Precio base: {precioBase:C}");
    Console.WriteLine("Ingredientes adicionales saludables:");
    foreach (string ingrediente in ingredientesSaludables) {
        Console.WriteLine("- " + ingrediente);
    }
    Console.WriteLine("\n¡Disfruta de tu ensalada!\n");
    }
}

class Program {
    static void Main(string[] args) {
        Hamburguesa hamburguesa = new Hamburguesa("Normal", "Res", 5.0M);
        hamburguesa.AgregarIngrediente("Queso", 1.5M);
        hamburguesa.AgregarIngrediente("Lechuga", 0.5M);
        hamburguesa.MostrarDetalle();

        HamburguesaSaludable hamburguesaSaludable = new HamburguesaSaludable("Integral", "Pollo", 6.0M);
        hamburguesaSaludable.AgregarIngrediente("Queso", 1.5M);
        hamburguesaSaludable.AgregarIngredienteSaludable("Lechuga", 0.5M);
        hamburguesaSaludable.AgregarIngredienteSaludable("Tomate", 0.5M);
        hamburguesaSaludable.MostrarDetalle();

        Console.ReadKey();
    }
}








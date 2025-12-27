using System;
using System.Text;

public class Computer
{
    // Properties are read-only or have private setters to ensure immutability
    public string CPU { get; }
    public string RAM { get; }
    public string Storage { get; }
    public bool HasGraphicsCard { get; }
    public bool HasWifi { get; }

    // Private constructor, only accessible by the Builder
    private Computer(ComputerBuilder builder)
    {
        CPU = builder.Cpu;
        RAM = builder.Ram;
        Storage = builder.Storage;
        HasGraphicsCard = builder.HasGraphicsCard;
        HasWifi = builder.HasWifi;
    }

    public override string ToString()
    {
        return $"Computer [CPU={CPU}, RAM={RAM}, Storage={Storage}, Graphics Card={HasGraphicsCard}, WiFi={HasWifi}]";
    }

    // Static entry point for the Builder
    public static ComputerBuilder CreateBuilder(string cpu, string ram, string storage)
    {
        return new ComputerBuilder(cpu, ram, storage);
    }


    public class ComputerBuilder
{
    // Mutable properties for the builder's internal state
    public string Cpu { get; }
    public string Ram { get; }
    public string Storage { get; }
    public bool HasGraphicsCard { get; private set; } = false;
    public bool HasWifi { get; private set; } = false;

    // Constructor for required parameters
    public ComputerBuilder(string cpu, string ram, string storage)
    {
        Cpu = cpu ?? throw new ArgumentNullException(nameof(cpu));
        Ram = ram ?? throw new ArgumentNullException(nameof(ram));
        Storage = storage ?? throw new ArgumentNullException(nameof(storage));
    }

    // Fluent setter methods, returning the builder instance
    public ComputerBuilder SetGraphicsCard(bool value)
    {
        HasGraphicsCard = value;
        return this;
    }

    public ComputerBuilder SetWifi(bool value)
    {
        HasWifi = value;
        return this;
    }

    // The final "Build" method creates the immutable Product
    public Computer Build()
    {
        // Optional validation logic here before creating the final object
        if (string.IsNullOrEmpty(Cpu) || string.IsNullOrEmpty(Ram) || string.IsNullOrEmpty(Storage))
        {
            throw new InvalidOperationException("Required components must be set before building.");
        }

        return new Computer(this);
    }
}

}

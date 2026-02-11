using System;
using System.Numerics;
using ASpace.Core;
using ASpace.Core.Logging;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ASpace.Windows;

public partial class MainWindow : Window
{
    private const int DisplayWidth = 256;
    private const int DisplayHeight = 224;
    private const int DefaultDisplayScale = 2;
        
    public static VMEngine VMEngine { get; private set; } = new();

    private Logger Log = new ("GUI");
    
    public int DisplayScale
    {
        get;
        set
        {
            Log.Info($"Set DisplayScale (old={field} new={value})");
            
            field = value;
            
            // Screen is rotated 90 degrees, just swap Width/Height here.
            Display.Width = DisplayHeight * value;
            Display.Height = DisplayWidth * value;
        }
    }
    
    public MainWindow()
    {
        InitializeComponent();
        Loaded += (_, _) =>
        {
            DisplayScale = DefaultDisplayScale;
        };
    }

    private void Menu_Exit(object? sender, RoutedEventArgs e) => Environment.Exit(0);
    private void Menu_DisplayScale(object? sender, RoutedEventArgs e)
    {
        if (
            sender is not MenuItem item ||
            item.Tag is not string scaleValue ||
            !int.TryParse(scaleValue, out var scaleInt)
        )
            return;
        DisplayScale = scaleInt;
    }
}
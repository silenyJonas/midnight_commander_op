using System;
using System.IO;
using System.Collections.Generic;

public sealed class Config
{
    private static readonly Config instance = new Config();

    private Config() { }

    public static Config Instance
    {
        get
        {
            return instance;
        }
    }

    public int Console_Height { get; private set; }
    public int Console_Width { get; private set; }
    public bool Dark_Mode { get; private set; }
    public bool Responzive { get; private set; }
    public int Body_Height { get; private set; }
    public void Set(string config_path)
    {
        try
        {
            using (var reader = new StreamReader(config_path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        var key = parts[0].Trim().ToLower();
                        var value = parts[1].Trim();

                        switch (key)
                        {
                            case "console_width":
                                if (int.TryParse(value, out int width))
                                {
                                    this.Console_Width = width;
                                }
                                break;
                            case "console_height":
                                if (int.TryParse(value, out int height))
                                {
                                    this.Console_Height = height;
                                }
                                break;
                            case "darkmode":
                                if (bool.TryParse(value, out bool darkMode))
                                {
                                    this.Dark_Mode = darkMode;
                                }
                                break;
                            case "responzive":
                                if (bool.TryParse(value, out bool responzive))
                                {
                                    this.Responzive = responzive;
                                }
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading config file: {ex.Message}");
        }
        Body_Height = Console_Height - 8;

    }
    public void Apply()
    {
        Console.SetCursorPosition(0, 0);
        try
        {
            #if WINDOWS
                Console.SetCursorPosition(0, 0);
                Console.SetWindowSize(this.Console_Width, this.Console_Height);
            #endif
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error setting console window size: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error setting console window size: {ex.Message}");
        }
        catch (PlatformNotSupportedException ex)
        {
            Console.WriteLine($"Platform does not support setting console window size: {ex.Message}");
        }
    }

    public void Change_Console_Height(int height)
    {
        this.Console_Height = height;
    }

    public void Change_Console_Width(int width)
    {
        this.Console_Width = width;
    }

    public void Change_Dark_Mode(bool dark_mode)
    {
        this.Dark_Mode = dark_mode;
    }
}

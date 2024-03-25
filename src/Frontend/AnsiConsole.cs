using System;
using Gammer0909.MiniMax.Frontend;

namespace Gammer0909.MiniMax.Frontend;

public static class AnsiConsole {

    public static void Write(string text) {
        Console.Write(text);
    }

    public static void WriteLine(string text) {
        Console.WriteLine(text);
    }

    public static void Write(string text, Color color) {
        Console.Write(color.ToString() + text + Color.Reset.ToString());
    }

    public static void WriteLine(string text, Color color) {
        Console.WriteLine(color.ToString() + text + Color.Reset.ToString());
    }

    public static void Clear() {
        Console.Clear();
        Console.Write(Color.Reset.ToString());
    }



}
using System;
using System.Drawing;
using System.Numerics;

namespace Gammer0909.MiniMax.Frontend;

/// <summary>
/// Representation of an Ansi Color
/// </summary>
public class Color {

    byte r, g, b;
    string ansiCode { get; set; } = "";
    bool foreground;

    // -- OTHER STUFF -- //
    public static Color Reset => new Color(0, 0, 0, "\u001b[0m", true);
    public static Color Bold => new Color(0, 0, 0, "\u001b[1m", true);
    public static Color Underline => new Color(0, 0, 0, "\u001b[4m", true);
    public static Color Inverse => new Color(0, 0, 0, "\u001b[7m", true);
    public static Color Strikethrough => new Color(0, 0, 0, "\u001b[9m", true);
    public static Color BoldOff => new Color(0, 0, 0, "\u001b[22m", true);
    public static Color UnderlineOff => new Color(0, 0, 0, "\u001b[24m", true);
    public static Color InverseOff => new Color(0, 0, 0, "\u001b[27m", true);
    public static Color StrikethroughOff => new Color(0, 0, 0, "\u001b[29m", true);
    public static Color Blink => new Color(0, 0, 0, "\u001b[5m", true);
    public static Color BlinkOff => new Color(0, 0, 0, "\u001b[25m", true);


    // -- STATIC FOREGROUND COLORS -- //
    public static Color Black => new Color(System.Drawing.Color.Black, true);
    public static Color Red => new Color(System.Drawing.Color.Red, true);
    public static Color Green => new Color(System.Drawing.Color.Green, true);
    public static Color Yellow => new Color(System.Drawing.Color.Yellow, true);
    public static Color Blue => new Color(System.Drawing.Color.Blue, true);
    public static Color Magenta => new Color(System.Drawing.Color.Magenta, true);
    public static Color Cyan => new Color(System.Drawing.Color.Cyan, true);
    public static Color White => new Color(System.Drawing.Color.White, true);
    public static Color Gray => new Color(System.Drawing.Color.Gray, true);
    public static Color DarkRed => new Color(System.Drawing.Color.DarkRed, true);
    public static Color DarkGreen => new Color(System.Drawing.Color.DarkGreen, true);
    public static Color DarkYellow => new Color(System.Drawing.Color.DarkGoldenrod, true);
    public static Color DarkBlue => new Color(System.Drawing.Color.DarkBlue, true);
    public static Color DarkMagenta => new Color(System.Drawing.Color.DarkMagenta, true);
    public static Color DarkCyan => new Color(System.Drawing.Color.DarkCyan, true);
    public static Color DarkGray => new Color(System.Drawing.Color.DarkGray, true);

    // -- STATIC BACKGROUND COLORS -- //
    public static Color BackgroundBlack => new Color(System.Drawing.Color.Black, false);
    public static Color BackgroundRed => new Color(System.Drawing.Color.Red, false);
    public static Color BackgroundGreen => new Color(System.Drawing.Color.Green, false);
    public static Color BackgroundYellow => new Color(System.Drawing.Color.Yellow, false);
    public static Color BackgroundBlue => new Color(System.Drawing.Color.Blue, false);
    public static Color BackgroundMagenta => new Color(System.Drawing.Color.Magenta, false);
    public static Color BackgroundCyan => new Color(System.Drawing.Color.Cyan, false);
    public static Color BackgroundWhite => new Color(System.Drawing.Color.White, false);
    public static Color BackgroundGray => new Color(System.Drawing.Color.Gray, false);
    public static Color BackgroundDarkRed => new Color(System.Drawing.Color.DarkRed, false);
    public static Color BackgroundDarkGreen => new Color(System.Drawing.Color.DarkGreen, false);
    public static Color BackgroundDarkYellow => new Color(System.Drawing.Color.DarkGoldenrod, false);
    public static Color BackgroundDarkBlue => new Color(System.Drawing.Color.DarkBlue, false);
    public static Color BackgroundDarkMagenta => new Color(System.Drawing.Color.DarkMagenta, false);
    public static Color BackgroundDarkCyan => new Color(System.Drawing.Color.DarkCyan, false);
    public static Color BackgroundDarkGray => new Color(System.Drawing.Color.DarkGray, false);


    public Color(byte r, byte g, byte b, string ansiCode, bool foreground) {
        this.r = r;
        this.g = g;
        this.b = b;
        this.ansiCode = ansiCode;
        this.foreground = foreground;
    }

    public Color(byte r, byte g, byte b, bool foreground) {
        this.r = r;
        this.g = g;
        this.b = b;
        this.foreground = foreground;
        this.ansiCode = foreground ? $"\u001b[38;2;{r};{g};{b}m" : $"\u001b[48;2;{r};{g};{b}m";
    }

    public Color(System.Drawing.Color color, bool foreground) {
        this.r = color.R;
        this.g = color.G;
        this.b = color.B;
        this.foreground = foreground;
        this.ansiCode = foreground ? $"\u001b[38;2;{r};{g};{b}m" : $"\u001b[48;2;{r};{g};{b}m";
    }


    // -- OPERATORS -- //
    public static implicit operator string(Color color) {
        return color.ansiCode;
    }

    public static implicit operator Color(System.Drawing.Color color) {
        return new Color(color, true);
    }

    // -- COLOR OPERATIONS -- //
    public static Color operator +(Color color1, Color color2) {
        return new Color((byte)(color1.r + color2.r), (byte)(color1.g + color2.g), (byte)(color1.b + color2.b), color1.foreground);
    }

    public static Color operator -(Color color1, Color color2) {
        return new Color((byte)(color1.r - color2.r), (byte)(color1.g - color2.g), (byte)(color1.b - color2.b), color1.foreground);
    }

    public static Color operator *(Color color1, Color color2) {
        return new Color((byte)(color1.r * color2.r), (byte)(color1.g * color2.g), (byte)(color1.b * color2.b), color1.foreground);
    }

    public static Color operator /(Color color1, Color color2) {
        return new Color((byte)(color1.r / color2.r), (byte)(color1.g / color2.g), (byte)(color1.b / color2.b), color1.foreground);
    }

    // -- SCALAR OPERATIONS -- //
    public static Color operator +(Color color1, byte value) {
        return new Color((byte)(color1.r + value), (byte)(color1.g + value), (byte)(color1.b + value), color1.foreground);
    }

    public static Color operator -(Color color1, byte value) {
        return new Color((byte)(color1.r - value), (byte)(color1.g - value), (byte)(color1.b - value), color1.foreground);
    }

    public static Color operator *(Color color1, byte value) {
        return new Color((byte)(color1.r * value), (byte)(color1.g * value), (byte)(color1.b * value), color1.foreground);
    }

    public static Color operator /(Color color1, byte value) {
        return new Color((byte)(color1.r / value), (byte)(color1.g / value), (byte)(color1.b / value), color1.foreground);
    }

    // -- COMPARISON OPERATORS -- //
    public static bool operator ==(Color color1, Color color2) {
        return color1.r == color2.r && color1.g == color2.g && color1.b == color2.b;
    }

    public static bool operator !=(Color color1, Color color2) {
        return color1.r != color2.r || color1.g != color2.g || color1.b != color2.b;
    }

    public override bool Equals(object? obj) {
        if (obj is Color color) {
            return this == color;
        }
        return false;
    }

    public override int GetHashCode() {
        return HashCode.Combine(r, g, b);
    }

    public override string ToString() {
        return this.ansiCode;
    }

    public static Color FromRGB(byte r, byte g, byte b) {
        return new Color(r, g, b, true);
    }

    public static Color FromRGB(byte r, byte g, byte b, bool foreground) {
        return new Color(r, g, b, foreground);
    }

    public static Color FromRGB(System.Drawing.Color color) {
        return new Color(color, true);
    }

    public static Color FromRGB(System.Drawing.Color color, bool foreground) {
        return new Color(color, foreground);
    }



}
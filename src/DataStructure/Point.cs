using System.Diagnostics;

namespace DataStructure
{

[DebuggerDisplay("x = {X} y = {Y}")]
public struct Point
{
    public static readonly Point Empty = new Point();

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Size sz)
    {
        X = sz.Width;
        Y = sz.Height;
    }

    public Point(int dw)
    {
        X = (short)LOWORD(dw);
        Y = (short)HIWORD(dw);
    }

    public bool IsEmpty
    {
        get
        {
            return X == 0 && Y == 0;
        }
    }

    public int X { get; private set; }

    public int Y { get; private set; }
    
    public static explicit operator Size(Point p)
    {
        return new Size(p.X, p.Y);
    }

    public static Point operator +(Point pt, Size sz)
    {
        return Add(pt, sz);
    }

    public static Point operator -(Point pt, Size sz)
    {
        return Subtract(pt, sz);
    }

    public static bool operator ==(Point left, Point right)
    {
        return left.X == right.X && left.Y == right.Y;
    }

    public static bool operator !=(Point left, Point right)
    {
        return !(left == right);
    }

    public static Point Add(Point pt, Size sz)
    {
        return new Point(pt.X + sz.Width, pt.Y + sz.Height);
    }

    public static Point Subtract(Point pt, Size sz)
    {
        return new Point(pt.X - sz.Width, pt.Y - sz.Height);
    }
    
    public override bool Equals(object obj)
    {
        if (!(obj is Point)) return false;
        Point comp = (Point)obj;
        // Note value types can't have derived classes, so we don't need
        // to check the types of the objects here.  -- [....], 2/21/2001 
        return comp.X == this.X && comp.Y == this.Y;
    }

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public void Offset(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    public void Offset(Point p)
    {
        Offset(p.X, p.Y);
    }

    public override string ToString()
    {
        return "{X=" + X.ToString() + ",Y=" + Y.ToString() + "}";
    }

    private static int HIWORD(int n)
    {
        return (n >> 16) & 0xffff;
    }

    private static int LOWORD(int n)
    {
        return n & 0xffff;
    }
}


}




using System.Diagnostics;



namespace DataStructure
{

[DebuggerDisplay("x = {X} y = {Y} z = {Z}")]
public struct Point3D
{
    public static readonly Point3D Empty = new Point3D();

    public Point3D(int x, int y,int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public bool IsEmpty
    {
        get
        {
            return X == 0 && Y == 0 && Z == 0;
        }
    }

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Z { get; private set; }

    public static bool operator ==(Point3D left, Point3D right)
    {
        return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
    }

    public static bool operator !=(Point3D left, Point3D right)
    {
        return !(left == right);
    }
    
    public override bool Equals(object obj)
    {
        if (!(obj is Point3D)) return false;
        Point3D comp = (Point3D)obj;
        // Note value types can't have derived classes, so we don't need
        // to check the types of the objects here.  -- [....], 2/21/2001 
        return comp.X == X && comp.Y == Y && comp.Z == Z;
    }

    public override int GetHashCode()
    {
        return X ^ Y ^ Z;
    }

    public void Offset(int dx, int dy, int dz)
    {
        X += dx;
        Y += dy;
        Z += dz;
    }

    public void Offset(Point3D p)
    {
        Offset(p.X, p.Y,p.Z);
    }

    public override string ToString()
    {
        return "{X=" + X.ToString() + ",Y=" + Y.ToString() + ",Z=" + Y.ToString()+"}";
    }
    
}


}



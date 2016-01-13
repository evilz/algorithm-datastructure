namespace DataStructure
{

public struct Size
{

    public static readonly Size Empty = new Size();
    
    public bool IsEmpty
    {
        get
        {
            return Width == 0 && Height == 0;
        }
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public Size(Point pt)
    {
        Width = pt.X;
        Height = pt.Y;
    }

    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public static Size operator +(Size sz1, Size sz2)
    {
        return Add(sz1, sz2);
    }

    public static Size operator -(Size sz1, Size sz2)
    {
        return Subtract(sz1, sz2);
    }

    public static bool operator ==(Size sz1, Size sz2)
    {
        return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
    }

    public static bool operator !=(Size sz1, Size sz2)
    {
        return !(sz1 == sz2);
    }

    public static explicit operator Point(Size size)
    {
        return new Point(size.Width, size.Height);
    }


    public static Size Add(Size sz1, Size sz2)
    {
        return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
    }

    public static Size Subtract(Size sz1, Size sz2)
    {
        return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Size))
            return false;

        Size comp = (Size)obj;
        // Note value types can't have derived classes, so we don't need to
        // check the types of the objects here.  -- [....], 2/21/2001 
        return (comp.Width == this.Width) &&
               (comp.Height == this.Height);
    }

    public override int GetHashCode()
    {
        return Width ^ Height;
    }

    public override string ToString()
    {
        return "{Width=" + Width.ToString() + ", Height=" + Height.ToString() + "}";
    }
}


}
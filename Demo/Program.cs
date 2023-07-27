using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

internal class Program
{
    private static void Main(string[] args)
    {
        var pattern = Console.ReadLine();
        Console.WriteLine(BrackeChecker(pattern));
    }
    public static bool BrackeChecker(string pattern)
    {
        Stack s = new Stack();
        foreach (var n in pattern)
        {
            if (n == '(' || n == '[' || n == '{')
            {
                s.Push(n);
            }
            else if (n == ')' || n == ']' || n == '}')
            {
                var temp = s.Pop();
                if (temp == '(' && n != ')')
                {
                    return false;
                }
                else if(temp == '{' && n != '}')
                {
                    return false;
                }
                else if (temp == '[' && n != ']')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
public class Arithmatic
{
    public bool key { get; set; }
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Multiply(int x, int y)
    {
        if(x*y < 100)
        {
            throw new ArithmeticException();
        }
        return x * y;
    }
    public virtual bool checker()
    {
        return false;
    }
}
public class Stack
{
    public int index = 0;
    public List<char> l = new List<char>();

    public char GetValue()
    {
        try
        {
            if(l.Count > 0)
            {
                return l[l.Count - 1];
            }
            throw new ArgumentOutOfRangeException();
        }
        catch(Exception e) { return 'o'; }
        
    }
    public void Push(char x)
    {
        try
        {
            this.index++;
            if (index > 100)
            {
                throw new Exception("Stack Overflow");
            }
            l.Add(x);
        }
        catch(Exception e) { Console.WriteLine(e.Message); }
    }
    public char Pop()
    {
        try
        {
            if(index < 0)
            {
                throw new ArgumentException();
            }
            var res = l[l.Count - 1];
            l.RemoveAt(l.Count - 1);
            this.index--;
            return res;
        }
        catch(Exception e) { Console.WriteLine(e.Message); return 'o'; }
    }
}
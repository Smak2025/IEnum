using System.Collections;
using System.Diagnostics;

var eqNodes = new Nodes(-1, 1, 5, NodesType.Equidistant);
foreach (var node in eqNodes)
{
    Console.WriteLine(node);
}

Console.WriteLine(eqNodes[3]);

public enum NodesType{
    Equidistant, Chebyshev, Random
}

public class Nodes : IReadOnlyCollection<double>
{
    double _left;
    double _right;
    int _count;
    NodesType _type;
    public int Count => _count;

    public Nodes(double left, double right, int count, NodesType type)
    {
        if(left >= right)
        {
            throw new ArgumentException("Левый конец должен быть меньше правого");
        }
        if(count <= 1)
        {
            throw new ArgumentException("Узлов должно быть больше");
        }
        _left = left;
        _right = right;
        _count = count;
        _type = type;
    } 

    public IEnumerator<double> GetEnumerator()
    {
        switch (_type)
        {
            case NodesType.Equidistant:
            {
                    var distance = (_right - _left) / (_count - 1);
                    for (int i = 0; i < _count; i++)
                    {
                        yield return _left + distance * i;
                    }
                    break;
            }
            case NodesType.Chebyshev:
            {

                    break;
            }
            case NodesType.Random:
            {

                    break;   
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public double this[int index]
    {
        get
        {
            var i = 0;
            if (index < 0 || index >= _count)
            {
                throw new ArgumentException("Указан неверный индекс");
            } 
            foreach(var elem in this)
            {
                if (i++ == index) return elem;
            }
            return Double.NaN;
        }
    }
}
namespace Calculator;

public class Calculate
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();

        return a / b;
    }
}
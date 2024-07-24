namespace DelegatesAndEvents.Task3Classes;

public class QuadraticPolynomial
{
    public static Func<double, double> GetPolynomial(double elder, double middle, double free)
    {
        return Polynomial;
        
        double Polynomial(double argument)
        {
            return elder * argument * argument + middle * argument + free;
        }
    }
}
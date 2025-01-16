namespace DZ_12_Tumakov
{
    internal class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            double newReal = c1.Real * c2.Real - c1.Imaginary * c2.Imaginary;
            double newImaginary = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
            return new ComplexNumber(newReal, newImaginary);
        }
        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
            {
                return false;
            }
            return c1.Real == c2.Real && c1.Imaginary == c2.Imaginary;
        }
        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            return this == (obj as ComplexNumber);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }
}

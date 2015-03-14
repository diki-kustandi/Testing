namespace KnockKnock.readify.net
{
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System;
    using System.Text;

    public enum TriangleType : int
    {
        Error = 0,
        Equilateral = 1,
        Isosceles = 2,
        Scalene = 3,
    }

    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        [OperationContract]
        System.Guid WhatIsYourToken();

        [OperationContract]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        [OperationContract]
        string ReverseWords(string s);
    }


    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPillClient : IRedPill
    {
        public RedPillClient()
        {
        }

        public System.Guid WhatIsYourToken()
        {
            //return new Guid("57082a72-c40a-4a1a-8d37-c469c4a07e1c");
            return System.Guid.Empty;
        }

        public long FibonacciNumber(long n)
        {
            bool isNegative = false;
            long returnValue = 1;
            long a = 1, b = 1, number = 1;

            switch (n)
            {
                case 0: returnValue = 0; break;
                case 1:
                case 2: returnValue = number; break;
                default:

                    if (n < 0)
                    {
                        if (n < -92) throw new FaultException("Fib(<92) will cause a 64-bit integer overflow");
                        if (n % 2 == 0)
                            isNegative = true;
                    }
                    if (n > 92) throw new FaultException("Fib(>92) will cause a 64-bit integer overflow");

                    for (long i = 0; i < n - 2; i++)
                    {
                        number = a + b;
                        a = b;
                        b = number;
                    }

                    returnValue = isNegative ? returnValue * -1 : number; break;
            }
            return returnValue;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            TriangleType returnType = TriangleType.Error;

            if (a + b > c && a + c > b && b + c > a)
                if (a == b && a == c)
                    returnType = TriangleType.Equilateral;
                else if ((a == b && a != c) || (a == c && a != b) || (b == c && b != a))
                    returnType = TriangleType.Isosceles;
                else
                    returnType = TriangleType.Scalene;
            else
                //if (a <= 0 || b <= 0 || c <= 0)
                    returnType = TriangleType.Error;
                //else

            return returnType;
        }

        public string ReverseWords(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                stringBuilder.Append(s[i]);
            }
            return stringBuilder.ToString();
        }

        /*
	    public string ReverseWords(string s)
	    {
                StringBuilder sb = new StringBuilder();

                string[] lines = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach(string line in lines)
                {
                    string[] innerLines = line.Split(' ');

                    foreach (string str in innerLines)
                    {
                        sb.Append(Reverse(str));
                        sb.Append(" ");
                    }
                    sb.AppendLine();
                }
	        return sb.ToString();
	    }
        */ 
    }

    //public class Constants
    //{
    //    // Ensures consistency in the namespace declarations across services
    //    public const string Namespace = "http://KnockKnock.readify.net";
    //}
}
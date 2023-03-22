using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public enum HEXVALUES 
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14, 
        F = 15
    }
    
    class Convert
    { 
        public string binaryValue { get; set; }
        public double convertDecimal()
        {
            double decimalNumber = 0;
            for(int i = binaryValue.Length - 1, j = 0; i >= 0; i--,j++)
                if(binaryValue[i] == '1')
                    decimalNumber += Math.Pow(2, j);
            return decimalNumber;
        }
        public string convertOctagonal()
        {
            string s = "", temp_r = "", result = "";
            int addedZeros = 3 - (binaryValue.Length % 3);
            if(addedZeros != 0)
                for (int i = 1; i <= addedZeros; i++)
                    s += "0";
            s += binaryValue;
            for(int i = 0; i < s.Length; i++)
            {
                temp_r += s[i];
                if ((i + 1) % 3 == 0)
                {
                    double numberFromThree = 0;
                    for (int k = temp_r.Length - 1, m = 0; k >= 0; k--, m++)
                        if (temp_r[k] == '1')
                            numberFromThree += Math.Pow(2,m);
                    temp_r = "";
                    if(numberFromThree != 0)
                        result = numberFromThree.ToString() + result;
                }
            }
            string reversedResult = "";
            for (int i = result.Length - 1; i >= 0; i--)
                reversedResult += result[i];
            return reversedResult;
        }
        public string convertHex()
        {
            string s = "", temp_r = "", result = "";
            int addedZeros = 4 - (binaryValue.Length % 4);
            if(addedZeros != 0)
                for (int i = 1; i <= addedZeros; i++)
                    s += "0";
            s += binaryValue;
            for (int i = 0; i < s.Length; i++)
            {
                temp_r += s[i];
                if ((i + 1) % 4 == 0)
                {
                    double numberFromFour = 0;
                    for (int k = temp_r.Length - 1, m = 0; k >= 0; k--, m++)
                        if (temp_r[k] == '1')
                            numberFromFour += Math.Pow(2, m);
                    temp_r = "";
                    if (numberFromFour != 0)
                    {
                        if (numberFromFour > 9) result = ((HEXVALUES)numberFromFour).ToString() + result;
                        else result = numberFromFour.ToString() + result;
                    }
                }
            }
            string reversedResult = "";
            for (int i = result.Length - 1; i >= 0; i--)
                reversedResult += result[i];
            return reversedResult;
        }
        public string convertFive()
        {
            int number = 0;
            string pentaNum = "";
            for (int i = binaryValue.Length - 1, j = 0; i >= 0; i--, j++)
                if (binaryValue[i] == '1')
                    number += (int)Math.Pow(2, j);

            while (number > 0)
            {
                int remainder = number % 5;
                pentaNum = remainder.ToString() + pentaNum; 
                number /= 5; 
            }

            return pentaNum;
        }
    }
}

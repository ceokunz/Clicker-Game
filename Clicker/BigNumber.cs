
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clicker
{
    public class BigNumber
    {
        private List<int> digits;
        private const int Base = 1000;

        public BigNumber(string numberStr = "0")
        {
            digits = new List<int>();
            ParseString(numberStr);
        }

        //парсит строку в число
        private void ParseString(string numberStr)
        {
            if (string.IsNullOrEmpty(numberStr))
            {
                digits.Add(0);
                return;
            }

            numberStr = numberStr.Replace(" ", "");

            for (int i = numberStr.Length; i > 0; i -= 3)
            {
                int start = Math.Max(0, i - 3);
                int length = Math.Min(3, i - start);
                string digitStr = numberStr.Substring(start, length);

                if (int.TryParse(digitStr, out int digit))
                {
                    digits.Add(digit);
                }
            }

            RemoveLeadingZeros();
        }

        //удаляет ведущие нули
        private void RemoveLeadingZeros()
        {
            while (digits.Count > 1 && digits.Last() == 0)
            {
                digits.RemoveAt(digits.Count - 1);
            }
        }

        //возвращает строковое представление числа
        public string GetStringNumber()
        {
            if (digits.Count == 0) return "0";

            var result = new StringBuilder();

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (i == digits.Count - 1)
                    result.Append(digits[i]);
                else
                    result.Append(digits[i].ToString("D3"));

                if (i > 0) result.Append(" ");
            }

            return result.ToString();
        }

        //сложение больших чисел
        public void Add(BigNumber other)
        {
            int maxLength = Math.Max(digits.Count, other.digits.Count);
            int carry = 0;

            for (int i = 0; i < maxLength || carry > 0; i++)
            {
                if (i == digits.Count) digits.Add(0);

                int currentDigit = digits[i] + carry;
                if (i < other.digits.Count) currentDigit += other.digits[i];

                carry = currentDigit / Base;
                digits[i] = currentDigit % Base;
            }

            RemoveLeadingZeros();
        }

        //вычитание больших чисел
        public void Subtract(BigNumber other)
        {
            if (CompareAbsolute(other) < 0)
            {
                digits = new List<int> { 0 };
                return;
            }

            int borrow = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                int currentDigit = digits[i] - borrow;
                if (i < other.digits.Count) currentDigit -= other.digits[i];

                if (currentDigit < 0)
                {
                    borrow = 1;
                    currentDigit += Base;
                }
                else
                {
                    borrow = 0;
                }

                digits[i] = currentDigit;
            }

            RemoveLeadingZeros();
        }

        //умножение на дробный множитель
        public void Multiply(double multiplier)
        {
            if (multiplier == 1.0) return;

            double result = 0;
            double basePower = 1;

            for (int i = 0; i < digits.Count; i++)
            {
                result += digits[i] * basePower;
                basePower *= Base;
            }

            result *= multiplier;

            digits.Clear();

            if (result < 1)
            {
                digits.Add(0);
                return;
            }

            while (result >= 1)
            {
                digits.Add((int)(result % Base));
                result = Math.Floor(result / Base);
            }

            RemoveLeadingZeros();
        }

        //сравнение абсолютных значений
        public int CompareAbsolute(BigNumber other)
        {
            if (digits.Count != other.digits.Count)
                return digits.Count.CompareTo(other.digits.Count);

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (digits[i] != other.digits[i])
                    return digits[i].CompareTo(other.digits[i]);
            }

            return 0;
        }

        //проверка на ноль
        public bool IsZero()
        {
            return digits.Count == 1 && digits[0] == 0;
        }
    }
}
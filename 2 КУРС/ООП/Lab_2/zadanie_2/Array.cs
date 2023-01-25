using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace zadanie_2
{
    class Array
    {
        private readonly int _lowRange;
        private readonly int _highRange;

        private readonly Hashtable _Array;

        public int LowRange
        {
            get { return _lowRange; }
        }

        public int HighRange
        {
            get { return _highRange; }
        }
   
        public Array(int lowRange, int highRange) // возможность задания произвольных границ индексов при создании объекта
        {
            _Array = new Hashtable();
            _lowRange = lowRange;
            _highRange = highRange;
            // инициализация по типу int[]
            for (var i = _lowRange; i <= _highRange; i++)
            {
                _Array[i] = 0;
            }
        }
        public int FindInd(int n)
        {
            for (var i = _lowRange; i < _highRange; i++)
            {
                if (this[i] == n)
                {
                    return i;
                }
            }
            return Int32.MinValue;
        }
        public int this[int index] // возможность обращения к отдельному элементу массива с контролем выхода за пределы индексов
        {
            get
            {
                if (index < _lowRange || index > _highRange)
                {
                    throw new IndexOutOfRangeException("Значение индекса за пределами диапазона");
                }
                return (int)_Array[index];
            }
            set
            {
                if (index < _lowRange || index > _highRange)
                {
                    throw new IndexOutOfRangeException("Значение индекса за пределами диапазона");
                }
                _Array[index] = value;
            }
        }

        public static Array operator +(Array Array1, Array Array2) // выполнениe операций поэлементного сложения
        {
            if (Array1.LowRange != Array2.LowRange || Array1.HighRange != Array2.HighRange)
            {
                throw new NotSupportedException("Операция сложения векторов с разными границами не поддерживается");
            }
            var Array = new Array(Array1.LowRange, Array1.HighRange);
            for (var i = Array1.LowRange; i <= Array1.HighRange; i++)
            {
                Array[i] = Array1[i] + Array2[i];
            }
            return Array;
        }
       
        public static Array operator -(Array Array1, Array Array2) // вычитаниe массивов с одинаковыми границами индексов
        {
            if (Array1.LowRange != Array2.LowRange || Array1.HighRange != Array2.HighRange)
            {
                throw new NotSupportedException("Операция вычитания векторов с разными границами не поддерживается");
            }
            var Array = new Array(Array1.LowRange, Array1.HighRange);
            for (var i = Array1.LowRange; i <= Array1.HighRange; i++)
            {
                Array[i] = Array1[i] - Array2[i];
            }
            return Array;
        }
      
        public static Array operator *(Array Array1, int scalar) // умножениe всех элементов массива на скаляр
        {
            var Array = new Array(Array1.LowRange, Array1.HighRange);
            for (var i = Array1.LowRange; i <= Array1.HighRange; i++)
            {
                Array[i] = Array1[i] * scalar;
            }
            return Array;
        }
      
        public static Array operator /(Array Array1, int scalar) // делениe всех элементов массива на скаляр
        {
            var Array = new Array(Array1.LowRange, Array1.HighRange);
            for (var i = Array1.LowRange; i <= Array1.HighRange; i++)
            {
                Array[i] = Array1[i] / scalar;
            }
            return Array;
        }
        
        public override string ToString() // вывод на экран всего массива
        {
            string Arr=null;
            for (var i = _lowRange; i <= _highRange; i++)
            {
                Arr += _Array[i].ToString()+" ";
            }
            return Arr.ToString();
        }
    }
}

using System;
namespace ArrayLists
{
    public class ArrayList
    {
        public int Lenght { get; private set; }

        private const int _minArrayLenght = 10;

        private int[] _array;

        //3 конструктора 
        public ArrayList()//пустой
        {
            Lenght = 0;
            _array = new int[_minArrayLenght];
        }

        public ArrayList(int n)//на основе одного элемента
        {
            Lenght = 1;
            _array = new int[] { n };
        }

        public ArrayList(int[] array)//на основе массива
        {
            _array = new int[(int)(array.Length * 1.5 + 1)];
            Array.Copy(array, _array, array.Length);
            Lenght = array.Length;
        }



        //добавление значения в конец
        public void Add(int value)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }

            _array[Lenght] = value;
            Lenght++;
        }

        //добавление значения в начало
        public void AddInTheBegining(int value)
        {
            if (IsArrayFull())
            {
                UpArraySize();
            }

            for (int i = Lenght; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = value;
            Lenght++;
        }


        //добавление значения по индексу
        public void AddByIndex(int value, int index)
        {
            if (index < 0 || index > Lenght + 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (IsArrayFull())
            {
                UpArraySize();
            }

            for (int i = Lenght; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;
            Lenght++;
        }


        //удаление из конца одного элемента
        public void DeleteFronEnd()
        {
            if (Lenght > 0)
            {
                _array[Lenght - 1] = 0;  //не хочет класть null
                Lenght--;

            }
        }


        //удаление из начала одного элемента
        public void DeleteFromBegining()
        {
            if (Lenght > 0)
            {
                for (int i = 0; i < Lenght; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Lenght--;
            }
        }

        //удаление по индексу одного элемента
        public void DeleteByIndex(int index)
        {
            if (index < 0 || index > Lenght + 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (Lenght > 0)
            {
                for (int i = index; i <= Lenght; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Lenght--;
            }
        }

        // удаление из конца N элементов
        public void DeleteNElememtsFronEnd(int n)
        {
            if (n < 0 || n > Lenght)
            {
                throw new ArgumentException();
            }
            else if (Lenght > 0)
            {
                for (int i = Lenght - 1; i > Lenght - n; i--)
                {
                    _array[i] = _array[i + 1];

                }
                Lenght -= n;
            }

        }

        //удаление из начала N элементов
        public void DeleteNElememtsFronBegining(int n)
        {
            if (n < 0 || n > Lenght)
            {
                throw new ArgumentException();
            }
            else if (Lenght > 0)
            {
                for (int i = 0; i < Lenght - n; i++)
                {
                    _array[i] = _array[i + n];

                }
                Lenght -= n;
            }
        }

        //удаление по индексу N элементов
        public void DeleteNElememtsByIndex(int index, int n)
        {
            if (n < 0 || n > Lenght)
            {
                throw new ArgumentException();
            }
            if (index < 0 || index + n > Lenght)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Lenght > 0)
            {
                for (int i = index; i <= Lenght - n; i++)
                {
                    _array[i] = _array[i + n];
                }
                Lenght -= n;
            }
        }

        //вернуть длину??
        public int GetLenght()
        {
            return Lenght;
        }

        //доступ по индексу
        public int GetElementByIndex(int index)
        {

            if (index < 0 || index > Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _array[index];
            }
        }

        //первый индекс по значению
        public int FirstIndexByValue(int value)
        {
            if (Lenght > 0)
            {
                int index = -1;
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] == value)
                    {
                        return i;
                    }

                }

                return index;
            }
            else
            {
                throw new Exception();
            }
        }

        //изменение по индексу
        public void ChangeValueByIndex(int value, int index)
        {
            if (index < 0 || index > Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }

        //реверс (123 -> 321)
        public void GetReverse()
        {
            int oppoziteValue;
            for (int i = 0; i < Lenght / 2; i++)
            {
                oppoziteValue = _array[i];
                _array[i] = _array[Lenght - i - 1];
                _array[Lenght - i - 1] = oppoziteValue;
            }
        }

        //поиск значения максимального элемента
        public int GetMax()
        {
            if (Lenght > 0)
            {
                int max = _array[0];
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] > max)
                    {
                        max = _array[i];
                    }
                }
                return max;
            }
            else
            {
                throw new Exception();
            }
        }

        //поиск значения минимального элемента
        public int GetMin()
        {
            if (Lenght > 0)
            {
                int min = _array[0];
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] < min)
                    {
                        min = _array[i];
                    }
                }
                return min;
            }
            else
            {
                throw new Exception();
            }
        }

        //поиск индекс максимального элемента
        public int GetIndexOfMaxElement()
        {
            if (Lenght > 0)
            {
                int maxIndex = 0;
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] > _array[maxIndex])
                    {
                        maxIndex = i;
                    }
                }

                return maxIndex;
            }
            else
            {
                throw new Exception();
            }
        }

        //поиск индекс минимального элемента
        public int GetIndexOfMinElement()
        {
            if (Lenght > 0)
            {
                int minIndex = 0;
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] < _array[minIndex])
                    {
                        minIndex = i;
                    }
                }

                return minIndex;
            }
            else
            {
                throw new Exception();
            }
        }

        //сортировка по возрастанию
        public void GetSortAscending()
        {
            int nextValue;
            for (int i = 0; i < Lenght - 1; i++)
            {
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        nextValue = _array[i];
                        _array[i] = _array[j];
                        _array[j] = nextValue;
                    }
                }
            }
        }


        //сортировка по убыванию
        public void GetDescendingSort()
        {
            int nextValue;
            for (int i = 0; i < Lenght - 1; i++)
            {
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[i] < _array[j])
                    {
                        nextValue = _array[i];
                        _array[i] = _array[j];
                        _array[j] = nextValue;
                    }
                }
            }
        }


        //удаление по значению первого (?вернуть индекс)
        public int DeleteFirstElementAndGetIndex(int value)
        {

            int index = FirstIndexByValue(value);
            if (index >= 0)
            {
                DeleteByIndex(index);
                return index;
            }
            else
            {
                throw new Exception("There is not such value");
            }

        }

        //удаление по значению всех (?вернуть кол-во)
        public int DeleteAllElementsAndGetCount(int value)
        {
            if (Lenght > 0)
            {
                int count = 0;

                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] == value)
                    {
                        DeleteByIndex(i);
                        count++;
                    }
                }
                if (count > 0)
                {
                    return count;
                }
                else
                {
                    throw new Exception("There is not such value");
                }
            }
            else
            {
                throw new Exception("There is not such value");
            }
        }


        //добавление списка (вашего самодельного) в конец
        public void AddArrayListInTheEnd(ArrayList array)
        {

            int len = array.GetLenght();

            for (int i = 0; i < len; i++)
            {
                Add(array.GetElementByIndex(i));

            }

        }

        //добавление списка в начало
        public void AddArrayListInTheBegining(ArrayList array)
        {
            int len = array.GetLenght();

            for (int i = len - 1; i >= 0; i--)
            {
                AddInTheBegining(array.GetElementByIndex(i));

            }
        }


        //добавление списка по индексу
        public void AddArrayListByIndex(ArrayList array, int index)
        {
            int len = array.GetLenght();

            for (int i = len - 1; i >= 0; i--)
            {
                AddByIndex(array.GetElementByIndex(i), index);

            }
        }

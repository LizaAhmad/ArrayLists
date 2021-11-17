
using System;


namespace LinkedLists

{
    public class LinkedList
    {
        private Node _root;

        //3 конструктора(пустой, на основе одного элемента, на основе массива )

        public LinkedList()
        {
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
        }

        public LinkedList(int[] array)
        {
            if(array.Length == 0)
            {
                _root = null;
            }
            else
            {
                Node node = new Node(array[0]);
                _root = node;
                for(int i = 1; i < array.Length; i++)
                {
                    node.Next = new Node(array[i]);
                    node = node.Next;
                }
            }
        }

        //добавление значения в конец
        public void Add(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = new Node(value);
            }
            else
            {
                _root = new Node(value);
                
            }
        }

        //добавление значения в начало
        public void AddInTheBegining(int value)
        {
            if (_root != null)
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            else
            {
                _root = new Node(value);
            }
        }



        //добавление значения по индексу
        public void AddByIndex(int value, int index)
        {
            if(index > GetLength() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (_root == null)
            {
                _root = new Node(value);
            }

            else if (index == 0)
            {
                AddInTheBegining(value);
            }
            else if(index == GetLength())
            {
                Add(value);
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    if (i == index - 1)
                    {
                        Node tmpNode = tmp;
                        tmp = tmp.Next;
                        tmpNode.Next = new Node(value);
                        tmpNode.Next.Next = tmp;
                    }
                    tmp = tmp.Next;
                }
            }
        }


        //удаление из конца одного элемента
        public void DeleteFronEnd()
        {
            if (_root != null)
            {
                Node tmp = _root;

                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next;
            }
            else
            {
                throw new Exception();
            }
        }

        //удаление из начала одного элемента
        public void DeleteFromBegining()
        {
            if (_root != null)
            {
                _root = _root.Next;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        //удаление по индексу одного элемента
        public void DeleteByIndex(int index)
        {
            if (index > GetLength() || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null && index == 0)
            {
                _root = null;
                return;
            }
            if (_root != null)
            {
                Node tmp = _root;

                if (index == 0)
                {
                    DeleteFromBegining();
                }
                else
                {
                    for (int i = 1; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Next = tmp.Next.Next;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
}
        //удаление из конца N элементов
        public void DeleteNElememtsFronEnd(int n)
        {

            if (n < 0)
            {
                throw new ArgumentException();
            }
            else if (_root == null || (n > GetLength()))
            {
                throw new NullReferenceException();
            }
            else
            {
                Node tmp = _root;
                for (int i = 1; i < GetLength() - n; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
            }
        }




        //удаление из начала N элементов
        public void DeleteNElememtsFronBegining(int n)
        {
            if (_root == null || n > GetLength())
            {
                throw new NullReferenceException();
            }
            else if (n < 0)
            {
                throw new ArgumentException();
            }
            else if (_root.Next == null && n == 1)
            {
                _root = null;
                return;
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < n; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp;
            }
        }



        //удаление по индексу N элементов
        public void DeleteNElememtsByIndex(int index, int n)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_root == null || n + index > GetLength())
            {
                throw new NullReferenceException();
            }
            else if(n < 0)
            {
                throw new ArgumentException();
            }
            Node tmp = _root;
            if (index != 0)
            {
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                Node tmp2 = tmp;
                for (int i = 0; i < n; i++)
                {
                    tmp2 = tmp2.Next;
                }
                tmp.Next = tmp2.Next;
            }
            else
            {
                if (_root.Next == null && n == 1)
                {
                    _root = null;
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        tmp = tmp.Next;
                    }
                    _root = tmp;
                }
            }

        }

        //вернуть длину
        public int GetLength()
        {
            Node tmp = _root;
            int length = 0;

            if (tmp == null)
            {
                return length;
            }
            while(tmp != null)
            {
                length++;
                tmp = tmp.Next;
            }
            return length;
        }

        //доступ по индексу
        public int GetElementByIndex(int index)
        {
            if (index < 0 || index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }

            Node tmp = _root;
            for (int i = 0; i < index; i++)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }


        //первый индекс по значению
        public int FirstIndexByValue(int value)
        {
            if (_root != null)
            {
                int index = -1;

                Node tmp = _root;
                for (int i = 0; i < GetLength(); i++)
                {
                    if(tmp.Value == value)
                    {
                        return i;
                    }
                    tmp = tmp.Next;
                }
                return index;

            }
            else
            {
                throw new NullReferenceException();
            }
        }
        //изменение по индексу
        public void ChangeValueByIndex(int value, int index)
        {
            if (index < 0 || index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 0; i < index; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Value = value;

        }

        //реверс(123 -> 321)
        public void GetReverse()
        {
            if (_root != null)
            {
                Node oldRoot = _root;
                Node crnt;
                while (oldRoot.Next != null)
                {
                    crnt = oldRoot.Next;
                    oldRoot.Next = crnt.Next;
                    crnt.Next = _root;
                    _root = crnt;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        //поиск значения максимального элемента
        public int GetMax()
        {
            if (GetLength() > 0)
            {
                Node tmp = _root;
                int max = tmp.Value;
                for (int i = 0; i < GetLength(); i++)
                {
                    if (tmp.Value > max)
                    {
                        max = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return max;
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        //поиск значения минимального элемента
        public int GetMin()
            {
            if (GetLength() > 0)
            {
                Node tmp = _root;
                int min = tmp.Value;
                for (int i = 0; i < GetLength(); i++)
                {
                    if (tmp.Value < min)
                    {
                        min = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return min;
            }
            else
            {
                throw new NullReferenceException();
            }


        }



        //поиск индекс максимального элемента
        public int GetIndexOfMaxElement()
        {
            if (GetLength() > 0)
            {
                Node tmp = _root;
                int max = tmp.Value;
                int maxIndex = 0;
                for (int i = 0; i < GetLength(); i++)
                {
                    if (tmp.Value > max)
                    {
                        max = tmp.Value;
                        maxIndex = i;
                    }
                    tmp = tmp.Next;
                }
                return maxIndex;
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        //поиск индекс минимального элемента
        public int GetIndexOfMinElement()
        {
            if (GetLength() > 0)
            {
                Node tmp = _root;
                int min = tmp.Value;
                int minIndex = 0;
                for (int i = 0; i < GetLength(); i++)
                {
                    if (tmp.Value < min)
                    {
                        min = tmp.Value;
                        minIndex = i;
                    }
                    tmp = tmp.Next;
                }
                return minIndex;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        //сортировка по возрастанию
        public void GetSortAscending(int[] list)
        {
            if(GetLength() > 0)
            {
                LinkedList linkedList = new LinkedList(list);
                for(int i = 0; i < GetLength(); i++)
                {
                    linkedList.AddByIndex(GetMin(),GetIndexOfMinElement());
                    DeleteByIndex(GetIndexOfMinElement());

                }
            }
        }

            //сортировка по убыванию


            //удаление по значению первого(?вернуть индекс)
        public int DeleteFirstElementAndGetIndex(int value)
        {
            int index = FirstIndexByValue(value);
            DeleteByIndex(index);
            return index;
        }
        //удаление по значению всех(?вернуть кол-во)
        public int DeleteAllElementsAndGetCount(int value)
        {
            Node tmp = _root;
            int count = 0;
            for (int i = 0; i < GetLength(); i++)
            {
                if(_root.Value == value)
                {
                    DeleteByIndex(i);
                    count++;
                }
                _root = _root.Next;
            }
            return count;
        }
        //добавление списка(вашего самодельного) в конец
        public void AddArrayListInTheEnd(int[] array)
        {
            LinkedList linkedList = new LinkedList(array);
            Node tmp = linkedList._root;
            for(int i = 0; i < linkedList.GetLength(); i++)
            {
                Add(tmp.Value);
                tmp = tmp.Next;
            }
        }

        //добавление списка в начало
        public void AddArrayListInTheBegining(int[] array)
        {
            LinkedList linkedList = new LinkedList(array);
            Node tmp = linkedList._root;

            for (int i = 0; i < linkedList.GetLength(); i++)
            {
                AddByIndex(tmp.Value, i);
                tmp = tmp.Next;
            }
        }
        //добавление списка по индексу
        public void AddArrayListByIndex(int[] array, int index)
        {

            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > GetLength())
            {
                throw new NullReferenceException();
            }
             LinkedList linkedList = new LinkedList(array);
            Node tmp = linkedList._root;

            for (int i = 0; i < linkedList.GetLength(); i++)
            {
                AddByIndex(tmp.Value, index);
                tmp = tmp.Next;
                index++;
            }
        }















public void RemoveByIndex(int index)
        {
            Node tmp = _root;

            for (int i = 1; i < index - 1; i++)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;

        }


        public override string ToString()
        {
            Node node = _root;

            string s = "";
            
            while (node != null)
            {
                s += $"{node.Value} ";
                node = node.Next;
                
            }
            return s;
        }


        public void WriteToConsole()
        {
            Node tmp1;
            tmp1 = _root;
            for (int i = 0; i < GetLength(); i++)
            {
                Console.Write($"{tmp1.Value} ");
                tmp1 = tmp1.Next;
            }
            Console.WriteLine();
        }


        public override bool Equals(object obj)
        {
            LinkedList node = (LinkedList)obj; //что тут происходит?
            Node tmp1;
            Node tmp2;

            tmp1 = _root;
            tmp2 = node._root;

            if (tmp1 == null && tmp2 == null)
            {
                return true;
            }
            while(tmp1 != null && tmp2 != null)
            {
                if ((tmp1 != null && tmp2 == null) ||
                    (tmp1 == null && tmp2 != null))
                {
                    return false;
                }
                if(tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

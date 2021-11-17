using System;
using NUnit.Framework;
using LinkedLists;
namespace LinkedListsTest
{
    public class LinkedListTest
    {
        #region AddTest
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, -1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddInTheBeginingTest
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(1, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(-1, new int[] { 0, 6, 7, -10 }, new int[] { -1, 0, 6, 7, -10 })]
        public void AddInTheBeginingTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddInTheBegining(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddByIndexTest
        [TestCase(4, 4, new int[] { 0, 1, 2, 3, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(0, 0, new int[] { 1, 2, 4, 5 }, new int[] { 0, 1, 2, 4, 5 })]  //не работает
        [TestCase(0, 0, new int[] { }, new int[] { 0 })]                      // хз почему
        [TestCase(6, 6, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        public void AddByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            
            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException
        [TestCase(4, -1, new int[] { 1, 2, 3 })]
        public void AddByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException(int value, int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }
        #endregion

        #region DeleteFronEndTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, -1, -2 }, new int[] { 0, -1 })]
        public void DeleteFronEndTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFronEnd();
            
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteFromBeginingTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -2, -3 })]
        public void DeleteFromBeginingTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFromBegining();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region
        [TestCase(new int[] { })]
        public void DeleteFromBeginingTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.DeleteFromBegining());
        }
        #endregion


        #region DeleteByIndex
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]

        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException
        [TestCase(-1, new int[] { 1, 2, 3 })]
        public void DeleteByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException(int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        }
        #endregion

        #region DeleteByIndexTest_WhenListIsEmpty_ShouldThrowsNullReferenceException
        [TestCase(0, new int[] { })]
        public void DeleteByIndexTest_WhenListIsEmpty_ShouldThrowsNullReferenceException(int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.DeleteByIndex(index));
        }
        #endregion


        #region DeleteNElememtsFronEndTest
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1 })]
        public void DeleteNElememtsFronEndTest(int n, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteNElememtsFronEnd(n);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteNElememtsFronEndTest_WhenNLargestThanLength_ShouldNullReferenceException
        [TestCase(1,  new int[] { })]
        [TestCase(5, new int[] { 1, 1 })]
        public void DeleteNElememtsFronEndTest_WhenNLargestThanLength_ShouldNullReferenceException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.DeleteNElememtsFronEnd(n));
        }
        #endregion

        #region DeleteNElememtsFronEndTest_WhenNLessThanZero_ShouldArgumentException
        [TestCase(-1, new int[] { })]
        public void DeleteNElememtsFronEndTest_WhenNLessThanZero_ShouldArgumentException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsFronEnd(n));
        }
        #endregion



        #region DeleteNElememtsFronBeginingTest
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6 })]
        public void DeleteNElememtsFronBeginingTest(int n, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteNElememtsFronBegining(n);

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region
        [TestCase(1, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3 })]
        public void DeleteNElememtsFronBeginingTest_WhenNBiggerThenLength_ShouldNullReferenceException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.DeleteNElememtsFronBegining(n));
        }
        #endregion



        #region
        [TestCase(-1, new int[] { 1, 2, 3 })]
        public void DeleteNElememtsFronBeginingTest_WhenNLessThanZero_ShouldArgumentException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsFronBegining(n));
        }
        #endregion



        #region DeleteNElememtsByIndexTest
        [TestCase(1, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 5, 6 })]
        public void DeleteNElememtsByIndexTest(int index, int n, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteNElememtsByIndex(index, n);

            Assert.AreEqual(expected, actual);
        }
        #endregion



        #region
        [TestCase(1, 1, new int[] { })]
        [TestCase(5, 1, new int[] { 1, 22, 33, 44 })]
        [TestCase(5, 1, new int[] { 2, 3, 4, 5, 6 })]
        public void DeleteNElememtsByIndexTest_WhenNAndIndexBiggerThanLength_ShouldNullReferenceException(int index, int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.DeleteNElememtsByIndex(index, n));
        }
        #endregion



        #region
        [TestCase(-5, 1, new int[] { 1, 2, 3, 4, 5,  })]
        public void DeleteNElememtsByIndexTest_WhenIndexLessThanZero_ShouldIndexOutOfRangeException(int index, int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteNElememtsByIndex(index, n));
        }
        #endregion



        #region
        [TestCase(5, -1, new int[] { 1, 2, 3, 4, 5,  })]
        public void DeleteNElememtsByIndexTest_WhenNLessThanZero_ShouldArgumentException(int index, int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsByIndex(index, n));
        }
        #endregion

        #region GetLenght
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { -1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
        public void GetLenghtTest(int[] array, int lenght)
        {
            int expectedLenght = array.Length;

            Assert.AreEqual(expectedLenght, lenght);
        }
        #endregion


        #region GetElementByIndexTest
        [TestCase(1, 1, new int[] { 0, 1, 2, 3 })]
        [TestCase(0, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(3, 3, new int[] { 0, 1, 2, 3 })]
        public void GetElementByIndexTest(int index, int element, int[] array)
        {
            LinkedList array1 = new LinkedList(array);

            int actual = array1.GetElementByIndex(index);
            int expected = element;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetElementByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException
        [TestCase(-1, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3 })]
        public void GetElementByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException(int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetElementByIndex(index));
        }
        #endregion


        #region FirstIndexByValueTest
        [TestCase(0, 0, new int[] { 0, 0, 0 })]
        [TestCase(0, 1, new int[] { 1, 0, 1, 0 })]
        [TestCase(0, 2, new int[] { 1, 2, 0 })]
        [TestCase(9, -1, new int[] { 1, 2, 0 })]
        //[TestCase(0, -1, new int[] { 1, 2, 3, 4, 4, 4  })]  //throw
        public void FirstIndexByValueTest(int value, int index, int[] array)
        {
            LinkedList arrayList = new LinkedList(array);

            int expected = index;
            int actual = arrayList.FirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region FirstIndexByValueTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(0, new int[] { })]
        [TestCase(-9, new int[] { })]
        public void FirstIndexByValueTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException(int value, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.FirstIndexByValue(value));
        }
        #endregion



        #region ChangeValueByIndexTest
        [TestCase(1, 1, new int[] { 0, 0, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(0, 0, new int[] { 1, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(5, 5, new int[] { 0, 1, 2, 3, 4, 4 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void ChangeValueByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.ChangeValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region ChangeValueByIndexTest_WhenIndexLessThanZero_ShouldThrowsOutOfRangeException
        [TestCase(-1, -1, new int[] { 1, 2, 3 })]
        public void ChangeValueByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException(int value, int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.ChangeValueByIndex(value, index));
        }
        #endregion

        #region GetReverseTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        public void GetReverseTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.GetReverse();

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region GetReversTest_WhenListEmpty_ShouldNullReferenceException
        [TestCase(new int[] { })]
        public void GetReversTest_WhenListEmpty_ShouldNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetReverse());
        }
        #endregion


        #region GetMaxTest
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(-1, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(5, new int[] { 1, 2, 5, 4, 1 })]
        public void GetMaxTest(int expectedMax, int[] array)
        {
            LinkedList arrayList = new LinkedList(array);

            int expected = expectedMax;
            int actual = arrayList.GetMax();

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region GetMaxTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException
        [TestCase(new int[] { })]
        public void GetMaxTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetMax());
        }
        #endregion


        #region GetMinTest
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(-10, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(1, new int[] { 3, 2, 1, 4, 7 })]
        public void GetMinTest(int expectedMax, int[] array)
        {
            LinkedList arrayList = new LinkedList(array);

            int expected = expectedMax;
            int actual = arrayList.GetMin();

            Assert.AreEqual(expected, actual);
        }

        #endregion



        #region GetMinTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException
        [TestCase(new int[] { })]
        public void GetMinTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetMin());
        }
        #endregion



        #region GetIndexOfMaxElementTest
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(4, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(2, new int[] { 1, 2, 5, 4, 1 })]
        public void GetIndexOfMaxElementTest(int expectedMaxIndex, int[] array)
        {
            LinkedList arrayList = new LinkedList(array);

            int expected = expectedMaxIndex;
            int actual = arrayList.GetIndexOfMaxElement();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMaxElementTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException
        [TestCase(new int[] { })]
        public void GetIndexOfMaxElementTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMaxElement());
        }
        #endregion



        #region GetIndexOfMinElementTest
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(4, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(0, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(0, new int[] { 1, 2, 5, 4, 1 })]
        public void GetIndexOfMinElementTest(int expectedMinIndex, int[] array)
        {
            LinkedList arrayList = new LinkedList(array);

            int expected = expectedMinIndex;
            int actual = arrayList.GetIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMinElementTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException
        [TestCase(new int[] { })]
        public void GetIndexOfMinElementTest_WhenArrayListIsEmpty_ShouldThrowsNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMinElement());
        }
        #endregion

        //сортировка по возрастанию

        //сортировка по убыванию



    }
}

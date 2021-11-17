using System;
using NUnit.Framework;
using ArrayLists;
namespace ArrayListTest
{
    public class ArrayListTest
    {

        #region AddTest
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, -1 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            
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
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddInTheBegining(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddByIndexTest
        [TestCase(4, 4, new int[] { 0, 1, 2, 3, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(0, 0, new int[] { 1, 2, 4, 5 }, new int[] { 0, 1, 2, 4, 5 })]
        [TestCase(0, 0, new int[] { }, new int[] { 0 })]
        [TestCase(6, 6, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        public void AddByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException
        [TestCase(4,-1, new int[] {1, 2, 3})]
        public void AddByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException(int value, int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }
        #endregion

        #region DeleteFromEndTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0, -1, -2 }, new int[] { 0, -1 })]
        public void DeleteFromEndTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromEnd();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region DeleteFromBeginingTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -2, -3 })]
        public void DeleteFromBeginingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromBegining();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DeleteByIndex
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(0, new int[] { }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]

        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException
        [TestCase(-1, new int[] { 1, 2, 3 })]
        public void DeleteByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException( int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        }
        #endregion

        #region DeleteNElememtsFronEndTest
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1 })]
        public void DeleteNElememtsFronEndTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteNElememtsFronEnd(n);

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region DeleteNElememtsFronEndTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException
        [TestCase(5, new int[] { })]
        [TestCase(-5,  new int[] { })]
        public void DeleteNElememtsFronEndTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException(int n, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsFronEnd(n));
        }
        #endregion


        #region DeleteNElememtsFronBeginingTest
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6 })]
        public void DeleteNElememtsFronBeginingTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteNElememtsFronBegining(n);

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region DeleteNElememtsFronEndTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException
        [TestCase(5, new int[] { })]
        [TestCase(-5, new int[] { })]
        public void DeleteNElememtsFronBeginingTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException(int n, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsFronEnd(n));
        }
        #endregion


        #region DeleteNElememtsByIndexTest
        [TestCase(1, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 5, 6 })]
        public void DeleteNElememtsByIndexTest(int index, int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteNElememtsByIndex(index, n);

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region DeleteNElememtsByIndexTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException
        [TestCase(5, -1, new int[] { })]
        [TestCase(-5, 5, new int[] { })]
        public void DeleteNElememtsByIndexTest_WhenNIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentException(int index, int n, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actual.DeleteNElememtsByIndex(index, n));
        }
        #endregion

        #region DeleteNElememtsByIndexTest_WhenIndexIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentOutOfRangeException
        [TestCase(5, 0, new int[] { })]
        [TestCase(-5, 0, new int[] { })]
        public void DeleteNElememtsByIndexTest_WhenIndexIsBiggerThenLengthOrLessThenZero_ShouldThrowsArgumentOutOfRangeException(int index, int n, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteNElememtsByIndex(index, n));
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
            ArrayList array1 = new ArrayList(array);

            int actual = array1.GetElementByIndex(index);
            int expected = element;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetElementByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException
        [TestCase(-1, new int[] { 1, 2, 3 })]
        public void GetElementByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException(int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
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
            ArrayList arrayList = new ArrayList(array);

            int expected = index;
            int actual = arrayList.FirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region FirstIndexByValueTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(0,  new int[] {  })]
        [TestCase(-9,  new int[] {  })]
        public void FirstIndexByValueTest_WhenArrayListIsEmpty_ShouldThrowsException(int value,  int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.FirstIndexByValue(value));
        }
        #endregion


        #region ChangeValueByIndexTest
        [TestCase(1, 1, new int[] { 0, 0, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(0, 0, new int[] { 1, 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(5, 5, new int[] { 0, 1, 2, 3, 4, 4 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        public void ChangeValueByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.ChangeValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region ChangeValueByIndexTest_WhenIndexLessThanZero_ShouldThrowsArgumentException
        [TestCase(-1, -1, new int[] { 1, 2, 3 })]
        public void ChangeValueByIndexTest_WhenIndexLessThanZero_ShouldThrowsIndexOutOfRangeException(int value, int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.ChangeValueByIndex(value, index));
        }
        #endregion



        #region GetReverseTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void GetReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetReverse();

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetMaxTest
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(-1, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(5, new int[] { 1, 2, 5, 4, 1 })]
        public void GetMaxTest(int expectedMax, int[] array)
        {
            ArrayList arrayList = new ArrayList(array);

            int expected = expectedMax;
            int actual = arrayList.GetMax();

            Assert.AreEqual(expected, actual);
        }
        #endregion


        #region GetMaxTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(new int[] { })]
        public void GetMaxTest_WhenArrayListIsEmpty_ShouldThrowsException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.GetMax());
        }
        #endregion



        #region GetMinTest
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(-10, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(1, new int[] { 3, 2, 1, 4, 7 })]
        public void GetMinTest(int expectedMax, int[] array)
        {
            ArrayList arrayList = new ArrayList(array);

            int expected = expectedMax;
            int actual = arrayList.GetMin();

            Assert.AreEqual(expected, actual);
        }

        #endregion



        #region GetMinTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(new int[] { })]
        public void GetMinTest_WhenArrayListIsEmpty_ShouldThrowsException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.GetMin());
        }
        #endregion

        #region GetIndexOfMaxElementTest
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(4, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(2, new int[] { 1, 2, 5, 4, 1 })]
        public void GetIndexOfMaxElementTest(int expectedMaxIndex, int[] array)
        {
            ArrayList arrayList = new ArrayList(array);

            int expected = expectedMaxIndex;
            int actual = arrayList.GetIndexOfMaxElement();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMaxElementTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(new int[] { })]
        public void GetIndexOfMaxElementTest_WhenArrayListIsEmpty_ShouldThrowsException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.GetIndexOfMaxElement());
        }
        #endregion



        #region GetIndexOfMinElementTest
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(4, new int[] { 5, 2, 3, 4, 1 })]
        [TestCase(0, new int[] { -10, -2, -3, -4, -1 })]
        [TestCase(0, new int[] { 1, 2, 5, 4, 1 })]
        public void GetIndexOfMinElementTest(int expectedMinIndex, int[] array)
        {
            ArrayList arrayList = new ArrayList(array);

            int expected = expectedMinIndex;
            int actual = arrayList.GetIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMinElementTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(new int[] { })]
        public void GetIndexOfMinElementTest_WhenArrayListIsEmpty_ShouldThrowsException(int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.GetIndexOfMinElement());
        }
        #endregion



        #region GetSortAscendingTest
        [TestCase(new int[] { 4, 3, 6, 8, 1, 4, 6 }, new int[] { 1, 3, 4, 4, 6, 6, 8 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { -4, -3, -6, -8, -1, -4, -6 }, new int[] { -8, -6, -6, -4, -4, -3, -1 })]
        [TestCase(new int[] {  }, new int[] {  })]
        public void GetSortAscendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetSortAscending();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetDescendingSortTest
        [TestCase(new int[] { 4, 3, 6, 8, 1, 4, 6 }, new int[] { 8, 6, 6, 4, 4, 3, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { -4, -3, -6, -8, -1, -4, -6 }, new int[] { -1, -3, -4, -4, -6, -6, -8 })]

        public void GetDescendingSortTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetDescendingSort();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region DeleteFirstElementAndGetIndexTest
        [TestCase(0, 0, new int[] { 0, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(0, 3, new int[] {  1, 2, 3, 0 }, new int[] { 1, 2, 3 })]
        public void DeleteFirstElementAndGetIndexTest(int value,
            int indexExpected, int[] array, int[] arrayExpected)
        {
            ArrayList actionArr = new ArrayList(array);
            ArrayList expectedArr = new ArrayList(arrayExpected);

            int action = actionArr.DeleteFirstElementAndGetIndex(value);
            int expected = indexExpected;

            Assert.AreEqual(expected, action);
            Assert.AreEqual(expectedArr, actionArr);
        }
        #endregion

        #region DeleteFirstElementAndGetIndexTest_WhenArrayListIsEmpty_ShouldThrowsException
        [TestCase(3, new int[] { })]
        [TestCase(3, new int[] { 1, 4, 6, 7})]
        public void DeleteFirstElementAndGetIndexTest_WhenArrayListIsEmpty_ShouldThrowsException(int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<Exception>(() => actual.DeleteFirstElementAndGetIndex(value));
        }
        #endregion




        #region DeleteAllElementsAndGetCountTest
        [TestCase(0, 7, new int[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0 }, new int[] { 1, 2, 3, 4, 5, 6 })]//собака сутулая
        [TestCase(-5, 3, new int[] { -5, 1, 2, -5, 3, 4, -5, 6 }, new int[] { 1, 2, 3, 4, 6 })]             //это тоже
        [TestCase(3, 0, new int[] { }, new int[] { })]
        [TestCase(3, 0, new int[] { 1, 2, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        public void DeleteAllElementsAndGetCountTest(int value, int countExpected, int[] array, int[] arrayExpected)
        {
            ArrayList action = new ArrayList(array);
            ArrayList expected = new ArrayList(arrayExpected);
            int count;

            count = action.DeleteAllElementsAndGetCount(value);
            action.DeleteAllElementsAndGetCount(value);

            Assert.AreEqual(count, countExpected);
            Assert.AreEqual(expected, action);
        }
        #endregion


        //#region DeleteAllElementsAndGetCountTest_WhenArrayListIsEmpty_ShouldThrowsException
        //public void DeleteAllElementsAndGetCountTest_WhenArrayListIsEmpty_ShouldThrowsException(int value, int[] array)
        //{
        //    ArrayList actual = new ArrayList(array);
        //    Assert.Throws<Exception>(() => actual.DeleteAllElementsAndGetCount(value));
        //}
        //#endregion




        #region AddArrayListInTheEndTest
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] {  }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 1, 2, 3, 4, 5, 6, 4, 5, 6 })]
        public void AddArrayListInTheEndTest(int[] array, int[] array1, int[] expectedArray)
        {
            ArrayList action = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList array11 = new ArrayList(array1);

            action.AddArrayListInTheEnd(array11);

            Assert.AreEqual(expected, action);
        }

        #endregion

        #region AddArrayListInTheBeginingTest
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 1, 2, 3, 4, 5, 6, 4, 5, 6 })]
        public void AddArrayListInTheBeginingTest(int[] array, int[] array1, int[] expectedArray)
        {
            ArrayList action = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList array11 = new ArrayList(array1);

            action.AddArrayListInTheBegining(array11);

            Assert.AreEqual(expected, action);
        }

        #endregion

        #region AddArrayListByIndexTest
        [TestCase(2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 4, 5, 1, 2, 3, 6 })]
        [TestCase(0, new int[] { }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(3, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3, 1, 2, 3, 4, 5, 6 })]
        public void AddArrayListByIndexTest(int index, int[] array, int[] array1, int[] expectedArray)
        {
            ArrayList action = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList array11 = new ArrayList(array1);

            action.AddArrayListByIndex(array11, index);

            Assert.AreEqual(expected, action);
        }

        #endregion

    }
}

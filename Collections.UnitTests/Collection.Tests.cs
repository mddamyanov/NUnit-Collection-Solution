using Collections;
using NUnit.Framework;
using System.Linq;
using System;

namespace Collection.Tests
{
    public class CollectionTest
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange
            var nums = new Collection<int>();

            //Assert
            Assert.That(nums.Count == 0);
            Assert.That(nums.Capacity == 0);
            Assert.AreEqual(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);
            Assert.That(nums.Count, Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 10, 15);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }

        [Test]
        public void Test_Collection_Add()
        {
            // Arrange
            var nums = new Collection<int>();

            // Act
            nums.Add(5);
            nums.Add(6);

            // Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_AddRange()
        {

        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");

            // Act
            var item0 = names[0];
            var item1 = names[1];

            // Assert
            Assert.That(item0, Is.EqualTo("Peter"));
            Assert.That(item1, Is.EqualTo("Maria"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Bob", "Joe");
            Assert.That(() => { var name = names[-1]; },
                  Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
                  Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
                  Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {

        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {

        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {

        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {

        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {

        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {

        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {

        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {

        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {

        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {

        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {

        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {

        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {

        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {

        }

        [Test]
        public void Test_Collection_RemoveAll()
        {

        }

        [Test]
        public void Test_Collection_Clear()
        {

        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {

        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {

        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {

        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {

        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {

        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);

        }
    }
}
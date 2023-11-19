using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using GroundWork.Core.Extensions;

namespace GroundWork.Core.Tests;

[TestClass]
public class EnumerableExtensionTest
{
    [TestMethod]
    public void Can_convert_enumrable_to_json()
    {
        IEnumerable<int> list = new List<int>()
        {
            1, 2, 3, 4, 5
        };

        var jsonString = list.ToJSON();

        Assert.AreEqual(jsonString.GetType(), typeof(string));

        Assert.AreEqual(jsonString, "[1,2,3,4,5]");
    }

    [TestMethod]
    public void combine_lists()
    {
        IEnumerable<int> listA = new List<int>() { 1, 2, 3 };
        IEnumerable<int> listB = new List<int>() { 4, 5 };
        IEnumerable<int> listC = new List<int>() { 6, 7 };

        var fullList = listA.Concat(listB, listC);

        Assert.IsTrue(fullList.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6 , 7 }));
    }

    /*
     * 
     * 
     */

    [TestMethod]
    public void Access_first_element()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5 };

        int last = list.First();

        Assert.AreEqual(last, 1);
    }

    [TestMethod]
    public void Access_last_element()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        int last = list.Last();

        Assert.AreEqual(last, 5);
    }


    [TestMethod]
    public void Returns_the_first_n_elements()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };


        var take = list.Take(3);

        Assert.IsTrue(take.SequenceEqual(new List<int>() { 1, 2, 3 }));
    }

    [TestMethod]
    public void Returns_the_elements_after_n_elements()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        var x = list.Skip(2).Take(2);

        Assert.IsTrue(x.SequenceEqual(new List<int>() { 3, 4 }));
    }


    [TestMethod]
    public void Remove_first_element()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5 };

        list.RemoveAt(0);

        Assert.IsTrue(list.SequenceEqual(new List<int>() { 1, 2, 3, 4 }));
    }

    [TestMethod]
    public void Remove_last_element()
    {
        var listA = new List<int>() { 1, 2, 3, 4, 5 };

        listA.RemoveAt(listA.Count - 1);

        Assert.IsTrue(listA.SequenceEqual(new List<int>() { 1, 2, 3, 4 }));

    }

    //[TestMethod]
    //public void Remove_first_element_and_return_it()
    //{
    //    var listA = new List<int>() { 1, 2, 3, 4, 5 };

    //    var listB = listA.Take(1);

    //    //Assert.IsTrue(listB.SequenceEqual(new List<int>() { 1, 2, 3, 4 }));

    //    var firstElement = listA.Shift();

    //    var a = 1;
    //}

    [TestMethod]
    public void Add_an_element_to_the_beginning()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        list = list.Prepend(0);

        Assert.IsTrue(list.SequenceEqual(new List<int>() { 0, 1, 2, 3, 4, 5 }));
    }

    [TestMethod]
    public void Add_an_element_to_the_end()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        list = list.Append(6);

        Assert.IsTrue(list.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }));
    }

    [TestMethod]
    public void Removes_a_specified_element()
    {
        //TODO: Doesnt seem to remove the element
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        list.Remove(x => x == 1);

        Assert.IsTrue(list.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }));
    }

    [TestMethod]
    public void Can_reverse_collection()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        var reversed = list.Reverse();

        Assert.IsTrue(reversed.SequenceEqual(new List<int>() { 5, 4, 3, 2, 1 }));
    }

    [TestMethod]
    public void Can_return_new_collection_based_on_predicate()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        var newList = list.Where((x, index) => x >= 4);

        Assert.IsTrue(newList.SequenceEqual(new List<int>() { 4, 5 }));
    }

    [TestMethod]
    public void Can_check_if_the_argument_given_is_included_in_collection()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        var exits = list.Any(x => x == 3);

        Assert.IsTrue(exits);
    }

    [TestMethod]
    public void Can_flatten_collection_into_one_dimensional_collection()
    {
        IEnumerable<IEnumerable<int>> list = new List<List<int>>() {
            new List<int>() { 1, 2 },
            new List<int>() { 3, 4, 5 },
            new List<int>() { 6 },
        };

        var flattenList = list.SelectMany(a => a.Select(b => b));

        Assert.IsTrue(flattenList.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }));
    }

    [TestMethod]
    public void Can_transform_elements_of_collection()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        var transformedList = list.Select((x, index) => x * index);

        Assert.IsTrue(transformedList.SequenceEqual(new List<int>() { 0, 2, 6, 12, 20 }));
    }

    [TestMethod]
    public void Can_remove_duplicate_elements()
    {
        IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5, 5, 5, 2, 1, 0 };

        var uniqueList = list.Distinct();

        Assert.IsTrue(uniqueList.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 0 }));

    }


}


/*
 *  First
 *  Last
 *  Take
 *  Drop ( = skip(3).take(3))
 *  Shift = RemoveAt(0)
 *  Unshift = Insert(0, element)
 *  Push = Add
 *  Map or Collect = Select
 *  
 *  
 *  
 */
# Collections

## Types

### System.Collections

> * Contain **object** references
>   * box and unbox value types as required


### System.Collections.Generic

> * Contain the **appropriate** data type
> * Reduce boxin and unboxing overhead

### Collections Interfaces
> System.Collections
> * IEnumerator
> * IEnumerable
> * ICollection: IEnumerable
> * IDictionary: ICollection, IEnumerable
> * IList: ICollection, IEnumerable

> System.Collections.Generic
> * IEnumerator &lt;T> : IEnumerator, IDisposable
> * IEnumerable &lt;T> : IEnumerable
> * ICollection &lt;T>: IEnumerable&lt;T>, IEnumerable
> * IList: ICollection&lt;T>, IEnumerable&lt;T>, IEnumerable
### Enumerators
Enumerators can be used to read the data in the collection, but they cannot be used to modify the underlying collection.

#### IEnumerator

> Properties
> * object Current (only get)
> 
> Methods
> * bool MoveNext();
> * void Reset();

#### IEnumerator&lt;T>

> Properties
> * T Current (only get)

#### IEnumerable

> Methods
> * IEnumerator GetEnumerator()

#### IEnumerable&lt;T>

> Properties
> * IEnumerator&lt;T> GetEnumerator();



#### Enumeration - Iteration
Enumeration refers to the process of iterating (stepping) through a collection. Use the iterator design pattern

#### When to use
The only thing you want is to iterate over the elements in a collection. You only need read-only access to that collection

##### Yield
Yield allows each iteration in a foreach-loop be generated only when needed. In this way it can improve performance.

##### Enumerables
Allows use of foreach on a collection


##### Example 
EnumeratorExample



## Collections 
### ICollection
> Properties
> * int Count (only get)
> * bool IsSynchronized (only get)
> 
> Methods
> * object SyncRoot
> * void CopyTo(Array array, int index);

### ICollection&lt;T>
> Properties
> * int Count (only get)
> * bool IsReadOnly (only get)
> 
> Methods
> * void Add(T item)
> * void Clear() 
> * bool Contains(T item)
> * void CopyTo(T[] array, int arrayIndex)
> * bool Remove(T item)

#### When to use
You want to modify the collection or you care about its size.

#### Implementations

* **Queue&lt;T>** (Use items first-in-first-out (FIFO))
* **Stack&lt;T>** (Use data Last-In-First-Out (LIFO))
* **LinkedList&lt;T>** (Access items sequentially)
* **HashSet&lt;T>** (A set for mathematical functions)
* **SortedSet&lt;T>** (A set for mathematical functions)
* **BitArray** (Manages a compact array of bit values, provides bit functions)





## Dictionaries 
### IDictionary
> Properties
> * object this[object key]
> * bool IsFixedSize (only get)
> * bool IsReadOnly (only get)
> * ICollection Keys (only get)
> * ICollection Values (only get)
> 
> Methods
> * void Add(object key, object value)
> * void Clear()
> * bool Contains(object key)
> * IDictionaryEnumerator GetEnumerator()
> * void Remove(object key)

#### When to use
If your indexes have a special meaning besides just positional placement.


#### Implementations

* **Dictionary&lt;TKey, TValue>** (Store items as key/value pairs for quick look-up by key)
* **Hashtable** (A collection of key/value pairs that are organize based on the hash code of the key.)
* **SortedList&lt;TKey, TValue>** (A sorted collection)
* **ListDictionary** (faster for looking up an element in a small collection, but performance benefits are at best minimal)
* **SortedDictionary&lt;TKey, TValue>** (A dictionary that are sorted on the key)
* **HybridDictionary** (Implements IDictionary by using ListDictionary while the collection is small, and then switching to a Hashtable when the collection gets large.)

#### Hashing
* GetHashCode() is called on the key
* Keys are grouped into “buckets”
  * This reduces the number of lookups needed to access
  * Inside a bucket items are stored in a linear array
* If the maximum ratio of entries-to-buckets (called the load factor) is reached, more buckets are allocated and the entries are redistributed. (Expensive)
* You may set the load factor when you create the Hashtable
  * Default is 1.0 (an average of 1 item per bucket)
  * Smaller load factor means faster lookups but take more memory
  * Load factor values can be between .1 and 1.0

### List

### IList
> Properties
> * object this[int index]
> * bool IsFixedSize (only get)
> * bool IsReadOnly (only get)
> 
> Methods
> * int Add(object value)
> * void Clear()
> * bool Contains(object value)
> * int IndexOf(object value)
> * void Insert(int index, object value)
> * void Remove(object value)
> * void RemoveAt(int index)

### IList&lt;T>
> Properties
> * T this[int index]
> 
> Methods
> * int IndexOf(T item);
> * void Insert(int index, T item);
> * void RemoveAt(int index);

#### Implementations

* **List&lt;T>** (Access items by index)
* **ArrayList** (Access items by index)
* **ObservableCollection&lt;T>** (Receive notifications when items are removed or added to the collection.)

#### Capacity
* When count is equal to capacity and element is added:
  *  A new array of twice the size is allocated
  *  The old elements are copied into the new location
  *  Expensive
* Set your Capacity upon creation if possible
* Default capacity is 4
* Don’t change it once it is set
  * It will change for you if it needs to



### Searching and Sorting


#### IComparable

> Methods
> * int CompareTo(object obj)

#### IComparable&lt;T>

> Methods
> * int CompareTo(T other)

* Required for binary searching and sorting
* Applies to items inside the Collection
  * An item is said to be “Comparable” to another
* Comparable items inside a collection can be sorted and searched


#### IComparer

> Methods
> * int Compare(object x, object y)

#### IComparer&lt;T>

> Methods
> * int Compare(T x, T y)


* Strategy Design Pattern
* Plug in a new comparer object for different results
* Can be applied to objects that are not “Comparable”
* Can be applied to override the comparable functionality that may already exist


### IReadOnlyCollection

> Properties
> * int Count (only get)

ReadOnlyCollection makes an array or List read-only. With this type from System.Collections.ObjectModel, we provide a collection of elements that cannot be changed. But it may be possible to change some elements themselves.


### IQueryable 
Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.


### Indexers

An indexer provides array-like syntax. It allows a type to be accessed the same way as an array. Properties such as indexers often access a backing store.


#### Syntax:
```c
Public <return type> this[<parameter type> index]
{
    Get{
        // return the value from the specified index
    }
    Set{
        // set values at the specified index
    }
}
```


### For vs Foreach

ForForEachExample


### Topics to explore
* IDbset
* LINQ

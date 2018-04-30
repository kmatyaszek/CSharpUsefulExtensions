# CSharpUsefulExtensions
This library is a collection of useful extension methods in C#.

## Methods

### String methods:
* Left
```
"abcdefghijk".Left(4) = "abcd"
"abcd".Left(10) = "abcd"
```

* Right
```
"abcdefghijk".Right(4) = "hijk"
"abcd".Right(10) = "abcd"
```

* AppendIfMissing
```
"my_string".AppendIfMissing(null) = "my_string"
"my_string".AppendIfMissing("mySuffix") = "my_stringmySuffix"
```

* PrependIfMissing
```
"my_string".PrependIfMissing(null) = "my_string"
"my_string".PrependIfMissing("MyPrefix") = "MyPrefixmy_string"
```

### StringBuilder methods:
* IsEmpty
```
StringBuilder builder = new StringBuilder();

var isEmpty = builder.IsEmpty(); // isEmpty = true
```

* IsNullOrEmpty
```
StringBuilder builder = null;

var isEmpty = builder.IsNullOrEmpty(); // isEmpty = true
```

* IsNullOrWhiteSpace
```
StringBuilder builder = new StringBuilder("\t\t");

var isEmpty = builder.IsNullOrWhiteSpace(); // isEmpty = true
```

### Guid methods:
* IsEmpty
```
Guid guid;

var isEmpty = guid.IsEmpty(); // isEmpty = true
```

### DateTime methods:
* FirstDayOfTheMonth
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).FirstDayOfTheMonth() = DateTime(2018, 4, 1, 15, 15, 15, 15)
```

* FirstDayOfTheMonthWithTime
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).FirstDayOfTheMonthWithTime(12, 12, 12, 12) = DateTime(2018, 4, 1, 12, 12, 12, 12)
```

* LastDayOfTheMonth
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).LastDayOfTheMonth() = DateTime(2018, 4, 30, 15, 15, 15, 15)
```

* LastDayOfTheMonthWithTime
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).LastDayOfTheMonthWithTime(12, 12, 12, 12) = DateTime(2018, 4, 30, 12, 12, 12, 12)
```

* WithTime
```
new DateTime(2018, 4, 24, 20, 07, 32).WithTime(21, 15, 10) = DateTime(2018, 4, 24, 21, 15, 10)
```

* IterateDayByDayTo
```
var startDate = new DateTime(2018, 4, 1);
var endDate = new DateTime(2018, 4, 7);

var result = startDate.IterateDayByDayTo(endDate);
// result = { new DateTime(2018, 4, 1), new DateTime(2018, 4, 2), new DateTime(2018, 4, 3), new DateTime(2018, 4, 4), new DateTime(2018, 4, 5), new DateTime(2018, 4, 6), new DateTime(2018, 4, 7) }
```
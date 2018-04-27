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
* IsNullOrEmpty
* IsNullOrWhiteSpace

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

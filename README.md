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

### DateTime methods:
* FirstDayOfTheMonth
* FirstDayOfTheMonthWithTime
* LastDayOfTheMonth
* LastDayOfTheMonthWithTime
* WithTime

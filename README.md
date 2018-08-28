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

* ToStream
```
var myString = "myString";

using (var stream = myString.ToStream(Encoding.UTF8))
{
    ...
}
```

* Reverse
```
var myString = "12345";
myString.Reverse() // "54321"
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
new DateTime(2018, 4, 23, 15, 15, 15, 15).FirstDayOfTheMonth() // DateTime(2018, 4, 1, 15, 15, 15, 15)
```

* FirstDayOfTheMonthWithTime
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).FirstDayOfTheMonthWithTime(12, 12, 12, 12) // DateTime(2018, 4, 1, 12, 12, 12, 12)
```

* LastDayOfTheMonth
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).LastDayOfTheMonth() // DateTime(2018, 4, 30, 15, 15, 15, 15)
```

* LastDayOfTheMonthWithTime
```
new DateTime(2018, 4, 23, 15, 15, 15, 15).LastDayOfTheMonthWithTime(12, 12, 12, 12) // DateTime(2018, 4, 30, 12, 12, 12, 12)
```

* WithTime
```
new DateTime(2018, 4, 24, 20, 07, 32).WithTime(21, 15, 10) // DateTime(2018, 4, 24, 21, 15, 10)
```

* NextDay
```
new DateTime(2018, 5, 8).NextDay() // new DateTime(2018, 5, 9)
```

* PreviousDay
```
new DateTime(2018, 5, 8).PreviousDay() // new DateTime(2018, 5, 7)
```

* IterateDayByDayTo
```
var startDate = new DateTime(2018, 4, 1);
var endDate = new DateTime(2018, 4, 7);

var result = startDate.IterateDayByDayTo(endDate);
// result = { new DateTime(2018, 4, 1), new DateTime(2018, 4, 2), new DateTime(2018, 4, 3), new DateTime(2018, 4, 4), new DateTime(2018, 4, 5), new DateTime(2018, 4, 6), new DateTime(2018, 4, 7) }
```

* IterateDayByDayFor
```
var startDate = new DateTime(2018, 5, 2);
int numOfDays = 7;
var result = startDate.IterateDayByDayFor(numOfDays);
// result = { new DateTime(2018, 5, 2), new DateTime(2018, 5, 3), new DateTime(2018, 5, 4), new DateTime(2018, 5, 5), new DateTime(2018, 5, 6), new DateTime(2018, 5, 7), new DateTime(2018, 5, 8) }
```

* IsWorkingDay
```
var date = new DateTime(2018, 5, 7);
var result = date.IsWorkingDay(); // true
```

* IsWorkingDayWithHolidayChecking
```
var date = new DateTime(2018, 5, 7);
var holidays = new[] { date };
var result = date.IsWorkingDayWithHolidayChecking(holidays); // false
```

* GetContinuousDaysRange
```

public static IEnumerable<DateTimeRange> GetContinuousDaysRange(this IEnumerable<DateTime> source) {...}

public class DateTimeRange
{
    private DateTimeRange(DateTime startDateTime, DateTime endDateTime)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

    public static DateTimeRange Of(DateTime startDateTime, DateTime endDateTime)
    {
        return new DateTimeRange(startDateTime, endDateTime);
    }

    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
}

Example:

DateTime firstDay = new DateTime(2018, 5, 7);
DateTime secondDay = new DateTime(2018, 5, 8);
DateTime thirdDay = new DateTime(2018, 5, 9);
IEnumerable<DateTime> source = new List<DateTime>() { firstDay, secondDay, thirdDay };

var result = source.GetContinuousDaysRange(); 
// result is enumeration with one item  DateTimeRange.Of(new DateTime(2018, 5, 7), new DateTime(2018, 5, 9))
```
* IsToday
```
var tomorrow = DateTime.Now.AddDays(1);
var result = tomorrow.IsToday(); // false
```

* IsPastDate
```
var today = DateTime.Now;
var result = today.IsPastDate(); // false
```

* IsFutureDate
```
var today = DateTime.Now;
var result = today.IsFutureDate(); // false
```

### Argument checking:

* ThrowIfNull
```
string nulParameter = null;
string notNullParameter = "parameter";

nulParameter.ThrowIfNull(); // throw new ArgumentNullException();
nulParameter.ThrowIfNull("param"); // throw new ArgumentNullException("param");
nulParameter.ThrowIfNull("param", "Exception message"); // throw new ArgumentNullException("param", "Exception message");
nulParameter.ThrowIfNull(() => nulParameter); // throw new ArgumentNullException("nulParameter");
nulParameter.ThrowIfNull(() => nulParameter, "Exception message"); // throw new ArgumentNullException("nulParameter", "Exception message");
notNullParameter.ThrowIfNull(); // ArgumentNullException is not thrown
```

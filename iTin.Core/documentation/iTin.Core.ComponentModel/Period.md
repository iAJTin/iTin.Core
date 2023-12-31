# Period class

Class which defines a time period.

```csharp
public class Period : ICloneable, IComparable<Period>, IEquatable<Period>
```

## Public Members

| name | description |
| --- | --- |
| [Period](Period/Period.md)() | Initializes a new instance of the [`Period`](./Period.md) class. |
| [Period](Period/Period.md)(…) | Initializes a new instance of the [`Period`](./Period.md) class. |
| static [FromMoment](Period/FromMoment.md)(…) | Returns a new [`Period`](./Period.md) for current date for single moment. (2 methods) |
| static [FromMoments](Period/FromMoments.md)(…) | Returns a new [`Period`](./Period.md) for current date between the specified times. (2 methods) |
| [Duration](Period/Duration.md) { get; } | Gets the duration. |
| [EndDateTime](Period/EndDateTime.md) { get; } | Gets the end date time. |
| [StartDateTime](Period/StartDateTime.md) { get; } | Gets the start date time. |
| [Clone](Period/Clone.md)() | Clones this instance. |
| [CompareTo](Period/CompareTo.md)(…) | Compares the current object with another object of the same type. |
| override [Equals](Period/Equals.md)(…) | Returns a value that indicates whether this class is equal to another |
| [Equals](Period/Equals.md)(…) | Indicates whether the current object is equal to another object of the same type. |
| override [GetHashCode](Period/GetHashCode.md)() | Returns a value that represents the hash code for this class. |
| [Overlaps](Period/Overlaps.md)(…) | Indicates whether both periods are overlapses. |
| [ToEpochPeriod](Period/ToEpochPeriod.md)() | Returns a new [`EpochPeriod`](./EpochPeriod.md) from this [`Period`](./Period.md). |
| override [ToString](Period/ToString.md)() | Returns a String that represents this instance. |
| static [CurrentDate](Period/CurrentDate.md) { get; } | Gets the current date. |
| static [CurrentTime](Period/CurrentTime.md) { get; } | Gets the current time. |
| static [CreateEpochPeriod](Period/CreateEpochPeriod.md)(…) | Returns a new epoch period from a period instance. |
| static [NaturalPeriodsBetweenTwoMoments](Period/NaturalPeriodsBetweenTwoMoments.md)(…) | Returns a list of natural [`Period`](./Period.md) that represents time line between two moments. |
| static [SequentialPeriodsFromMoments](Period/SequentialPeriodsFromMoments.md)(…) | Returns a list of [`Period`](./Period.md) that represents time line for specified moment list. |

## See Also

* namespace [iTin.Core.ComponentModel](../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

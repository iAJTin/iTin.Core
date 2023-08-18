# SentinelHelper.ArgumentNotFinite method

Performs a check against a method argument, and throws a  if it is not a finite number eg NaN, PositiveInfinity or NegetiveInfinity.

```csharp
public static void ArgumentNotFinite(string parameter, float argument)
```

| parameter | description |
| --- | --- |
| parameter | The name of the method parameter. |
| argument | The value being passed as an argument. |

## Exceptions

| exception | condition |
| --- | --- |
| NotFiniteNumberException | If *argument* is not a finite number. |

## See Also

* class [SentinelHelper](../SentinelHelper.md)
* namespace [iTin.Core.Helpers](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->
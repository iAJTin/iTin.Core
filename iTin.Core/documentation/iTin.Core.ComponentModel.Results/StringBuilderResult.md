# StringBuilderResult class

Specialization of the interface [`ResultBase`](../iTin.Core.ComponentModel/ResultBase-1.md) that contains a StringBuilder result.

```csharp
public class StringBuilderResult : ResultBase<StringBuilder>
```

## Public Members

| name | description |
| --- | --- |
| [StringBuilderResult](StringBuilderResult/StringBuilderResult.md)() | The default constructor. |
| static [CreateErrorResult](StringBuilderResult/CreateErrorResult.md)(…) | Returns a new [`StringBuilderResult`](./StringBuilderResult.md) with specified detailed error. (4 methods) |
| static [CreateSuccessResult](StringBuilderResult/CreateSuccessResult.md)(…) | Returns a new success result. |
| static [FromException](StringBuilderResult/FromException.md)(…) | Creates a new [`StringBuilderResult`](./StringBuilderResult.md) instance from known exception. (2 methods) |

## See Also

* class [ResultBase&lt;T&gt;](../iTin.Core.ComponentModel/ResultBase-1.md)
* namespace [iTin.Core.ComponentModel.Results](../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->
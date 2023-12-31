# TimeSpanResponse class

Specialization of the interface [`ResponseBase`](../iTin.Core.ComponentModel/ResponseBase-1.md) that contains a timespan response.

```csharp
public class TimeSpanResponse : ResponseBase<TimeSpan>
```

## Public Members

| name | description |
| --- | --- |
| [TimeSpanResponse](TimeSpanResponse/TimeSpanResponse.md)() | The default constructor. |
| static [CreateErroResponse](TimeSpanResponse/CreateErroResponse.md)(…) | Returns a new [`TimeSpanResponse`](./TimeSpanResponse.md) with specified detailed error. (2 methods) |
| static [CreateSuccessResponse](TimeSpanResponse/CreateSuccessResponse.md)(…) | Returns a new success response. |
| static [FromException](TimeSpanResponse/FromException.md)(…) | Creates a new [`TimeSpanResponse`](./TimeSpanResponse.md) instance from known exception. |

## See Also

* class [ResponseBase&lt;T&gt;](../iTin.Core.ComponentModel/ResponseBase-1.md)
* namespace [iTin.Core.ComponentModel.Responses](../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

# PeriodResponse.CreateErroResponse method (1 of 2)

Returns a new [`PeriodResponse`](../PeriodResponse.md) with specified detailed errors collection.

```csharp
public static PeriodResponse CreateErroResponse(IResponseError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`PeriodResponse`](../PeriodResponse.md) with specified detailed errors collection.

## See Also

* interface [IResponseError](../../iTin.Core.ComponentModel/IResponseError.md)
* class [PeriodResponse](../PeriodResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

---

# PeriodResponse.CreateErroResponse method (2 of 2)

Returns a new [`PeriodResponse`](../PeriodResponse.md) with specified detailed error.

```csharp
public static PeriodResponse CreateErroResponse(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`PeriodResponse`](../PeriodResponse.md) with specified detailed error.

## See Also

* class [PeriodResponse](../PeriodResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

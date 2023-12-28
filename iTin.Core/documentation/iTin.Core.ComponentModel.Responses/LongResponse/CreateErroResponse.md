# LongResponse.CreateErroResponse method (1 of 2)

Returns a new [`LongResponse`](../LongResponse.md) with specified detailed errors collection.

```csharp
public static LongResponse CreateErroResponse(IResponseError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`LongResponse`](../LongResponse.md) with specified detailed errors collection.

## See Also

* interface [IResponseError](../../iTin.Core.ComponentModel/IResponseError.md)
* class [LongResponse](../LongResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

---

# LongResponse.CreateErroResponse method (2 of 2)

Returns a new [`LongResponse`](../LongResponse.md) with specified detailed error.

```csharp
public static LongResponse CreateErroResponse(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`LongResponse`](../LongResponse.md) with specified detailed error.

## See Also

* class [LongResponse](../LongResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->
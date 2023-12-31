# NullableBooleanResponse.CreateErroResponse method (1 of 2)

Returns a new [`NullableBooleanResponse`](../NullableBooleanResponse.md) with specified detailed errors collection.

```csharp
public static NullableBooleanResponse CreateErroResponse(IResponseError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`NullableBooleanResponse`](../NullableBooleanResponse.md) with specified detailed errors collection.

## See Also

* interface [IResponseError](../../iTin.Core.ComponentModel/IResponseError.md)
* class [NullableBooleanResponse](../NullableBooleanResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

---

# NullableBooleanResponse.CreateErroResponse method (2 of 2)

Returns a new [`NullableBooleanResponse`](../NullableBooleanResponse.md) with specified detailed error.

```csharp
public static NullableBooleanResponse CreateErroResponse(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`NullableBooleanResponse`](../NullableBooleanResponse.md) with specified detailed error.

## See Also

* class [NullableBooleanResponse](../NullableBooleanResponse.md)
* namespace [iTin.Core.ComponentModel.Responses](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

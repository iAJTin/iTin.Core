# ResponseBase&lt;T&gt;.CreateErroResponse method (1 of 2)

Returns a new [`ResponseBase`](../ResponseBase-1.md) with specified detailed errors collection.

```csharp
public static ResponseBase CreateErroResponse(IResponseError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`ResponseBase`](../ResponseBase-1.md) with specified detailed errors collection.

## See Also

* interface [IResponseError](../IResponseError.md)
* class [ResponseBase&lt;T&gt;](../ResponseBase-1.md)
* namespace [iTin.Core.ComponentModel](../../iTin.Core.md)

---

# ResponseBase&lt;T&gt;.CreateErroResponse method (2 of 2)

Returns a new [`ResponseBase`](../ResponseBase-1.md) with specified detailed error.

```csharp
public static ResponseBase CreateErroResponse(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`ResponseBase`](../ResponseBase-1.md) with specified detailed error.

## See Also

* class [ResponseBase&lt;T&gt;](../ResponseBase-1.md)
* namespace [iTin.Core.ComponentModel](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

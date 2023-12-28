# StreamExtensions.AsByteArrayAsync method (1 of 2)

Returns stream input as byte array asynchronously.

```csharp
public static Task<byte[]> AsByteArrayAsync(this Stream stream, 
    CancellationToken cancellationToken = default)
```

| parameter | description |
| --- | --- |
| stream | Stream to convert. |
| cancellationToken | A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

## Return Value

Array of byte that represent the input stream.

## See Also

* class [StreamExtensions](../StreamExtensions.md)
* namespace [iTin.Core](../../iTin.Core.md)

---

# StreamExtensions.AsByteArrayAsync method (2 of 2)

Returns stream input as byte array asynchronously.

```csharp
public static Task<byte[]> AsByteArrayAsync(this Stream stream, bool closeAfter, 
    CancellationToken cancellationToken = default)
```

| parameter | description |
| --- | --- |
| stream | Stream to convert. |
| closeAfter | if set to true close stream after convert it. |
| cancellationToken | A cancellation token that can be used by other objects or threads to receive notice of cancellation. |

## Return Value

Array of byte that represent the input stream.

## See Also

* class [StreamExtensions](../StreamExtensions.md)
* namespace [iTin.Core](../../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->
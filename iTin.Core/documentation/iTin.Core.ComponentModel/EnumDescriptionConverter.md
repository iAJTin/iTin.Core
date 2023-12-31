# EnumDescriptionConverter class

Provides a type converter to convert enumeration types to String and from String to enumeration types.

```csharp
public abstract class EnumDescriptionConverter : EnumConverter
```

## Public Members

| name | description |
| --- | --- |
| override [ConvertFrom](EnumDescriptionConverter/ConvertFrom.md)(…) | Convierte el objeto de valor especificado en un objeto de enumeración. |
| override [ConvertTo](EnumDescriptionConverter/ConvertTo.md)(…) | Converts the value in the destination type. |

## Protected Members

| name | description |
| --- | --- |
| [EnumDescriptionConverter](EnumDescriptionConverter/EnumDescriptionConverter.md)(…) | Initializes a new instance of the [`EnumDescriptionConverter`](./EnumDescriptionConverter.md) class for specified enum type. |

## Remarks

This converter obtains the value by reflection from the attribute [`EnumDescriptionAttribute`](./EnumDescriptionAttribute.md) associated with the enum type.

## See Also

* namespace [iTin.Core.ComponentModel](../iTin.Core.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.dll -->

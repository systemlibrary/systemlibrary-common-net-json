# Installation

## Install nuget package

* Open your project/solution in Visual Studio
* Open Nuget Project Manager
* Search and install SystemLibrary.Common.Net.Json

## First time usage

- Classes and methods can be used out of the box by including the namespace they live in

- Sample:
```csharp  
	public class Car{
	}
	
	public void Test() 
	{
		var car = new Car();
		var json = car.ToJson(); //Extension method inside this package
	}
```

## Override default module's configurations
* Example of all default configurations in this package:

appSettings.json:
```json  
	{

		"systemLibraryCommonNetJson": {
			"maxDepth": 32,
			"propertyNameCaseInsensitive": true,
			"writeIndented": false
		}
	}
```  

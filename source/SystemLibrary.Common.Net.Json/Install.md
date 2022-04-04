# Installation

# DEPRECATED/OBSOLETE
- All code from this repo is copy pasted into SystemLibrary.Common.Net version >= 2.0.1.2:
- https://github.com/systemlibrary/systemlibrary-common-net#latest-version

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

## Package Configurations
* Default (and modifiable) configurations in this package:

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

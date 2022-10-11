# FluentAssociation
A data mining library for finding tightly connected elements in a database using apriori algorithm and association rules.

## Installation
Download by dotnet cli:  

```   
  Install-Package FluentAssociation  
```

### Release Notes
- Inclusion of method GetReportItemSets(ushort quantity), 
that can generate reports with any quantity of itemSets.
- Change to 0 the MinSuport property default value in FluentAssociation instance.

### Use Mode:

Data instantiation and loading:		

![image](https://user-images.githubusercontent.com/30809620/195217760-de9a479b-698e-45f9-8fdc-42e910c9f191.png)  

Or if it is a web application, include in Startup.cs:		

![services](https://user-images.githubusercontent.com/30809620/68983591-754ddc00-07ea-11ea-8fb8-a4415ba6731f.PNG)  

Then just use one of the following methods to get a report that is basically a list of combinations of the
different list elements along with Support and Confidence metrics:

* GetReport1ItemSets()  
* GetReport2ItemSets()  
* GetReport3ItemSets()  
* GetReport4ItemSets()
* GetReportItemSets(ushort quantity)

Example of how to get the metrics report:  
![image](https://user-images.githubusercontent.com/30809620/195216806-b0f9d57c-431a-4289-8aca-9ff8b106fdb3.png)  


Example of how to get the most reliable report:  
![image](https://user-images.githubusercontent.com/30809620/195217130-485b0fbc-913d-46dc-bbb4-ac8835fa749f.png)

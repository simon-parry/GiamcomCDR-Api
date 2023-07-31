
**GiacomCDR-Api**
Api written in .NET6 with Visual Studio 2022, using a Code First approach

For purposes of this test the Api has been configured to use SQL Lite rather than a direct database connection.
Api is structured with a CQRS pattern with a generic repository pattern using Entity Framework for accessing the database

[SOLID](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design))  is a set of object-oriented software principles that are expressed quite well in the CQRS architecture.

CQRS states that commands need to be separate from queries.  A method does one thing and one thing only, either returning data or changing it. Thus, CQRS is a great expression of the single responsibility principle.

Includes  Swagger api documentation 

**Packages Used**

 - CsvHelper Version="30.0.1" 
 -  MediatR Version="12.1.1"
 -  Microsoft.EntityFrameworkCore Version="7.0.9"
 -  Microsoft.EntityFrameworkCore.Sqlite Version="7.0.9"  
 -  Microsoft.EntityFrameworkCore.Tools Version="7.0.9" 
 - Newtonsoft.Json Version="13.0.3" 
 - Swashbuckle.AspNetCore Version="6.5.0"

**Running the application**
- pull the repo
- build API
- run update-database to create sql lite db

application is seeded to start with 5 test rows of data

**Unit Tests**
Written in XUnit with Moq
Only a selection of unit tests have been added, this is just to give an idea, was conscious of time.

**Endpoints**

***/api/CallDetailRecord/GetCallRecords***

parameters: startDate, endDate

returns all call records based off a date range

***/api/CallDetailrecord/GetCallRecordsByCallerId***

paramters: callerId

returns call records from a caller id

***/api/CallDetailRecords/GetCallerTotals***

paramters: callerId

returns: selection of call totals and Averages for a caller_id

***/api/CallDetailRecord/DeleteCallRecord***

paramters: callerId

Deletes a call record off the database primary key

***/api/UploadFile/ImportData***

 - Method Saves file first 
 - Imports Data 
 - Removes Uploaded File

Because files can be quite large, the api uses **streaming** via [MultipartReader] rather than using **buffering** via [IFormFile], which is more suited for larger files

NOTE: The endpoint has been written to add the records in using Entity Framework. There may be speed issues with this depending on file size, possibly the file may need chunking before adding to the database or using a different approach to EF such as dapper. You could also make use of message queuing here when processing the file chunks which would minimise any loss of data when importing a file which may contain invalid records/data

returns: fileSize

Going forward:

 - More work on custom exceptions, rather than a global one. 
 - Finish missing Unit tests. 
 - Data sanitisation for import file (valid phone
   numbers, duplicate entries). 
 - Add Logging (NLog ?).

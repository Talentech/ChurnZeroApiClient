# ChurnZero Api Client
.NET Standard API Client for ChurnZero API

## Versioning NuGet package

**Format:**  
`[major]`.`[minor]`.`[patch]`

Package version is not incremented automaticly. If you do some changes, you should change package version as follows: 

>**MAJOR** version when you make incompatible API changes

>**MINOR** version when you add functionality in a backwards-compatible manner

>**PATCH** version when you make backwards-compatible bug fixes.


## Create nuget package with dependencies

```git
nuget pack -Prop Configuration=Release -IncludeReferencedProjects
```

## How do I use it?

#### 1. Add ChurnZeroApiClient.Lib nuget package 
#### 2. In your **appsettings.json** insert ChurnZeroSettings:
  ```json
  "ChurnZeroSettings": {
    "ApiBaseUrl": "https://eu1analytics.churnzero.net/i",
    "AppKey": "Your App Key from ChurnZero"
  } 
```
#### 3. Register AddChurnZeroApiClient services in Startup.cs or Program.cs: 
 ```c#
services.AddChurnZeroApiClient(Configuration);
```
#### 4. Call api methods, e.g.: 
 ```c#
var trackEventResponse = await serviceProvider.GetService<IChurnZeroClient>().TrackEventAsync(new TrackEventRequest
{
    AccountExternalId = "test",
    ContactExternalId = "test@test.com",
    EventName = "sample-event-test"
});
```


## Examples
 
https://github.com/Talentech/ChurnZeroApiClient/tree/master/examples/ChurnZeroApiClientExamples

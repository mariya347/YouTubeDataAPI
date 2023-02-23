# API

```csharp
APIController aPIController = client.APIController;
```

## Class Name

`APIController`


# Youtube Search

Youtube Search

```csharp
YoutubeSearchAsync(
    string part,
    string q,
    Models.TypeEnum? type = null,
    Models.VideoDefinitionEnum? videoDefinition = null,
    string key = null,
    string channelId = null,
    string channelType = null,
    Models.EventTypeEnum? eventType = null,
    string location = null,
    string locationRadius = null,
    int? maxResults = 5,
    Models.OrderEnum? order = Models.OrderEnum.Relevance,
    Models.VideoCaptionEnum? videoCaption = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `part` | `string` | Query, Required | Comma-separated list of resource properties to include in the response. |
| `q` | `string` | Query, Required | Search query term(s). Cannot be used with other parameters. |
| `type` | [`Models.TypeEnum?`](../../doc/models/type-enum.md) | Query, Optional | Comma-separated list of resource types to search for. |
| `videoDefinition` | [`Models.VideoDefinitionEnum?`](../../doc/models/video-definition-enum.md) | Query, Optional | Specifies the definition of the video(s) to retrieve. |
| `key` | `string` | Query, Optional | API key. Required unless you provide an OAuth 2.0 token. |
| `channelId` | `string` | Query, Optional | The channelId parameter indicates that the API response should only contain resources created by the channel. |
| `channelType` | `string` | Query, Optional | The channelType parameter lets you restrict a search to a particular type of channel. |
| `eventType` | [`Models.EventTypeEnum?`](../../doc/models/event-type-enum.md) | Query, Optional | The eventType parameter restricts a search to broadcast events. If you specify a value for this parameter, you must also set the type parameter's value to video. |
| `location` | `string` | Query, Optional | The location parameter, in conjunction with the locationRadius parameter, defines a circular geographic area and also restricts a search to videos that specify, in their metadata, a geographic location that falls within that area. The parameter value is a string that specifies latitude/longitude coordinates e.g. (37.42307,-122.08427).  If you specify a value for this parameter, you must also set the type parameter's value to video. |
| `locationRadius` | `string` | Query, Optional | The locationRadius parameter, in conjunction with the location parameter, defines a circular geographic area. |
| `maxResults` | `int?` | Query, Optional | The maxResults parameter specifies the maximum number of items that should be returned in the result set. Acceptable values are 0 to 50, inclusive.<br>**Default**: `5` |
| `order` | [`Models.OrderEnum?`](../../doc/models/order-enum.md) | Query, Optional | The order parameter specifies the method that will be used to order resources in the API response.<br>**Default**: `OrderEnum.relevance` |
| `videoCaption` | [`Models.VideoCaptionEnum?`](../../doc/models/video-caption-enum.md) | Query, Optional | The videoCaption parameter indicates whether the API should filter video search results based on whether they have captions. If you specify a value for this parameter, you must also set the type parameter's value to video. |

## Response Type

[`Task<Models.SearchListResponse>`](../../doc/models/search-list-response.md)

## Example Usage

```csharp
string part = "part2";
string q = "q0";
int? maxResults = 5;
OrderEnum? order = OrderEnum.Relevance;

try
{
    SearchListResponse result = await aPIController.YoutubeSearchAsync(part, q, null, null, null, null, null, null, null, null, maxResults, order, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | `ApiException` |
| 403 | Forbidden. | `ApiException` |
| 404 | Not found. | `ApiException` |


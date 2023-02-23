
# Search List Response

## Structure

`SearchListResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Kind` | `string` | Optional | Identifies the API resource's type |
| `Etag` | `string` | Optional | The Etag of this resource |
| `NextPageToken` | `string` | Optional | The token that can be used as the value of the pageToken parameter to retrieve the next page in the result set. |
| `PrevPageToken` | `string` | Optional | The token that can be used as the value of the pageToken parameter to retrieve the previous page in the result set. |
| `RegionCode` | `string` | Optional | The region code that was used for the search query. |
| `PageInfo` | [`Models.PageInfo`](../../doc/models/page-info.md) | Optional | - |
| `Items` | `object` | Optional | A list of results that match the search criteria. |

## Example (as JSON)

```json
{
  "kind": null,
  "etag": null,
  "nextPageToken": null,
  "prevPageToken": null,
  "regionCode": null,
  "pageInfo": null,
  "items": null
}
```


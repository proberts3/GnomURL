# GnomURL
URL Shortening Service

## Requirements:
- Creating and Deleting short URLs with associated long URLs.
- Getting the long URL from a short URL.
- Getting statistics on the number of times a short URL has been "clicked," i.e., the number of times its long URL has been retrieved.
- Entering a custom short URL or letting the app randomly generate one while maintaining the uniqueness of short URLs.

## Design Considerations
- No Persistence Layer, can mock but use in-memory
- Single long URL can map to multiple short URLs

## Additional Considerations
- Valid URL (URI) RFC3986[https://datatracker.ietf.org/doc/html/rfc3986] ASCII
- Support IRI? RFC3987[https://datatracker.ietf.org/doc/html/rfc3987] UTF-8

## Dev Notes
Scaffolded with https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-react?view=vs-2022&viewFallbackFrom=aspnetcore-8.0

- I decided to only support valid URLs at this point in time. I would have had to do extra validations for foreign characters.
- It would be a good idea to add some more client-side validators for character length.
- You would want to add a loading state and indicator
- I got stuck on Vite's proxy setting so I settled for having all short URL redirects be under the G/ path
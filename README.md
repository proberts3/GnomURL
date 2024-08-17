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
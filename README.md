# AccessPointMap

The project consists of two elements:
- mobile application,
- web service.

The mobile application built on the basis of Xamarin technology collects information about geolocation and about occurring access points. 
The server has a REST API that manages queries between the application, website frontend and database. The site presents access points on the map using the Google Maps API and shows various statistics using ChartJS. The router manufacturer is also detected thanks to the MacVendors API.

Changelog:
- 1.2b:
    - Adding an option to save access point informations locally to a JSON file except of sending them to the REST API
    - Library update to new stable versions
- 1.1b:
    - Adding an algorithm which in kilometers expresses the area in which the given access point is available.
    - Signal level not changing bug fixed
- 1.0b 

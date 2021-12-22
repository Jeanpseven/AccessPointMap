![apm logo](https://user-images.githubusercontent.com/46250989/123469319-2b96bb80-d5f3-11eb-9b53-d8be8fa73c0b.png)
#  AccessPointMap

The AccessPointMap project can be described as "White hat war-driving". AccessPointMap consists in collecting and analyzing data about access points, their security and geolocation (without connecting to the network or interacting with it in any way). In contrast to similar projects like (WiGLE), the project does not focus on statistics on a global, but on a local scale. The main assumption of the project is to pay attention to the lack of education and knowledge of people about their own networks, which often have a default, unsafe configuration. project consists in collecting and analyzing data on access points. From the technical side, the project consists of a mobile application for gathering information. The information is then sent to a server where the analysis is performed, the data is stored in a database and can be viewed through the web application. For data security purposes, everyone can individually have their own AccessPointMap instance. Everyone can join the project by creating their own scanning algorithms or writing integrations for other network-device scanning programs.
A more detailed description of the entire project can be found in the PDF file (*outdated*).

##  Segments

The project consists of several parts:

- MariaDB database (*SQL Server earlier*)

- ASP.NET Core REST API

- Angular client/administration application

- Xamarin mobile application for collecting data (*The concept has been dropped and it is suggested to use one of the integrations*)

- A special device based on the ESP8266 microcontroller used to collect data slightly more efficiently than the mobile application (*The concept has been dropped and it is suggested to use one of the integrations*)

## Integrations

- [Wigle](https://github.com/wiglenet/wigle-wifi-wardriving) - The project has been adapted to the data collected by the WiGLE WiFi Wardriving application. The data collected by the application are analyzed, processed and prepared for integration with other access points already in the system. The collected data is sent to the server in CSV format.

- [Aircrack-ng](https://github.com/aircrack-ng/aircrack-ng) (*under development*)  - The project has been adapted to the data collected by the airodump-ng segment. The data collected by the application are analyzed, processed and prepared for integration with other access points already in the system. Geolocation data collection is also supported. The collected data is sent to the server in CSV format.

- [Kismet](https://github.com/kismetwireless/kismet) (under development)

## Use Cases

- **For network administrators** - Mapping local access points can facilitate the work of maintaining and servicing extensive network infrastructures.

- **For Internet Service Providers (ISPs)** - Mapping access points in a given town or city can provide valuable information related to the further expansion of Internet services or future marketing efforts.

- **For students and teachers** - The project can be a valuable teaching aid showing the operation and features of wireless networks. In addition, mapping a school or campus network can facilitate the administration and maintenance of such a network.

- **For "home network administrators"** - You can map all your home access points and make sure they are properly secured.

##  Technology stack

The basic technology stack used by the project. As a "historical curiosity" it is worth noting that the application has changed a lot over time and was initially written in PHP, then it was transferred to NodeJS using ExpressJS, and then it was transferred to the .NET platform and is constantly evolving:

- [.NET Core](https://dotnet.microsoft.com) - a open-source, cross-platform, managed computer software framework for Windows, Linux, and macOS operating systems.

- [Angular](https://angular.io) - a open-source web application framework that allows you to create "Single-Page" client interfaces.

- [MariaDb](https://mariadb.org/) - a fork of the MySQL database solution characterized by support for multiple architectures and high performance.

- [Docker](https://www.docker.com) - Virtualization at the operating system level. The division into microservices provides high scalability of the entire project.

- [Hangfire](https://www.hangfire.io) - An easy way to perform background processing in .NET and .NET Core applications.

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Modern object-database mapper for .NET Core

- [OpenLayers](https://openlayers.org) - This technology makes it easy to put a dynamic map in any web page.

- [ChartJS](https://www.chartjs.org) - Simple yet flexible JavaScript charting for designers & developers

## Roadmap

Functionalities that need to be implemented or repaired:

✅ Adding the OUI lookup service based on the Wireshark database to eliminate dependencies on the external MacVendor API. 

✅ Implementation of the Aircrack-ng integration. Creating a parser for detailed logs containing information about geolocation.

🔲 Preparation of a set of scanning scripts for supported software.

✅ Docker support.

🔲 Deployment script.

✅ Server side caching solution.

✅ Statistics endpoint.

✅ All the AccessPoint [TODO's](https://github.com/Krzysztofz01/AccessPointMap/blob/master/src/AccessPointMap/AccessPointMap.Domain/AccessPoints/AccessPoint.cs#L77), all of them are related to the stamp merge functionality.

🔲 Migration from .NET5 to .NET6 LTS
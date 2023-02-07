# DroneDeliveryService

## Problem
A squad of drones is tasked with delivering packages for a major online reseller in a world 
where time and distance do not matter. Each drone can carry a specific weight and can make 
multiple deliveries before returning to home base to pick up additional loads; however, the goal 
is to make the fewest number of trips as each time the drone returns to home base, it is 
extremely costly to refuel and reload the drone.

The purpose of the written software is to accept input which will include the name of each 
drone and the maximum weight it can carry, along with a series of locations and the total weight 
needed to be delivered to that specific location. The software should highlight the most efficient 
deliveries for each drone to make on each trip.

Assume that time and distance to each drop off location do not matter, and that the size of 
each package is also irrelevant. It is also assumed that the cost to refuel and restock each 
drone is a constant and does not vary between drones. The maximum number of drones in a 
squad is 100, and there is no maximum number of deliveries which are required.

## Solution
An statistic aproach was used to solve the problem. 

First, the drones and locations data needs to be ordered ascending.

Second, the locations wich its weigth exceed the highest drone weigth charge capacity should be removed.

Thrid, the location data was grouped in three parts:

1. from percentile 0 to 20: Atypical lowest values.
2. from percentile 20 to 80: Normal values.
3. From percentile 80 to 100: Atypical highest values.

Fourth, the charge is distributed trying to reach the maximun weigth capacity of the biggest drone. Then the relation between the trip weigth and the drone weigth capacity is calculated for each drone. So, this way we can choose the correct drone (the drone with the relation most closer to 1, but never over 1).

To distribute the wegiths in a trip, we need to start with the normal values, then we follow with the atypical lowest values and finally we took the atypical highest values.

## Technical Dependencies and Libraries

>## DroneDeliveryService
It's a Web API wich target framework is .Net 6. The app was developed using visual studio 2022. It includes the Domain class library and Swashbuckle as dependencies.

>## Application
It's a custom clase library wich target framework is .Net 6. The library was developed using visual studio 2022. It includes Microsoft.Extensions.Configurations and the Domain class library as dependencies.

>## Domain
It's a custom clase library wich target framework is .Net 6. The library was developed using visual studio 2022. It includes Microsoft.AspNetCore.Http.Extensions, Microsoft.AspNetCore.Http.Features and the Domain class library as dependencies.
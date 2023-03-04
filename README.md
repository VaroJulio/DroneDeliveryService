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
I chose a statistical approach to solve the problem.

First, the drone and location data need to be in ascending order.

Second, remove all the locations from the input data with a weight that exceeds the highest drone weight charge capacity.

Thrid, group the location data into three parts:

  1. From percentile 0 to 19: Atypical lowest values.
  2. From percentile 20 to 79: Normal values.
  3. From percentile 80 to 99: Atypical highest values.
  
Fourth, distribute the charge and try to occupy the maximum weight capacity the biggest drone can carry. Then the relation between the trip weight and the drone weight capacity is calculated for each drone. This method allows us to choose the correct drone (the drone with the closest relation to 1, but never over 1).

To accomplish the distribution of the weights for a trip, we need to start with the Normal values. After, follow with the atypical lowest values. Finally, we took the atypical highest values.

## Technical Dependencies and Libraries

>## DroneDeliveryService
It's a Web API wich target framework is .Net 6. The app was developed using visual studio 2022. It includes the Domain class library and Swashbuckle as dependencies.

>## Application
It's a custom class library wich target framework is .Net 6. The library was developed using visual studio 2022. It includes Microsoft.Extensions.Configurations and the Domain class library as dependencies.

>## Domain
It's a custom class library wich target framework is .Net 6. The library was developed using visual studio 2022. It includes Microsoft.AspNetCore.Http.Extensions, Microsoft.AspNetCore.Http.Features and the Domain class library as dependencies.

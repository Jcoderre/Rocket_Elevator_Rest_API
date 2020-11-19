# Rocket_Elevators_REST

This repo contains all the code for the RESTful API in .NET Core from Week 8 of Odyssey.


- The URL for this API deployed on Azure is : https://apirocketelevators.azurewebsites.net 

A REST API

In order to connect our information system to the equipment in operation throughout the territory served, we first need to develop a REST API using C # and .ASP NET. It will allow us to know and to manipulate the status of all the relevant entities of the operational database.

>  To retrieve the status of a specific battery, column or elevator, use GET with one of the following  endpoints:

  `/api/battery/{battery_id}`
  `/api/column/{column_id}`
  `/api/elevator/{elevator_id}`
    
    
  > To change the status of a specific battery, column or elevator, use PUT with the following endpoints:
  
  `/api/battery/{battery_id}`
  `/api/column/{column_id}`
  `/api/elevator/{elevator_id}`
  
  In Postman, in the Body section, you have to use raw JSON and give a value for the corresponding ID and the desired status. 
  
  ![enter image description here](https://cdn.discordapp.com/attachments/752978810609336322/776998105496289330/Screenshot_204.png)

> Retrieving a list of Elevators that are not in operation at the time of the request

To retrieve this list, use GET with the following endpoint:
  `/api/elevator/inoperational` 

> Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention

To retrieve this list, use GET with the following endpoint: 
`/api/building/intervention` 

> Retrieving a list of Leads created in the last 30 days who have not yet become customers.

To retrieve this list, use GET with the following endpoint:
 `/api/lead/noncustomers`

## TEAM MEMBERS

> Fabien Dimitrov "Team Leader"
> 
> Louis-David Marmen "Member"
> 
> William Jacques "Member"
> 
> Joey Coderre "Member"​

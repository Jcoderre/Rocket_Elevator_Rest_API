# Rocket_Elevators_REST

This repo contains all the code for the RESTful API in .NET Core from Week 9 of Odyssey.


- The URL for this API deployed on Azure is : 

https://rocket-elevator-restapi.azurewebsites.net


A REST API


 To retrieve the information of all intervention without date of starting intervention and with the status "Pending":

  `api/intervention/ispending`

To change the status of a specific Intervention to ("InProgress or Complete"), and change the date:

  `api/interventions/{id}`

  {
    "id":1,
    "status":"inProgress"
  }
  
  {
    "id":1,
    "status":"Complete"
  }

  In Postman, in the Body section, you have to use raw JSON and give a value for the corresponding ID and the desired status. 
  


## Made By


> Joey Coderre

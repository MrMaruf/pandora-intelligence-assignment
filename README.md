# Pandora Intelligence assignment

# Introduction
Assignment created for Pandora Intelligence as a technical test, being part of an interviewing process. 

# Goal
Create an endpoint to lookup a car using this api https://opendata.rdw.nl/Voertuigen/Open-Data-RDW-Gekentekende_voertuigen/m9d7-ebf2
## Input 
- Part of license plate number 
- brand
- type 
- combination of these fields.
### Assumption
- No input means no results returned.
## Output 
At least
- make
- model
- year of the vehicle
### Assumptions & explanations
I am not good with cars so I don't know what any of those things mean.
- The more information returned, the better
- Can return more than one car information, so it returns an array of cars info
## Path
/CarLookup
## Nonfunctional requirements
- The API is protected by an API key.
- The API serves an Open-API spec with a Swagger UI that must be usable to experiment with the API.
- The solution should contain at least one relevant unit test.
- The solution should contain at least one integration test.
- Ensure the application can be monitored in production.
## Bonus
- [ ] - Persist the data you retrieve via the API’s
- [ ] - Put the application in a docker image.
- [ ] - Show it in a CI/CD pipeline how the application is built and deployed

## Deployed version
https://pandora-intelligence-task.herokuapp.com
### Docs
https://pandora-intelligence-task.herokuapp.com/swagger/index.html
### ApiKey
Endpoints are protected by the ApiKey. It can be found in appsettings.json under the name of "X-API-Key"

# TODO

- [X] - Create base solution
- [X] - Add ApiKey authorization
- [X] - Update ReadMe
- [X] - Add testing
- [X] - Add CI/CD pipeline (Heroku)
- [X] - Find a way for production logging (Heroku allows you to track the state of your app in Heroku)

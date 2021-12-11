# ISBAN.BestStories.API
NeoTalent - ISBAN Code Test API

## 1. Objective
This project provides an API using REST that implements the feature and respects the technical requirements describes on the Senior Backend Test 3 documentation.

## 2. Feature description
### 2.1 Return the best 20 stories from Hacker News API: GET /best20
#### Success Response: 200
```json
[
    {
        "title": "Pixel prevented me from calling 911",
        "uri": "https://old.reddit.com/r/GooglePixel/comments/r4xz1f/pixel_prevented_me_from_calling_911/",
        "postedBy": "sohkamyung",
        "time": "2021-12-09T01:50:45Z",
        "score": 1356,
        "commentCount": 85
    },
    {...},
    ...
]
```
#### Too Many Requests Error: 429
```json
{
   "status": 429,
   "message": "Access quota exceeded. Maximum allowed: 10 per 1s. Please try again in X second(s)."
}
```
#### Other Errors: 40X, 500
```json
{
   "status": 500,
   "message": "<<Error message>>"
}
```

## 3. Build and run application
#### 3.1 Requirements
The application was built targeting a cross-plataform solution using [ApsnetCore](https://dotnet.microsoft.com/download). To achieve that, it is used [Docker](https://docs.docker.com/get-started/). Docker is a platform for developers and sysadmins to build, run, and share applications with containers. 
  ###### 3.1.1. Docker compose: 
  Since the application has a main required services to run (service Api), it´s provided a `docker-compose.yml`, so that with a single command, you create and start all the services from the configuration. Therefore, it´s necessary to have [docker-composed](https://docs.docker.com/compose/install/) installed. 
  ###### 3.1.2. Docker:
  To avoid having to install and configure local database and frameworks manually, it´s provided a `Dockerfile`, so that with a single command, you build and run the aplication. Therefore, it´s necessary to have [Docker](https://docs.docker.com/get-started/) installed. 

#### 3.2 Step by step
After downloading this repository, open up a terminal in the repository root folder. After that, run the following command:
```shell
docker-compose up
```
The application will start and will be exposed at the port configured on `Dockerfile`: 27123.
Finally, you can navigate to  `localhost:27123/swagger` to see a human friendly interface by [Swagger UI](https://swagger.io/tools/swagger-ui/).

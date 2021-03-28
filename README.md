
# English Exam Project

## Description

It offers creating English exams based on published articles of wired.com.

Exam project occures 5-Tiers Onion Architecture. 

Core layer is at the top with Entity, DataAccess and the sub layers Business and Api or MVC. 
For Authentication is used Jwt Token and for database is used SqLite.

The project has been designed two different parts, .Net Core MVC and the other one .Net Core Web-Api.

MVC and Api have been deployed to my own host service.

# .Net Core Api

Web-Api side is alive on https://api.exam.logospathos.com

UI side is alive on https://createxam.logospathos.com

I designed UI side by React.js. For testing; email:admin@admin.com password: admin

The Api allows all origins, so you can create, read, update, delete by any server.

## Exam Operations

You can use Postman program for requesting.

### Get Articles

`https://api.exam.logospathos.com/exam/getarticles`

it gets latest 5 articles information released in wired.com

### Add Exam
It requires to be authenticated at first before adding an exam.

If you wish you can use email:admin@admin.com password: admin or you can create your own account following with Add User in Authentication Operations.

After you get bearer token, you should select Authorization tab in Postman, and type:Bearer Token, put the Token code in the blank. 

`https://api.exam.logospathos.com/exam/addexam`

    {
    "exam": {
        "userId": 3,
        "title": "People Who Text While Walking Actually Do Ruin Everything",
        "content": "Save for the Macarena, the most aggravating dance a human can perform is that thing where ...”",
        "dateTime": "2021-03-17 21:36:14",
        "id": 64
    },
    "questions":    [
        {
            "examId": 64,
            "qNumber": 1,
            "q": "asdfa",
            "a": "sadf",
            "b": "sdaf",
            "c": "sadf",
            "d": "sadf",
            "answer": "A",
            "id": 118
        },
         {
            "examId": 64,
            "qNumber": 2,
            "q": "ewrw",
            "a": "we",
            "b": "eerde",
            "c": "e",
            "d": "fefr",
            "answer": "A",
            "id": 118
        }
        ]
    }

Select POST operation lastly and send. If it will return status code 200 and will be added.



### Get Exams

`https://api.exam.logospathos.com/exam/`

The request gets being created exams by users.

### Get Exam

`https://api.exam.logospathos.com/exam/getexam/{the exam id}`

It gets the exam information who you want to take.

For example;

`https://api.exam.logospathos.com/exam/getexam/60`

 This will return the following JSON data:

    {
    "exam": {
        "userId": 3,
        "title": "People Who Text While Walking Actually Do Ruin Everything",
        "content": "Save for the Macarena, the most aggravating dance a human can perform is that thing where ...”",
        "dateTime": "2021-03-17 21:36:14",
        "id": 64
    },
    "questions":    [
        {
            "examId": 64,
            "qNumber": 1,
            "q": "asdfa",
            "a": "sadf",
            "b": "sdaf",
            "c": "sadf",
            "d": "sadf",
            "answer": "A",
            "id": 118
        }
        ]
    }

## Authentication Operations

### Register
To having an account requests POST in Postman;

`https://api.exam.logospathos.com/auth/register`

Body:
 
    {
    "name":"ali",
    "username":"aliveli",
    "email":"aliveli@dot.com",
    "password":"54321"
    }
    

### Login
If the register request returned 200 ok, you can login and get the Token code with following JSON code,

`https://api.exam.logospathos.com/auth/login`

Body:

    {
    "email":"aliveli@dot.com",
    "password":"54321"
    }
    
it will return Json code, 
    
    {
    "token":"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFyJVc2VySWQiOiIxIiwiZW1haWwiOiJzaW5hbkBkb3QuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vc...", 
    "expiration": "2021-03-20T23:55:44.4585817+03:00",
    "userId": 1,
    "userName": "aliveli",
    "name": "ali",
    "email": "aliveli@dot.com"
     }
     
# .Net Core MVC

The .Net Core MVC part is alive on https://exam.logospathos.com/

For testing, email:admin@admin.com password:admin

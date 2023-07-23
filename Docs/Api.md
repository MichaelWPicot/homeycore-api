#Homie Core API

- [Homie Core API](#homie-core-api)
    - [User Table](#user-table)
        - [Create User](#create-user)
            - [Create User Request](#create-user-request)
            - [Create User Response](#create-user-response)
        - [Get User](#get-user)
            - [Get User Request](#get-user-request)
            - [Get User Response](#get-user-response)
        - [Update User](#update-user)
            - [Update User Request](#update-user-request)
            - [Update User Response](#update-user-response)
        - [Delete User](#delete-user)
            - [Delete User Request](#delete-user-request)
            - [Delete User Response](#delete-user-response)
    - [Group Table](#group-table)
        - [Create Group](#create-user)
            - [Create Group Request](#create-group-request)
            - [Create Group Response](#create-group-response)
        - [Get Group](#get-group)
            - [Get Group Request](#get-group-request)
            - [Get Group Response](#get-group-response)
        - [Update Group](#update-user)
            - [Update Group Request](#update-group-request)
            - [Update Group Response](#update-group-response)
        - [Delete Group](#delete-group)
            - [Delete Group Request](#delete-group-request)
            - [Delete Group Response](#delete-group-response)


## User Table

### Create User

#### Create User Request


```js
POST /users
```

```json
{
    "firstName": "John",
    "lastName": "Smith"
}
```

#### Create User Response


```js
201 Created
```


```json
{
    "id": 123414,
    "firstName": "John",
    "lastName": "Smith",
    "lastModifiedDateTime": "2023-06-15T08:00:00"
}
```


### Get User


#### Get User Request


```js
GET /users/{{id}}
```

#### Get User Response


```js
200 Ok
```


```json
{
    "id": 123414,
    "firstName": "John",
    "lastName": "Smith",
    "lastModifiedDateTime": "2023-06-15T08:00:00"
}
```


### Update User


#### Update User Request


```js
PUT /users/{{id}}
```


```json
{
    "firstName": "John",
    "lastName": "Smith"
}
```

#### Update User Response

```js
204 No Content
```
OR
```js
201 Created
```

### Delete User


#### Delete User Request


```js
DELETE /users/{{id}}
```


#### Delete User Response


```js
204 No Content
```

## Group Table

### Create Group


#### Create Group Request


```js
POST /groups
```


```json
{
    "groupName": "Night's Watch",
    "groupDescription": "Wasted Potential"
}
```


#### Create Group Response


```js
201 Created
```


```json
{
    "id": 123414,
    "groupName": "Night's Watch",
    "groupDescription": "Wasted Potential",
    "lastModifiedDateTime": "2023-06-15T08:00:00"
}
```

### Get Group


#### Get Group Request


```js
GET /groups/{{id}}
```

#### Get Group Response


```js
200 Ok
```


```json
{
    "id": 123414,
    "groupName": "Night's Watch",
    "groupDescription": "Wasted Potential",
    "lastModifiedDateTime": "2023-06-15T08:00:00"
}
```


### Update Group


#### Update Group Request


```js
PUT /groups/{{id}}
```


```json
{
    "groupName": "Day's Watch",
    "groupDescription": "Champions of the sun",
}
```

#### Update Group Response


```js
204 No Content
```
OR
```js
201 Created

```
### Delete Group

#### Delete Group Request

```js
DELETE {{host}}/groups/{{id}}
```
#### Delete Group Response

```js
204 No Content
```
## Task Table
### Create Task

#### Create Task Request

```js
POST {{host}}/tasks
```

```json
{
    "taskName": "Clean the Stables",
    "taskDescription": "Replace hay in the pens and fill water troughs",
    "completeByDate":"2023-07-23 02:29:30.638 -0700",
    "createdUserId":1,
    "assignedUserId":2
}
```

#### Create Task Response

```js
201 Created
```

```json
{
    "id": 123414,
    "taskName": "Clean the Stables",
    "taskDescription": "Replace hay in the pens and fill water troughs",
    "completeByDate":"2023-07-23 02:29:30.638 -0700",
    "taskCreatedDate":"2023-07-23 02:29:30.638 -0700",
    "lastModifiedDateTime":"2023-07-23 02:29:30.638 -0700",
    "createdUserId":1,
    "assignedUserId":2
}
```

### Get Task

#### Get Task Request

```js
GET {{host}}/tasks/{{id}}
```

#### Get Task Response

```js
200 Ok
```

```json
{
    "id": 123414,
    "taskName": "Clean the Stables",
    "taskDescription": "Replace hay in the pens and fill water troughs",
    "completeByDate":"2023-07-23 02:29:30.638 -0700",
    "taskCreatedDate":"2023-07-23 02:29:30.638 -0700",
    "lastModifiedDateTime":"2023-07-23 02:29:30.638 -0700",
    "createdUserId":1,
    "assignedUserId":2
}
```

### Update Task

#### Update Task Request

```js
PUT /tasks/{{id}}
```

```json
{
    "taskName": "Clean the Tower",
    "taskDescription": "Wash the flagstones and the banners",
    "completeByDate":"2023-07-23 02:29:30.638 -0700",
    "createdUserId":2,
    "assignedUserId":1
}
```

#### Update Task Response

```js
204 No Content
```

or

```js
201 Created
```

### Delete Task

#### Delete Task Request

```js
DELETE /tasks/{{id}}
```
#### Delete Task Response

```js
204 No Content
```
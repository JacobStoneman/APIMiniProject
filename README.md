# API Mini Project



<h2>Project Overview</h2>

<h3>Aim</h3>

The aim of the project is to create a framework to interact with the 'todoist' REST API. This API is used for creating To-Do lists. Extensive tests were run on the API endpoints to evaluate the responses.

Documentation for the API can be seen [here](https://developer.todoist.com/guides/#developing-with-todoist).



<h3>API</h3>

The API allows you to create a to-do list by defining a project and then assigning tasks to it. It enables the user to apply CRUD functionality to these projects with endpoints containing a multitude of optional parameters.
<p> The API can create projects where you can name them and then specify their colour, if they are in favourites, whether they have been shared and more. Within projects you can create tasks. Tasks have their own name (content) and can also contain more detail such as the assigner, whether its completed, the due date and more. </p> 

The API adheres to HTTP which means it is interacted with through the usual HTTP verbs. A GET request enables the user to view single or multiple projects and tasks. A POST request with parameters included in the body allows for creating new projects/tasks whilst the DELETE request allows for removing projects and tasks.

<h3>Class Diagram</h3>

<b>Insert class diagram here.</b>

<h3>Services and Managers</h3>

In order to make and handle API requests, services and call manager classes are used which are responsible for both building the request and sending it to the client to be executed.
For each CRUD function for both projects and tasks, a relevant service provides methods that allow the user to query the API and return the requested information. In the case of projects, the user is able to retrieve a project by a given ID or retrieve all projects, with the option to filter these by different attributes such as colour or favourites. This is also the case for tasks which can be retrieved by an ID, group of ID's or filtered by task attributes passed in as parameters. New tasks and projects can also be created as well as updated and deleted.
When one of these methods are called, it is passed to the call manager which takes the given parameters and builds a request ready to send to the client to be executed. The call manager is also responsible for passing the bearer token into the request to authorise the call with the API.
Both the services and the call managers inherit from base classes which contain the generic properties needed, including the status code and message and the client used to execute requests.

<b>Something about the structure of how we access the API</b>

<h3>Unit Testing</h3>

<p>API testing is intended to reveal bugs: inconsistencies or deviations from the expected behavior.</p>

<p>Responses are evaluated through unit testing following the constraint model with assert statements. There are tests in place to verify that the status code is as expected (200 = OK, 204 = No Content, 404 = Not Found, etc). There was also verification that the content itself was as expected.
This includes testing that the name and other characteristics of projects/tasks is stored and retrieved as stated in the API documentation. </p>


<h2>Project Review</h2>



<h2>Project Retrospective</h2>

<p>Overall, the project was carried out well. Planning of the project took place immediately after the initial selection of the API for testing through the development of user stories. Once these were created, the team was able to set up an initial project structure
which the outcome of each user story could be implemented on. From here, the team was able to distribute tasks to be completed by each team member and these were all delivered by the end of the project sprint. Communication was absolutely vital throughout this process to avoid difficult merge conflicts and damage of existing code.
</p>

<p>To better improve upon this project, better branch structure in the Github repo would make for a less risky way of adding updates to the project. No serious issues occurred during this project but with more people and a longer project, separating out the dev from the main would be imperative.</p>
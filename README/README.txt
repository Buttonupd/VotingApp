**** THIS IS A BRIEF GUIDE ON SETTING UP THE PROJECT ****


1 . Unzip VotingApp. There are several ways to open this project inside of a code editor.
    Open VisualStudio and click on "Open Local Folder". Navigate to the local project destination and select the project

2 . Once the project has loaded, we need to install a few packages which the project depends on:

	Double click the ".sln" file
	
	In VisualStudio, open "Nuget package manager". Clicks on tools and this option will be avilable .

	We need to install :
 		
		a) Microsoft.EntityFrameworkCore
		b) Microsoft.EntityFrameworkCore.SqlServer
		c) Microsoft.AspNet.WebApi.Cors

3 . Once these dependencies are installed,  we need to have a database connection. In this project, I user MSSQL.
	The "appsettings.json" file is where we place out config variables. Locate it and change it accordingly.
	There is an example provided.

4 . Your database must contain a table with the fields inside of the "Data/UserVotesIncrement"

	A simple SQL statement to create a table and an INSERT INTO SQL command will generate dummy data.

5 . You can achieve the same, although your database connection needs to be active .Run the project.

	This API is preconfigured with "Swagger". Once it executes successfully, there are available endpoints to test the functionality of this API.

6 . 75% - 85% functionality complete, however optimization is required .
    
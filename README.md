#Contact Book

_A Simple App to Organize Your the Your Hair Salon Stylists, {02/24/2017}

By Grinil Khanna_

####Description

_This is a simple app to manage your stylist employees. This programs shows a list of your stylists and the clients they are seeing._

####Setup/Installation Requirements

_Setup the SQL Server and Database:
In SQLCMD:
> CREATE DATABASE hair_salon;
> GO
> USE hair_salon;
> GO
> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
> CREATE TABLE clients (id INT IDENTITY(1,1), description VARCHAR(255));
> GO

Clone the files from github
Upload them in an editor
Fire up a server and load the files onto a browser
Fill out the form with stylist details
Navigate to specific stylist page via name
Add clients
Edit and Delete clients when needed_

####Specs

_1. Make sure there is a connection from the site to the DB.
**input: none
**output: count = 0;
2. The program recognizes if entries are the same.
**input: "Client Name" **input: "Client Name"
** output: True
3. The program saves entries to the database.
**input: "Client Name"
** output: "Cient Name" (shows in database)
4. The program attributes ID to each entry.
**input: "Client Name" (first entry: ID 1)
** output: ID: 1;  Name: "Cient Name"
5. The program can find a particular entry through use of ID number.
**input: ID: 1  
** output: "Cient Name" (from database)


####Known Bugs

_  _


####Support and contact details

_Feel free to contact me - give me some pointers or feedback! gmkhanna@gmail.com --_

####Technologies Used

_HTML, C#, SQL_,

####License

_Copyright (c) 2017 Grinil Khanna, Epicodus

Copyright (c)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

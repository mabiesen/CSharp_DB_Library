# CSharp Database Library

Library to assist with database connections, data validation, querying, data variable storage, etc.

Library will be interfaced appropriately to allow user to switch between database types(such as mongo and sql) without having to alter much code.  Additional interfaces to be included for logging (console, debugger, file) and for field type validation (confirming input data matches field type for mongo,sql, etc.)

### Structure is as follows:

DBCommMaster is the main class which will drive all interaction.  When users require additional functionality and/or swaps between interfaces, they make those changes here.

DBCommMaster interfaces are supplied as inputs on DBCommMaster object instantiation.  A connection string is also supplied.

DBCommMaster contains one DB instance which represents a database.

DB instances hold DBTables, whic represent tables.

DBTable instances contain a schema table, a data table, and a name.

### Accomplishments as of first commit

1. Successful unit testing of DB, DBTables, SQLConnection, TypeValidation, DBCommMaster

### TODO as of first commit

1. Develop methods in DBCommMaster to validate user supplied data matches field type.
2. Better error hanlding for db connections
3. Test error writers, complete development of filewriter


--Part 1: list the columns and their data types in the Jobs table
-- int Id 
-- longtext Name
-- int EmployerId


--Part 2: query to list the names of the employers in St. Louis City
SELECT * 
FROM employers 
WHERE Location = "St. Louis City";


--Part 3: query to return list of the names & descriptions of all skills in alphabetical order.
SELECT name, description
FROM skills 
ORDER BY name ASC;

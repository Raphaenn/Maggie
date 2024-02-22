-- create_user_table.sql

-- Check if the Users table already exists
SELECT COUNT(*)
FROM information_schema.tables
WHERE table_name = 'Users';

-- If the Users table does not exist, create it
CREATE TABLE IF NOT EXISTS Users
(
    id uuid PRIMARY KEY,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Status BOOLEAN NOT NULL
);
-- create_user_table.sql

-- Check if the Users table already exists
SELECT COUNT(*)
FROM information_schema.tables
WHERE table_name = 'Budget';

-- If the Users table does not exist, create it
CREATE TABLE IF NOT EXISTS Budget
(
    id uuid PRIMARY KEY,
    salary DECIMAL NOT NULL,
    light DECIMAL NOT NULL,
    water DECIMAL NOT NULL,
    internet DECIMAL NOT NULL,
    basic_food DECIMAL NOT NULL,
    health DECIMAL NOT NULL,
    leisure DECIMAL NOT NULL,
    clothes DECIMAL NOT NULL,
    transport DECIMAL,
    home_rent DECIMAL,
    home_tax DECIMAL,
    home_financing DECIMAL,
    medicines DECIMAL NOT NULL,
    car_tax DECIMAL,
    car_financing DECIMAL,
    gas DECIMAL,
    education DECIMAL,
    home_spends DECIMAL
);
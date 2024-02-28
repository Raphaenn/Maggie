-- Check if the column already exists

-- if column does not exists, create it
-- Step 1: Add the new column
ALTER TABLE users
    ADD COLUMN cpf VARCHAR(255);

-- Step 2: Update existing rows
UPDATE users
SET cpf = ''
WHERE cpf IS NULL;

-- Step 3: Alter the column to make it required
ALTER TABLE users
    ALTER COLUMN cpf SET NOT NULL;
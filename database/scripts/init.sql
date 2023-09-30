CREATE TABLE IF NOT EXISTS Items (
    Id        uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    Name      VARCHAR NOT NULL,
    Stock     INT NOT NULL
);
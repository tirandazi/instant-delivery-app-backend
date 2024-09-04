CREATE TABLE address (
    id UUID DEFAULT gen_random_uuid(),
    street_number VARCHAR,
    area_name VARCHAR NOT NULL,
    pincode INT NOT NULL,
    latitude DOUBLE PRECISION NOT NULL,
    longitude DOUBLE PRECISION NOT NULL,
    PRIMARY KEY (id)
);
CREATE TABLE customer    (
    id UUID DEFAULT gen_random_uuid(),
    name VARCHAR NOT NULL,
    phone_number VARCHAR NOT NULL,
    address_id UUID NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (address_id) REFERENCES address(id)
);
CREATE TABLE store (
    id UUID DEFAULT gen_random_uuid(),
    store_name VARCHAR(30) NOT NULL,
    address_id UUID NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (address_id) REFERENCES address(id)
);
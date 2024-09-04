CREATE TABLE cart (
  id UUID DEFAULT gen_random_uuid(),
  customer_id UUID,
  status VARCHAR NOT NULL,
  FOREIGN KEY (customer_id) REFERENCES customer(id),
  PRIMARY KEY (id)
);

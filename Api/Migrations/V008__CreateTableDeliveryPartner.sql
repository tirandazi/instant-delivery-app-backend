CREATE TABLE delivery_partner (
  id UUID DEFAULT gen_random_uuid(),
  name VARCHAR,
  phone_number VARCHAR(10),
  home_location VARCHAR,
  availability_status VARCHAR,
  hourly_rate MONEY,
  ratings INT,
  PRIMARY KEY(id)
);

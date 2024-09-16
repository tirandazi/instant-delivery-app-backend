CREATE TABLE OTPRecord (
    Id UUID DEFAULT gen_random_uuid(),
    Phone_number VARCHAR NOT NULL,
    Otp VARCHAR NOT NULL,
    Expiry TIMESTAMP NOT NULL,
    PRIMARY KEY (Id)
);
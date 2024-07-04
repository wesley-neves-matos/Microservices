--Create database
CREATE TABLE Coupon(Id SERIAL PRIMARY KEY,
					ProductName VARCHAR(24) NOT NULL,
					Description TEXT,
					Amount INT);
--Insert new registers in database
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Caderno','Caderno Espiral',5);
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Caneta','Caneta Esferográfica',2);
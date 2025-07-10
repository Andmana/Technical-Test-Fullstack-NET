USE Technical_Test;


DROP TABLE IF EXISTS Company;
CREATE TABLE Company(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    NPWP NVARCHAR(50) NOT NULL,
    director_name NVARCHAR(255) NOT NULL,
    PIC_name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) NOT NULL,
    phone_number NVARCHAR(50) NOT NULL,
    NPWP_src NVARCHAR(255),
    power_of_attorey_src NVARCHAR(255),
    invitation_access BIT DEFAULT 0, 
    CreatedAt DATETIME DEFAULT GETDATE()
);

SELECT * FROM COMPANY;

-- Insert fake data into Company table
INSERT INTO Company (
    name, NPWP, director_name, PIC_name, email, phone_number, 
    NPWP_src, power_of_attorey_src, invitation_access, CreatedAt
)
VALUES 
('Alpha Solutions', '12.345.678.9-012.345', 'John Doe', 'Jane Smith', 'contact@alphasolutions.com', '081234567890', 
 '/uploads/npwp_alpha.pdf', '/uploads/poa_alpha.pdf', 1, GETDATE()),

('Beta Tech', '98.765.432.1-098.765', 'Michael Johnson', 'Sara Parker', 'info@betatech.co.id', '082112345678', 
 '/uploads/npwp_beta.pdf', '/uploads/poa_beta.pdf', 0, GETDATE()),

('Gamma Industries', '11.223.344.5-667.788', 'Albert Newton', 'Diana Prince', 'support@gammaindustries.id', '081298765432', 
 '/uploads/npwp_gamma.pdf', '/uploads/poa_gamma.pdf', 1, GETDATE()),

('Delta Corp', '22.334.455.6-778.899', 'Clara Oswald', 'Bruce Wayne', 'hello@deltacorp.com', '083112233445', 
 '/uploads/npwp_delta.pdf', '/uploads/poa_delta.pdf', 0, GETDATE()),

('Epsilon Ltd', '33.445.566.7-889.900', 'Peter Parker', 'Tony Stark', 'contact@epsilonltd.co.id', '081233344455', 
 '/uploads/npwp_epsilon.pdf', '/uploads/poa_epsilon.pdf', 1, GETDATE()),

('Zeta Dynamics', '44.556.677.8-900.011', 'Diana Ross', 'Clark Kent', 'admin@zetadynamics.id', '081244455566', 
 '/uploads/npwp_zeta.pdf', '/uploads/poa_zeta.pdf', 0, GETDATE()),

('Eta Group', '55.667.788.9-011.122', 'Steve Rogers', 'Natasha Romanoff', 'info@etagroup.co.id', '082255566677', 
 '/uploads/npwp_eta.pdf', '/uploads/poa_eta.pdf', 1, GETDATE()),

('Theta Ventures', '66.778.899.0-122.233', 'Bruce Banner', 'Wanda Maximoff', 'contact@thetaventures.com', '081266677788', 
 '/uploads/npwp_theta.pdf', '/uploads/poa_theta.pdf', 1, GETDATE()),

('Iota Enterprises', '77.889.900.1-233.344', 'Scott Lang', 'Hope Van Dyne', 'team@iotaenterprises.id', '083177788899', 
 '/uploads/npwp_iota.pdf', '/uploads/poa_iota.pdf', 0, GETDATE()),

('Kappa Innovations', '88.990.011.2-344.455', 'Stephen Strange', 'Christine Palmer', 'hello@kappainnovations.co.id', '081288899900', 
 '/uploads/npwp_kappa.pdf', '/uploads/poa_kappa.pdf', 1, GETDATE());

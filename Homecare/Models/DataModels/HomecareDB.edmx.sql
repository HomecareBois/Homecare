
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2018 13:32:34
-- Generated from EDMX file: C:\Users\pesti\Documents\Datamatiker\4.semester\CSharp\Homecare\Homecare\Models\DataModels\HomecareDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HomecareDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Address_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Address] DROP CONSTRAINT [FK_Address_City];
GO
IF OBJECT_ID(N'[dbo].[FK_Caretaker_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caretaker] DROP CONSTRAINT [FK_Caretaker_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_Login_User_Rights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_Login_User_Rights];
GO
IF OBJECT_ID(N'[dbo].[FK_Patient_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Patient] DROP CONSTRAINT [FK_Patient_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_Patient_Phone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Patient] DROP CONSTRAINT [FK_Patient_Phone];
GO
IF OBJECT_ID(N'[dbo].[FK_Schedule_Route]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schedule] DROP CONSTRAINT [FK_Schedule_Route];
GO
IF OBJECT_ID(N'[dbo].[FK_Staff_Occupation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Staff] DROP CONSTRAINT [FK_Staff_Occupation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Caretaker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Caretaker];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Occupation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Occupation];
GO
IF OBJECT_ID(N'[dbo].[Patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patient];
GO
IF OBJECT_ID(N'[dbo].[Phone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phone];
GO
IF OBJECT_ID(N'[dbo].[Route]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Route];
GO
IF OBJECT_ID(N'[dbo].[Schedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedule];
GO
IF OBJECT_ID(N'[dbo].[Staff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Staff];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User_Rights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Rights];
GO
IF OBJECT_ID(N'[HomecareDBModelStoreContainer].[CaretakerView]', 'U') IS NOT NULL
    DROP TABLE [HomecareDBModelStoreContainer].[CaretakerView];
GO
IF OBJECT_ID(N'[HomecareDBModelStoreContainer].[PatientView]', 'U') IS NOT NULL
    DROP TABLE [HomecareDBModelStoreContainer].[PatientView];
GO
IF OBJECT_ID(N'[HomecareDBModelStoreContainer].[RouteView]', 'U') IS NOT NULL
    DROP TABLE [HomecareDBModelStoreContainer].[RouteView];
GO
IF OBJECT_ID(N'[HomecareDBModelStoreContainer].[database_firewall_rules]', 'U') IS NOT NULL
    DROP TABLE [HomecareDBModelStoreContainer].[database_firewall_rules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [id_address] int IDENTITY(1,1) NOT NULL,
    [road_name] varchar(30)  NOT NULL,
    [number] varchar(10)  NOT NULL,
    [fk_city_address] int  NOT NULL
);
GO

-- Creating table 'Caretakers'
CREATE TABLE [dbo].[Caretakers] (
    [id_caretaker] int IDENTITY(1,1) NOT NULL,
    [caretaker_name] varchar(70)  NOT NULL,
    [fk_login_caretaker] int  NOT NULL,
    [fk_phone_caretaker] int  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [id_city] int IDENTITY(1,1) NOT NULL,
    [city_name] varchar(50)  NOT NULL,
    [zipcode] varchar(4)  NOT NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [id_login] int IDENTITY(1,1) NOT NULL,
    [username] varchar(20)  NOT NULL,
    [password] varchar(100)  NOT NULL,
    [fk_user_rights_login] int  NOT NULL
);
GO

-- Creating table 'Occupations'
CREATE TABLE [dbo].[Occupations] (
    [id_occupation] int IDENTITY(1,1) NOT NULL,
    [occupation_name] varchar(25)  NULL
);
GO

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [id_patient] int IDENTITY(1,1) NOT NULL,
    [patient_name] varchar(70)  NOT NULL,
    [cpr] varchar(10)  NOT NULL,
    [relative_phonenumber] nchar(12)  NULL,
    [fk_address_patient] int  NOT NULL,
    [fk_phone_patient] int  NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [id_phone] int IDENTITY(1,1) NOT NULL,
    [phone_number] varchar(12)  NOT NULL
);
GO

-- Creating table 'Schedules'
CREATE TABLE [dbo].[Schedules] (
    [id_schedule] int IDENTITY(1,1) NOT NULL,
    [schedule_start] datetime  NOT NULL,
    [schedule_end] datetime  NOT NULL,
    [fk_staff_schedule] int  NOT NULL,
    [fk_route_schedule] int  NOT NULL
);
GO

-- Creating table 'Staffs'
CREATE TABLE [dbo].[Staffs] (
    [id_staff] int IDENTITY(1,1) NOT NULL,
    [staff_name] varchar(70)  NOT NULL,
    [fk_occupation_staff] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'User_Rights'
CREATE TABLE [dbo].[User_Rights] (
    [id_user_rights] int IDENTITY(1,1) NOT NULL,
    [user_rights_type] varchar(45)  NOT NULL
);
GO

-- Creating table 'CaretakerViews'
CREATE TABLE [dbo].[CaretakerViews] (
    [username] varchar(20)  NOT NULL,
    [phone_number] varchar(12)  NOT NULL,
    [caretaker_name] varchar(70)  NOT NULL
);
GO

-- Creating table 'PatientViews'
CREATE TABLE [dbo].[PatientViews] (
    [patient_name] varchar(70)  NOT NULL,
    [road_name] varchar(30)  NOT NULL,
    [number] varchar(10)  NOT NULL,
    [phone_number] varchar(12)  NOT NULL,
    [city_name] varchar(50)  NOT NULL,
    [zipcode] varchar(4)  NOT NULL,
    [cpr] varchar(10)  NOT NULL,
    [relative_phonenumber] nchar(12)  NULL,
    [id_patient] int  NOT NULL
);
GO

-- Creating table 'RouteViews'
CREATE TABLE [dbo].[RouteViews] (
    [arrival] time  NOT NULL,
    [caretaker_name] varchar(70)  NOT NULL,
    [road_name] varchar(30)  NOT NULL,
    [number] varchar(10)  NOT NULL,
    [city_name] varchar(50)  NOT NULL,
    [zipcode] varchar(4)  NOT NULL,
    [patient_name] varchar(70)  NOT NULL
);
GO

-- Creating table 'database_firewall_rules'
CREATE TABLE [dbo].[database_firewall_rules] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL,
    [start_ip_address] varchar(45)  NOT NULL,
    [end_ip_address] varchar(45)  NOT NULL,
    [create_date] datetime  NOT NULL,
    [modify_date] datetime  NOT NULL
);
GO

-- Creating table 'Routes'
CREATE TABLE [dbo].[Routes] (
    [id_route] int IDENTITY(1,1) NOT NULL,
    [arrival] datetime  NOT NULL,
    [date] datetime  NOT NULL,
    [fk_caretaker_route] int  NOT NULL,
    [fk_address_route] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_address] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([id_address] ASC);
GO

-- Creating primary key on [id_caretaker] in table 'Caretakers'
ALTER TABLE [dbo].[Caretakers]
ADD CONSTRAINT [PK_Caretakers]
    PRIMARY KEY CLUSTERED ([id_caretaker] ASC);
GO

-- Creating primary key on [id_city] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([id_city] ASC);
GO

-- Creating primary key on [id_login] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([id_login] ASC);
GO

-- Creating primary key on [id_occupation] in table 'Occupations'
ALTER TABLE [dbo].[Occupations]
ADD CONSTRAINT [PK_Occupations]
    PRIMARY KEY CLUSTERED ([id_occupation] ASC);
GO

-- Creating primary key on [id_patient] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([id_patient] ASC);
GO

-- Creating primary key on [id_phone] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([id_phone] ASC);
GO

-- Creating primary key on [id_schedule] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [PK_Schedules]
    PRIMARY KEY CLUSTERED ([id_schedule] ASC);
GO

-- Creating primary key on [id_staff] in table 'Staffs'
ALTER TABLE [dbo].[Staffs]
ADD CONSTRAINT [PK_Staffs]
    PRIMARY KEY CLUSTERED ([id_staff] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id_user_rights] in table 'User_Rights'
ALTER TABLE [dbo].[User_Rights]
ADD CONSTRAINT [PK_User_Rights]
    PRIMARY KEY CLUSTERED ([id_user_rights] ASC);
GO

-- Creating primary key on [username], [phone_number], [caretaker_name] in table 'CaretakerViews'
ALTER TABLE [dbo].[CaretakerViews]
ADD CONSTRAINT [PK_CaretakerViews]
    PRIMARY KEY CLUSTERED ([username], [phone_number], [caretaker_name] ASC);
GO

-- Creating primary key on [patient_name], [road_name], [number], [phone_number], [city_name], [zipcode], [cpr], [id_patient] in table 'PatientViews'
ALTER TABLE [dbo].[PatientViews]
ADD CONSTRAINT [PK_PatientViews]
    PRIMARY KEY CLUSTERED ([patient_name], [road_name], [number], [phone_number], [city_name], [zipcode], [cpr], [id_patient] ASC);
GO

-- Creating primary key on [arrival], [caretaker_name], [road_name], [number], [city_name], [zipcode], [patient_name] in table 'RouteViews'
ALTER TABLE [dbo].[RouteViews]
ADD CONSTRAINT [PK_RouteViews]
    PRIMARY KEY CLUSTERED ([arrival], [caretaker_name], [road_name], [number], [city_name], [zipcode], [patient_name] ASC);
GO

-- Creating primary key on [id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] in table 'database_firewall_rules'
ALTER TABLE [dbo].[database_firewall_rules]
ADD CONSTRAINT [PK_database_firewall_rules]
    PRIMARY KEY CLUSTERED ([id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] ASC);
GO

-- Creating primary key on [id_route] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [PK_Routes]
    PRIMARY KEY CLUSTERED ([id_route] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fk_city_address] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_Address_City]
    FOREIGN KEY ([fk_city_address])
    REFERENCES [dbo].[Cities]
        ([id_city])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_City'
CREATE INDEX [IX_FK_Address_City]
ON [dbo].[Addresses]
    ([fk_city_address]);
GO

-- Creating foreign key on [fk_address_patient] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [FK_Patient_Address]
    FOREIGN KEY ([fk_address_patient])
    REFERENCES [dbo].[Addresses]
        ([id_address])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Patient_Address'
CREATE INDEX [IX_FK_Patient_Address]
ON [dbo].[Patients]
    ([fk_address_patient]);
GO

-- Creating foreign key on [fk_login_caretaker] in table 'Caretakers'
ALTER TABLE [dbo].[Caretakers]
ADD CONSTRAINT [FK_Caretaker_Login]
    FOREIGN KEY ([fk_login_caretaker])
    REFERENCES [dbo].[Logins]
        ([id_login])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Caretaker_Login'
CREATE INDEX [IX_FK_Caretaker_Login]
ON [dbo].[Caretakers]
    ([fk_login_caretaker]);
GO

-- Creating foreign key on [fk_user_rights_login] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [FK_Login_User_Rights]
    FOREIGN KEY ([fk_user_rights_login])
    REFERENCES [dbo].[User_Rights]
        ([id_user_rights])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Login_User_Rights'
CREATE INDEX [IX_FK_Login_User_Rights]
ON [dbo].[Logins]
    ([fk_user_rights_login]);
GO

-- Creating foreign key on [fk_occupation_staff] in table 'Staffs'
ALTER TABLE [dbo].[Staffs]
ADD CONSTRAINT [FK_Staff_Occupation]
    FOREIGN KEY ([fk_occupation_staff])
    REFERENCES [dbo].[Occupations]
        ([id_occupation])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Staff_Occupation'
CREATE INDEX [IX_FK_Staff_Occupation]
ON [dbo].[Staffs]
    ([fk_occupation_staff]);
GO

-- Creating foreign key on [fk_phone_patient] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [FK_Patient_Phone]
    FOREIGN KEY ([fk_phone_patient])
    REFERENCES [dbo].[Phones]
        ([id_phone])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Patient_Phone'
CREATE INDEX [IX_FK_Patient_Phone]
ON [dbo].[Patients]
    ([fk_phone_patient]);
GO

-- Creating foreign key on [fk_route_schedule] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [FK_Schedule_Route]
    FOREIGN KEY ([fk_route_schedule])
    REFERENCES [dbo].[Routes]
        ([id_route])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Schedule_Route'
CREATE INDEX [IX_FK_Schedule_Route]
ON [dbo].[Schedules]
    ([fk_route_schedule]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
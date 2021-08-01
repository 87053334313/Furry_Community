
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/05/2021 20:50:16
-- Generated from EDMX file: C:\Users\VictorLi\Desktop\Exam_Furry_community\Furry_Community_Sln\Furry_Community\Models\DataBase\Furry_DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vitya_Furry];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_help_to_main_table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[all_information] DROP CONSTRAINT [FK_help_to_main_table];
GO
IF OBJECT_ID(N'[dbo].[FK_I_found_main_table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[all_information] DROP CONSTRAINT [FK_I_found_main_table];
GO
IF OBJECT_ID(N'[dbo].[FK_i_have_lost_to_maint_table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[all_information] DROP CONSTRAINT [FK_i_have_lost_to_maint_table];
GO
IF OBJECT_ID(N'[dbo].[FK_I_want_to_shelter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[all_information] DROP CONSTRAINT [FK_I_want_to_shelter];
GO
IF OBJECT_ID(N'[dbo].[FK_it_is_me]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[all_information] DROP CONSTRAINT [FK_it_is_me];
GO
IF OBJECT_ID(N'[dbo].[FK_how_to_Contact_telephone_or_email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[it_is_me] DROP CONSTRAINT [FK_how_to_Contact_telephone_or_email];
GO
IF OBJECT_ID(N'[dbo].[FK_reputation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[it_is_me] DROP CONSTRAINT [FK_reputation];
GO
IF OBJECT_ID(N'[dbo].[FK_role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[reputation] DROP CONSTRAINT [FK_role];
GO
IF OBJECT_ID(N'[dbo].[FK_ID_animal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[I_want_to_shelter_from_the_shelter] DROP CONSTRAINT [FK_ID_animal];
GO
IF OBJECT_ID(N'[dbo].[FK_ID_shelter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[I_want_to_shelter_from_the_shelter] DROP CONSTRAINT [FK_ID_shelter];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[all_information]', 'U') IS NOT NULL
    DROP TABLE [dbo].[all_information];
GO
IF OBJECT_ID(N'[dbo].[SsylkaNaVideo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SsylkaNaVideo];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[how_to_contact_me]', 'U') IS NOT NULL
    DROP TABLE [dbo].[how_to_contact_me];
GO
IF OBJECT_ID(N'[dbo].[it_is_me]', 'U') IS NOT NULL
    DROP TABLE [dbo].[it_is_me];
GO
IF OBJECT_ID(N'[dbo].[reputation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[reputation];
GO
IF OBJECT_ID(N'[dbo].[role_love_of_animal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role_love_of_animal];
GO
IF OBJECT_ID(N'[dbo].[help]', 'U') IS NOT NULL
    DROP TABLE [dbo].[help];
GO
IF OBJECT_ID(N'[dbo].[I_found]', 'U') IS NOT NULL
    DROP TABLE [dbo].[I_found];
GO
IF OBJECT_ID(N'[dbo].[I_have_lost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[I_have_lost];
GO
IF OBJECT_ID(N'[dbo].[I_want_to_shelter_from_the_shelter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[I_want_to_shelter_from_the_shelter];
GO
IF OBJECT_ID(N'[dbo].[id_animal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[id_animal];
GO
IF OBJECT_ID(N'[dbo].[id_shelter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[id_shelter];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'all_information'
CREATE TABLE [dbo].[all_information] (
    [it_is_me] int  NOT NULL,
    [help] int  NULL,
    [i_found] int  NULL,
    [i_want_to_shelter_from_the_shelter] int  NULL,
    [i_have_lost] int  NULL,
    [id_all] int  NOT NULL
);
GO

-- Creating table 'SsylkaNaVideo'
CREATE TABLE [dbo].[SsylkaNaVideo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NULL,
    [SsylkaNaYouTube] varchar(max)  NULL
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

-- Creating table 'how_to_contact_me'
CREATE TABLE [dbo].[how_to_contact_me] (
    [ID_how_to_contact_me] int IDENTITY(1,1) NOT NULL,
    [tepelhone] varchar(30)  NULL,
    [email] varchar(55)  NULL
);
GO

-- Creating table 'it_is_me'
CREATE TABLE [dbo].[it_is_me] (
    [ID_I] int IDENTITY(1,1) NOT NULL,
    [First_name] varchar(50)  NOT NULL,
    [Second_name] varchar(50)  NOT NULL,
    [Patronymic] varchar(50)  NULL,
    [Photo] varbinary(max)  NULL,
    [ID_how_to_contact_me] int  NOT NULL,
    [ID_reputation] int  NOT NULL,
    [Parol] char(30)  NULL
);
GO

-- Creating table 'reputation'
CREATE TABLE [dbo].[reputation] (
    [ID_reputation] int IDENTITY(1,1) NOT NULL,
    [acheivements] varchar(100)  NULL,
    [id_role] int  NULL
);
GO

-- Creating table 'role_love_of_animal'
CREATE TABLE [dbo].[role_love_of_animal] (
    [ID_role] int IDENTITY(1,1) NOT NULL,
    [dogs] bit  NULL,
    [cats] bit  NULL,
    [humsters] bit  NULL
);
GO

-- Creating table 'help'
CREATE TABLE [dbo].[help] (
    [ID_help] int IDENTITY(1,1) NOT NULL,
    [How_can_i_help] varchar(255)  NULL,
    [What_help_do_I_need] varchar(255)  NULL,
    [ssylka_id] int  NULL
);
GO

-- Creating table 'I_found'
CREATE TABLE [dbo].[I_found] (
    [ID_I_found] int IDENTITY(1,1) NOT NULL,
    [animal_photo] varbinary(max)  NULL,
    [geolocation] varchar(150)  NULL,
    [information] varchar(255)  NULL,
    [date_found] datetime  NULL,
    [ssylka_id] int  NULL
);
GO

-- Creating table 'I_have_lost'
CREATE TABLE [dbo].[I_have_lost] (
    [ID_I_have_lost] int IDENTITY(1,1) NOT NULL,
    [advertisment] nvarchar(255)  NULL,
    [support] varchar(255)  NULL,
    [ssylka_id] int  NULL,
    [photo] varbinary(max)  NULL
);
GO

-- Creating table 'I_want_to_shelter_from_the_shelter'
CREATE TABLE [dbo].[I_want_to_shelter_from_the_shelter] (
    [ID_help_animal] int IDENTITY(1,1) NOT NULL,
    [ID_animal] int  NOT NULL,
    [ID_shelter] int  NOT NULL
);
GO

-- Creating table 'id_animal'
CREATE TABLE [dbo].[id_animal] (
    [ID_animal1] int IDENTITY(1,1) NOT NULL,
    [dogs] bit  NULL,
    [cats] bit  NULL,
    [humsters] bit  NULL
);
GO

-- Creating table 'id_shelter'
CREATE TABLE [dbo].[id_shelter] (
    [ID_shelter1] int IDENTITY(1,1) NOT NULL,
    [Name_of_shelter] varchar(150)  NOT NULL,
    [Address_of_shelter] varchar(200)  NOT NULL,
    [Telephone] varchar(35)  NOT NULL,
    [vid_animals] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_all] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [PK_all_information]
    PRIMARY KEY CLUSTERED ([id_all] ASC);
GO

-- Creating primary key on [Id] in table 'SsylkaNaVideo'
ALTER TABLE [dbo].[SsylkaNaVideo]
ADD CONSTRAINT [PK_SsylkaNaVideo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID_how_to_contact_me] in table 'how_to_contact_me'
ALTER TABLE [dbo].[how_to_contact_me]
ADD CONSTRAINT [PK_how_to_contact_me]
    PRIMARY KEY CLUSTERED ([ID_how_to_contact_me] ASC);
GO

-- Creating primary key on [ID_I] in table 'it_is_me'
ALTER TABLE [dbo].[it_is_me]
ADD CONSTRAINT [PK_it_is_me]
    PRIMARY KEY CLUSTERED ([ID_I] ASC);
GO

-- Creating primary key on [ID_reputation] in table 'reputation'
ALTER TABLE [dbo].[reputation]
ADD CONSTRAINT [PK_reputation]
    PRIMARY KEY CLUSTERED ([ID_reputation] ASC);
GO

-- Creating primary key on [ID_role] in table 'role_love_of_animal'
ALTER TABLE [dbo].[role_love_of_animal]
ADD CONSTRAINT [PK_role_love_of_animal]
    PRIMARY KEY CLUSTERED ([ID_role] ASC);
GO

-- Creating primary key on [ID_help] in table 'help'
ALTER TABLE [dbo].[help]
ADD CONSTRAINT [PK_help]
    PRIMARY KEY CLUSTERED ([ID_help] ASC);
GO

-- Creating primary key on [ID_I_found] in table 'I_found'
ALTER TABLE [dbo].[I_found]
ADD CONSTRAINT [PK_I_found]
    PRIMARY KEY CLUSTERED ([ID_I_found] ASC);
GO

-- Creating primary key on [ID_I_have_lost] in table 'I_have_lost'
ALTER TABLE [dbo].[I_have_lost]
ADD CONSTRAINT [PK_I_have_lost]
    PRIMARY KEY CLUSTERED ([ID_I_have_lost] ASC);
GO

-- Creating primary key on [ID_help_animal] in table 'I_want_to_shelter_from_the_shelter'
ALTER TABLE [dbo].[I_want_to_shelter_from_the_shelter]
ADD CONSTRAINT [PK_I_want_to_shelter_from_the_shelter]
    PRIMARY KEY CLUSTERED ([ID_help_animal] ASC);
GO

-- Creating primary key on [ID_animal1] in table 'id_animal'
ALTER TABLE [dbo].[id_animal]
ADD CONSTRAINT [PK_id_animal]
    PRIMARY KEY CLUSTERED ([ID_animal1] ASC);
GO

-- Creating primary key on [ID_shelter1] in table 'id_shelter'
ALTER TABLE [dbo].[id_shelter]
ADD CONSTRAINT [PK_id_shelter]
    PRIMARY KEY CLUSTERED ([ID_shelter1] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [help] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [FK_help_to_main_table]
    FOREIGN KEY ([help])
    REFERENCES [dbo].[help]
        ([ID_help])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_help_to_main_table'
CREATE INDEX [IX_FK_help_to_main_table]
ON [dbo].[all_information]
    ([help]);
GO

-- Creating foreign key on [i_found] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [FK_I_found_main_table]
    FOREIGN KEY ([i_found])
    REFERENCES [dbo].[I_found]
        ([ID_I_found])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_I_found_main_table'
CREATE INDEX [IX_FK_I_found_main_table]
ON [dbo].[all_information]
    ([i_found]);
GO

-- Creating foreign key on [i_have_lost] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [FK_i_have_lost_to_maint_table]
    FOREIGN KEY ([i_have_lost])
    REFERENCES [dbo].[I_have_lost]
        ([ID_I_have_lost])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_i_have_lost_to_maint_table'
CREATE INDEX [IX_FK_i_have_lost_to_maint_table]
ON [dbo].[all_information]
    ([i_have_lost]);
GO

-- Creating foreign key on [i_want_to_shelter_from_the_shelter] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [FK_I_want_to_shelter]
    FOREIGN KEY ([i_want_to_shelter_from_the_shelter])
    REFERENCES [dbo].[I_want_to_shelter_from_the_shelter]
        ([ID_help_animal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_I_want_to_shelter'
CREATE INDEX [IX_FK_I_want_to_shelter]
ON [dbo].[all_information]
    ([i_want_to_shelter_from_the_shelter]);
GO

-- Creating foreign key on [it_is_me] in table 'all_information'
ALTER TABLE [dbo].[all_information]
ADD CONSTRAINT [FK_it_is_me]
    FOREIGN KEY ([it_is_me])
    REFERENCES [dbo].[it_is_me]
        ([ID_I])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_it_is_me'
CREATE INDEX [IX_FK_it_is_me]
ON [dbo].[all_information]
    ([it_is_me]);
GO

-- Creating foreign key on [ID_how_to_contact_me] in table 'it_is_me'
ALTER TABLE [dbo].[it_is_me]
ADD CONSTRAINT [FK_how_to_Contact_telephone_or_email]
    FOREIGN KEY ([ID_how_to_contact_me])
    REFERENCES [dbo].[how_to_contact_me]
        ([ID_how_to_contact_me])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_how_to_Contact_telephone_or_email'
CREATE INDEX [IX_FK_how_to_Contact_telephone_or_email]
ON [dbo].[it_is_me]
    ([ID_how_to_contact_me]);
GO

-- Creating foreign key on [ID_reputation] in table 'it_is_me'
ALTER TABLE [dbo].[it_is_me]
ADD CONSTRAINT [FK_reputation]
    FOREIGN KEY ([ID_reputation])
    REFERENCES [dbo].[reputation]
        ([ID_reputation])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_reputation'
CREATE INDEX [IX_FK_reputation]
ON [dbo].[it_is_me]
    ([ID_reputation]);
GO

-- Creating foreign key on [id_role] in table 'reputation'
ALTER TABLE [dbo].[reputation]
ADD CONSTRAINT [FK_role]
    FOREIGN KEY ([id_role])
    REFERENCES [dbo].[role_love_of_animal]
        ([ID_role])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role'
CREATE INDEX [IX_FK_role]
ON [dbo].[reputation]
    ([id_role]);
GO

-- Creating foreign key on [ID_animal] in table 'I_want_to_shelter_from_the_shelter'
ALTER TABLE [dbo].[I_want_to_shelter_from_the_shelter]
ADD CONSTRAINT [FK_ID_animal]
    FOREIGN KEY ([ID_animal])
    REFERENCES [dbo].[id_animal]
        ([ID_animal1])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ID_animal'
CREATE INDEX [IX_FK_ID_animal]
ON [dbo].[I_want_to_shelter_from_the_shelter]
    ([ID_animal]);
GO

-- Creating foreign key on [ID_shelter] in table 'I_want_to_shelter_from_the_shelter'
ALTER TABLE [dbo].[I_want_to_shelter_from_the_shelter]
ADD CONSTRAINT [FK_ID_shelter]
    FOREIGN KEY ([ID_shelter])
    REFERENCES [dbo].[id_shelter]
        ([ID_shelter1])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ID_shelter'
CREATE INDEX [IX_FK_ID_shelter]
ON [dbo].[I_want_to_shelter_from_the_shelter]
    ([ID_shelter]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
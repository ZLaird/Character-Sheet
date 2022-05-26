USE master
GO

--drop database if it exists and create a new one
IF DB_ID('CharacterSheet') IS NOT NULL
BEGIN
	ALTER DATABASE CharacterSheet SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE CharacterSheet;
END

CREATE DATABASE CharacterSheet
GO

USE CharacterSheet
GO

--create tables
/* authentication stuff, add later
CREATE TABLE User (
	
)
*/
CREATE TABLE UserProfile (
	--this table needs to change once authentication is added
	UserProfileId int IDENTITY(1,1) NOT NULL,
	UserName varchar(50) NOT NULL

	CONSTRAINT [PK_UserProfile] PRIMARY KEY (UserProfileId)
)

CREATE TABLE PlayerCharacter (
	PlayerCharacterId int IDENTITY(1,1) NOT NULL,
	CharacterName varchar(50) NOT NULL

	CONSTRAINT [PK_PlayerCharacter] PRIMARY KEY (PlayerCharacterId)
)

CREATE TABLE UserPlayerCharacter ( --Junction
	UserProfileId int NOT NULL,
	PlayerCharacterId int NOT NULL

	CONSTRAINT [PK_UserPlayerCharacter] PRIMARY KEY (UserProfileId, PlayerCharacterId),
    CONSTRAINT [FK_UserPlayerCharacter_UserProfile] FOREIGN KEY (UserProfileId) REFERENCES [UserProfile] (UserProfileId),
	CONSTRAINT [FK_UserPlayerCharacter_PlayerCharacter] FOREIGN KEY (PlayerCharacterId) REFERENCES [PlayerCharacter] (PlayerCharacterId)
)
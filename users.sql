CREATE TABLE users (
    [id] int NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [login] VARCHAR(50) NOT NULL UNIQUE,
    [password] BINARY(50) NOT NULL,
    [tokenExpiration] INT(10) NOT NULL,
    [writePermission] BIT NOT NULL,
    [readPermission] BIT NOT NULL,
    [createDate] DATETIME2(6) DEFAULT GETDATE(),
    [lastLoginDate] DATETIME2(6) DEFAULT GETDATE(),
    [lastLoginIp] VARCHAR(45) NOT NULL,
    [active] BIT DEFAULT 1
);
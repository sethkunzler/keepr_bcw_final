-- Active: 1711142519797@@35.87.147.206@3306@forgiving_monk_a379d6_db
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts ADD COLUMN coverImg VARCHAR(500) DEFAULT 'https://images.unsplash.com/34/BA1yLjNnQCI1yisIZGEi_2013-07-16_1922_IMG_9873.jpg?q=80&w=3871&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D' COMMENT 'Cover Image';

DESC accounts;

CREATE TABLE keeps(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
  kept INT DEFAULT 0 COMMENT 'Kept Count';
  -- Creator profile is a Virtual
  -- Kept Count is a Virtual
);

-- ALTER TABLE keeps ADD COLUMN kept INT DEFAULT 0 COMMENT 'Kept Count';
DROP TABLE vaultKeeps, vaults, keeps;
DESC keeps;

CREATE TABLE vaults(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT  NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  isPrivate BOOLEAN NOT NULL COMMENT 'Private or Public Condition',
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  -- Creator Profile is a Virtual
  -- UNIQUE (name, creatorId)
);

CREATE TABLE vaultKeeps(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  keepId INT NOT NULL,
  vaultId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL, 
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
  UNIQUE (keepId, vaultId)
);

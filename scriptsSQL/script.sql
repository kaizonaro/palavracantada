/*CREATE TABLE Comentario
(COM_ID				INT PRIMARY KEY IDENTITY(1,1)
,TAR_ID				INT REFERENCES Tarefa (TAR_ID) NULL
,REL_ID				INT REFERENCES RelatoTarefa (REL_ID) NULL
,USU_ID				INT REFERENCES Usuario (USU_ID) NULL
,ADM_ID				INT REFERENCES Administrador (ADM_ID) NULL
,COM_TEXTO			TEXT NOT NULL
,COM_DH_PUBLICACAO	DATETIME NOT NULL DEFAULT(getDate())
,COM_ATIVO			BIT NOT NULL DEFAULT(1)
)

CREATE TABLE Recompensa
(REC_ID				INT PRIMARY KEY IDENTITY (1,1)
,REC_TITULO			VARCHAR(128) NOT NULL
,REC_
)
*/
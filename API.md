# Api

## Controllers

### ScoreController.cs

La API té un controlador **'ScoreController'** que gestiona totes les operacions relacionades amb les puntuacions. Aquest controlador interactúa amb una base de dades a través de **'AppDbContext'**.

#### GetScores

Ruta: **'apid/Score/GetScores'**
Mètode: GET
Descripció: Obté totes les puntiacions emmagatzemades a la base de dades.
Resposta: Retorna una llista de puntuacions.

#### getScoreById

Ruta: **'api/Score/GetScoreById/{id}'**
Mètode: GET
Descripció: Obté una puntuació específica per el seu ID.
Resposta: Retorna la puntuació corresponent al ID proporcionat.

#### GetScoresByCharacter

Ruta: **'api/Score/GetScoreByCharacter/{name}'**
Mètode: GET
Descripció: Obté totes les puntuacions d'un personatge específic.
Resposta. retorna una llista de puntuacions del personatge proporcionat.

#### AddScore

Ruta: **'api/Score/PostScore'**:
Mètode: POST
Descripció: Afegeix una nova puntuació a la base de dades.
Resposta: Retorna una resposta indicant si l'operació ha set existosa.

### UserController.cs

El controlador **'UserController'** interactúa amb la base de dades a través del context **'AppDbContext'** i gestiona les respostes utilitzant un objecte **'ResponseDTO'**.

#### GetUsers

Ruta: **'api/User/GetUsers'**
Mètode: GET
Descripció: Obté tots els usuaris de la base de dades i desencripta les seves contrasenyes.
Resposta: Retorna una llista d'usuaris amb les sevse contrasenyes desencriptades.

#### GetUserByUsername

Ruta: **'api/UserGetUSerByUsername/{username}'**
Mètode: GET
Descripció: Obté un usuari específic per el seu nom de usuari i desencripta la seva contrasenya.
Resposta: Retorna l'usuari corresponent al nom d'usuari proporcionat.

#### PostUser

Ruta: **'api/User/PostUser'**
Mètode: POST
Descripció: Afegeix un nou usuari a la base de dades i encripta la seva contrasenya abans d'emmagatzemar-la.
Resposta: Retorna una resposta indicant si l'operació ha set exitosa.

#### PutUser

Ruta: **'api/User/PutUser'**
Mètode: PUT
Descripció: Actualitza un usuari existent a la base de dades.
Resposta: Retorna una resposta indicant si l'operació ha set exitosa.

#### DeleteUser

Ruta: **'api/User/GetScoresByUser/{username}'**
Mètode: GET
Descripció: Obté totes les puntuacions d'un usuari específic.
Resposta: Retorna una llista de puntuacions de l'usuari proporcionat.

## Data

### AppDbContext

Context de la Base de Dades: **'AppDbContext'** és el pont entre l'aplicació i la base de dades.

DbSets: **'Scores'** i **'Users'** representen les taules a la base de dades.

Registre del context: A **'Startup.cs'** es registra **'AppDbContext'** perquè pugui ser utilitzat a través d'injecció de dependències.

Cadena de connexió: Configurada a **'appsettings.json'**.

## Models

### DTO 

La classe **'ResponseDTO'** és una Data Transfer Object(DTO) que encapsula l'estructura de la resposta que s'enviarà al client per qualsevol petició API. Això assegura que totes les respostes segueixin un format consistent.

### Score

La classe **'Score'** és un model de dades que representa les puntuacions obtingudes pels jugadors en el joc. Cada instància d'aquesta casse correspon a una fila en la taula de puntiacions a la base de dades.

### User

La classe **'User'** és un model de dades qu representa a un usuari en le sistema. Cada instància d'aquesta clase correspon a una fila a la taula d'usuaris a la base de dades.

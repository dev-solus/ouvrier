export class User {
    id = 0;
    type = '';
    role = 1;
    idMetier = 0;
    username = '';
    lastName = '';
    dateNaissance = new Date();
    email = '';
    password = '';
    civilite = '';
    tel = '';
    imageUrl = '';
    idLocation = 0;
    location = new Location();
    metier = new Metier();
}

export class Location {
    id = 0;
    adresse = '';
    lat = Math.round(33.927251 * 100) / 100;
    lng = Math.round(-6.887098 * 100) / 100;
    draggble = false;
    idQuartier = 0;
    quartier = new Quartier();
    users: User[] = [];
}

export class Quartier {
    id = 0;
    nom = '';
    idVille = -1;
    ville = new Ville();
}

export class Ville {
    id = 0;
    nom = '';
}

export class Metier {
    id = 0;
    nom = '';
}

export class Catalogue {
    id = 0;
    nom = '';
    idUser = 0;
    articles: Article[] = [];
    user = new User();
}

export class Article {
    id = 0;
    description = '';
    imageUrl = '';
    idCatalogue = 0;
}

export class Likeuser {
    idUser = 0;
    idOuvrier = 0;
    note = 0;
}

export class Favorie {
    idOuvrier = 0;
    idUser = 0;
    ouvrier = new User();
}

export class Commentaire {
    id = 0;
    idOuvrier = 0;
    idUser = 0;
    comment = '';
    date = new Date();
    user = new User();
}

INSERT INTO Estado VALUES ('Activo'),
            ('Inactivo'),
            ('Pendiente'),
            ('Pago'),
            ('Vencido');

INSERT INTO Marca VALUES ('Visa'),
            ('MasterCard');

INSERT INTO Tipo_Usuario VALUES ('Administrador'),
            ('Cliente');

INSERT INTO Usuario VALUES ('304730944','Kenneth','Leiva','Sanchez','kenneth@asada.com','admin',86699336,1),
            ('116060958','Michael','Sevilla','Miranda','michael@asada.com','admin',71116945,2);

INSERT INTO Medidor VALUES ('Ipis',116060958),
            ('Tejar',304730944);

INSERT INTO Averia VALUES ('Reparación','Ipis','2021-11-27','2021-12-10',1),
            ('Mantenimiento','Tejar','2021-11-27','2021-12-09',2);

INSERT INTO Recibo VALUES ('2021-11-01',11500,115,1,116060958,'2021-11-01',3),
            ('2021-11-01',15000,150,2,304730944,'2021-11-01',4);

INSERT INTO Tarjeta VALUES (4532020274467452,'Michael Sevilla',234,'2025-11-01',1,116060958),
            (5461823853347918,'Kenneth Leiva',525,'2024-09-01',2,304730944);

INSERT INTO Comprobante VALUES (116060958,1,4532020274467452),
            (304730944,2,5461823853347918);
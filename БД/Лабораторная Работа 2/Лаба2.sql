-- create
CREATE TABLE сотрудники (
  Id INTEGER PRIMARY KEY auto_increment,
  ФИО TEXT NOT NULL,
  Телефон TEXT NOT NULL,
  ЗП INTEGER NOT NULL,
  Адрес TEXT NOT NULL,
  Трудовая_деятельность INTEGER NOT NULL
);

-- insert
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Мокрушин Никита Дмитриевич','+79223110848',100000 ,'Пушкина 52', 5);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Мокрый Дмитрий Никитьевич','+79223110848',50000 ,'Челюскинцев 131', 1);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Мокрица Семен Валерьевич','+79223110848',25000 ,'Королева 42', 2);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Гнидкинс Вальдемар Рейхстагович','+79223110848',12500 ,'Дедюкина 18', 3);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Тихий Никита Сергеевич','+79223110848',200000 ,'Дедюкина 15', 6);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Нечаев Артем Сергеевич','+79223110848',15000 ,'Дедюкина 52', 12);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Молодой Никита Альбертович','+79223110848',20000 ,'Королева 77', 2);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Селяк Матвей Альферович','+79223110848',12345 ,'Трудовая 12', 1);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Талант Сергей Пиратович','+79223110848',54321 ,'Гагарина 80', 3);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Найнмайс Найткор Дрипович','+79223110848',21345 ,'Ельцина 152', 12);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Кайанжелс Ньюграунд Джекович','+79223110848',32145 ,'Кальцина 771', 19);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Роджерс Нейд Амерьевич','+79223110848',23451 ,'Каминцев 15', 4);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Рейгн Кьюкей Соулридович','+79223110848',45231 ,'Семина 62', 2);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Одетари Мой Папович','+79223110848',42351 ,'Калия 7', 11);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Бейбикьют Мария Олеговна','+79223110848',25431 ,'Лебедева 89', 10);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Ричман Томми Эдуардович','+79223110848',25313 ,'Галилео 56', 2);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Бритиш Сии Пауверович','+79223110848',62351 ,'Савелиев 88', 4);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Свами Саунд Рефьюзович','+79223110848',75214 ,'Пушкина 75', 5);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Бебрович Никита Феофилович','+79223110848',26125 ,'Пушкина 90', 5);
INSERT INTO сотрудники(ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('Клим Жуков Свинович','+79223110848',15 ,'Ярицева 75', 13);

SELECT ФИО, Телефон, ЗП FROM сотрудники;
SELECT ФИО, Адрес FROM сотрудники ORDER BY Адрес asc;
SELECT ФИО, Трудовая_деятельность FROM сотрудники WHERE Трудовая_деятельность > 4;
DROP TABLE IF EXISTS "public"."dac_student";
DROP TABLE IF EXISTS "public"."dac_course";
CREATE TABLE "public"."dac_student" ( 
  "id" SERIAL,
  "first_name" VARCHAR(20) NULL,
  "last_name" VARCHAR(20) NULL,
  "email" VARCHAR(100) NULL,
  "age" INTEGER NULL,
  "password" TEXT NULL
);
CREATE TABLE "public"."dac_course" ( 
  "id" SERIAL,
  "name" VARCHAR(20) NULL,
  "points" INTEGER NULL,
  "start_date" DATE NULL,
  "end_date" DATE NULL,
  CONSTRAINT "undefined" PRIMARY KEY ("id")
);
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Rob', 'Ztewartz', 'zzz@chas.se', 50, '1111');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Winnie', 'DaPooh', 'dapooh@chas.se', 32, '2222');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Moogli', 'DJ', 'moodj@chas.se', 45, '1111');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Pablo', 'Discobar', 'padi@chas.se', 52, 'AllEyesOnMe1337');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('asd', 'asd', 'asd', 31, 'asd');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Chapo', 'Guzzman', 'chaguz@chas.se', 56, 'elCHapohh5.56');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('asd', 'asd', 'asd', 123, 'lolIdk13');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Ferdinan', 'Ligallow', 'feli@chas.se', 28, 'WhatIsDrugs?');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('Danilo', 'Acosta', 'daaco@chas.se', 30, 'NyttLösenIgen123');
INSERT INTO "public"."dac_student" ("first_name", "last_name", "email", "age", "password") VALUES ('John', 'Rambo', 'jora@chas.se', 62, 'newPassword123');
INSERT INTO "public"."dac_course" ("name", "points", "start_date", "end_date") VALUES ('JavaScript', 50, '2022-10-11', '2022-11-11');
INSERT INTO "public"."dac_course" ("name", "points", "start_date", "end_date") VALUES ('C#', 50, '2022-11-12', '2023-02-20');
INSERT INTO "public"."dac_course" ("name", "points", "start_date", "end_date") VALUES ('HTML/CSS', 50, '2022-09-10', '2022-10-10');
INSERT INTO "public"."dac_course" ("name", "points", "start_date", "end_date") VALUES ('Angular', 50, '2023-02-25', '2023-05-20');

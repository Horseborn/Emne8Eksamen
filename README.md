### Eksamen Emne 8 - Cloudteknikker, Web-arkitektur og Container Teknologi

## Prosjektet inneholder følgende komponenter

### Ett backend api

- Rest api som kjører på port 8080
- Kobler til MySQL database
- Er containisert med Docker

### MySQL Database

- Database: product_db
- Brukernavn: product-api
- Passord: securepass
- Har persistent lagring ved hjelp av volum

### Nginx reverse proxy

- Ruter API trafkk
- Eksponerer API
- Containerisert med Docker

## Oppsett

Med Docker og Docker compose installert
Bygg og start containere med følgende kommando

`Docker-compose up -d --build`

Bekreft containere kjører med

`Docker ps`

Apiet kan deretter testes ved hjelp av disse curl kommandoene

curl http://localhost/api/products

curl http://localhost/api/health

## Publisering av images til Docker Hub

Er du allerede innlogget på Docker Desktop, kan du kjøre

`docker login`

Bygg og legg til en passende tag

`docker build -t <docker-hub-user>/products-api:latest ./products-api`

`docker build -t <docker-hub-user>/products-web:latest ./products-web`

Push så images til Docker Hub ved hjelp av push kommandoen

`docker push <docker-hub-user>/products-api:latest`

`docker push <docker-hub-user>/products-web:latest`

Vi kan deretter oppdatere docker-compose.yml filen fra å bruke "build" til å bruke "images" da vi ikke lenger henter api
og web images lokalt, men fra docker hub.
Da er det viktig å legge ved korrekt url til riktig image

`services:
  products-api:
    image: <docker-hub-user>/products-api:latest
  products-web:
    image: <docker-hub-user>/products-web:latest`

Om du har, slett lokale instanser av api og web images, før du kjører kommandoen

`docker-compose up -d`

På nytt, da skal du se at docker automatisk henter images fra Docker hub
Du skal nå kunne bruke denne curl kommandoen til å spørre mot apiet

`curl http://localhost/api/products`

## Deploy API til AWS EC2 med Nginx

1. Opprett en VPC i AWS
2. Opprett en EC2 instans (Ubuntu, Amazon Linux)
3. Opprett ett key pair og lagre den en trygt sted
4. Tilatt følgende traff i security Groups
    - Port 22 (SSH)
    - Port 80 (HTTP)
    - Port 8080 (Ved API-testing)
5. Koble til EC2 instansen ved hjelp av ssh kommandoen
   `ssh -i "Emne8Eksamen.pem" ec2-user@<EC2-PUBLIC-IP>`
6. Install Docker og Docker Compose ved hjelp av følgende kommandoer

`sudo yum update -y`

`sudo yum install -y docker`

`sudo service docker start`

`sudo usermod -aG docker ec2-user`

`newgrp docker`

7. Overfør docker-compose.yml filen til EC2 instansen ved hjelp av følgende kommando

`scp -i "Emne8Eksamen.pem" docker-compose.yml ec2-user@<EC2-PUBLIC-IP>:~`

8. Start kontainerene på vanlig vis ved hjelp av kommandoen

`docker-compose up -d`

9. API'et kan nå testes ved hjelp av curl

`curl http://<EC2-PUBLIC-IP>/api/products`

`curl http://<EC2-PUBLIC-IP>/api/health`

10. Ved behov for feilsøking kan docker loggen være ett godt sted å starte, bruk kommandoen nedenfor for å vise logg

`docker logs products-api --tail 50/100`

### Prosjekt Linker

### Docker hub:

- https://hub.docker.com/repository/docker/horseborn/products-api/general
- https://hub.docker.com/repository/docker/horseborn/products-web/general

### Github prosjekt link

- https://github.com/Horseborn/Emne8Eksamen

![Isaac, thumbs up](https://media.tenor.com/6VBWwSJMRhEAAAAe/thumbs-up-tboi.png)


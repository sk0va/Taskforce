# docker build -t taskforce -f ./docker/Dockerfile ./src

docker compose -f ./docker/docker-compose.env-only.yml -p env-only up --build